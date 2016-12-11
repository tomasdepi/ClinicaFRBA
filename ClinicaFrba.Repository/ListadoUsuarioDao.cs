using ClinicaFrba.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClinicaFrba.Repository
{
    public class ListadoUsuarioDao : BaseDao<Usuario>
    {



        public List<Usuario> getProfesionalesMasConsultados(InfoParaListado info)
        {
            List<Usuario> vRetorno = new List<Usuario>();
            this.Connector.Open();

            String query = "";
            if (info.Mes != 0)
            {
                query = "select top 5 u.varNombre as nombre, u.varApellido as apellido, t.intEspecialidadCodigo as especialidad, count(t.bitEstado) as atendidos" +
                "from dbo.Usuario as u inner join dbo.Turno as t on u.intIdUsuario = t.intIdDoctor AND YEAR(t.datFechaTurno) =" + info.Ano + "AND MONTH(t.datFechaTurno) = " + info.Mes +
                "inner join dbo.Asistencia as a on a.intIdTurno = t.intIdTurno" +
                "inner join dbo.Afiliado as afi on afi.intIdUsuario = u.intIdUsuario" +
                "where a.bitAtendido = 1 AND afi.intCodigoPlan =" + info.Plan +
                "group by u.intIdUsuario, t.intEspecialidadCodigo " +
                "order by atendidos desc;";
            }
            if (info.Mes == 0)
            {
                if (info.Semestre == 1)
                {
                     query = "select top 5 u.varNombre as nombre, u.varApellido as apellido, t.intEspecialidadCodigo as especialidad, count(t.bitEstado) as atendidos" +
                "from dbo.Usuario as u inner join dbo.Turno as t on u.intIdUsuario = t.intIdDoctor AND YEAR(t.datFechaTurno) =" + info.Ano + "AND MONTH(t.datFechaTurno) < 7 " +
                "inner join dbo.Asistencia as a on a.intIdTurno = t.intIdTurno" +
                "inner join dbo.Afiliado as afi on afi.intIdUsuario = u.intIdUsuario" +
                "where a.bitAtendido = 1 AND afi.intCodigoPlan =" + info.Plan +
                "group by u.intIdUsuario, t.intEspecialidadCodigo " +
                "order by atendidos desc;";
                }
                else
                {
                    query = "select top 5 u.varNombre as nombre, u.varApellido as apellido, t.intEspecialidadCodigo as especialidad, count(t.bitEstado) as atendidos" +
                "from dbo.Usuario as u inner join dbo.Turno as t on u.intIdUsuario = t.intIdDoctor AND YEAR(t.datFechaTurno) =" + info.Ano + "AND MONTH(t.datFechaTurno) > 6 " +
                "inner join dbo.Asistencia as a on a.intIdTurno = t.intIdTurno" +
                "inner join dbo.Afiliado as afi on afi.intIdUsuario = u.intIdUsuario" +
                "where a.bitAtendido = 1 AND afi.intCodigoPlan =" + info.Plan +
                "group by u.intIdUsuario, t.intEspecialidadCodigo " +
                "order by atendidos desc;";
                }
            }


            this.Command = new SqlCommand(query, this.Connector);

            SqlDataReader resultado = Command.ExecuteReader();


            while (resultado.Read())
            {
                Usuario usuario = new Usuario();
                usuario.Nombre = resultado["nombre"].ToString();
                usuario.Apellido = resultado["apellido"].ToString();
                usuario.EstadoCivil = resultado["especialidad"].ToString();
                vRetorno.Add(usuario);
            }


            this.Connector.Close();

            return vRetorno;

        }

       // linea de recordatorio para que rompa y no cuelgue. Revisar horarios de agenda para esta query;

        public List<Usuario> getProfesionalesConMenosHorasTrabajadas(InfoParaListado info)
        {
            List<Usuario> vRetorno = new List<Usuario>();
            this.Connector.Open();
            String query = "";

            if (info.Mes != 0)
            {

                query = "select top 5 u.varApellido as apellido, u.varNombre as nombre, sum(DATEDIFF(minute, a.timeHoraInicio, a.timeHoraFin)) as horasTrabajadas"+
                "from dbo.Usuario u inner join dbo.Profesional p on p.intIdUsuario = u.intIdUsuario" +
                "inner join dbo.ProfesionalXEspecialidad pxe on pxe.intIdUsuario = p.intIdUsuario" +
                "inner join dbo.Especialidad e on e.intEspecialidadCodigo = pxe.intEspecialidadCodigo" +
                "inner join dbo.Agenda a on a.intIdProfesional = p.intIdUsuario" +
                "inner join dbo.Turno t on t.intIdDoctor = p.intIdUsuario" +
                "inner join dbo.Afiliado afi on afi.intIdUsuario = t.intIdPaciente" +
                "where afi.intCodigoPlan = 123 and e.varDescripcion = 'Traumatología' AND YEAR(t.datFechaTurno) = " + info.Ano + "AND MONTH(t.datFechaTurno) = " + info.Mes +
                "group by u.varApellido, u.varNombre"+
                "order by horasTrabajadas asc;";
            }
            if (info.Mes == 0)
            {
                if (info.Semestre == 1)
                {
                query = "select top 5 u.varApellido as apellido, u.varNombre as nombre, sum(DATEDIFF(minute, a.timeHoraInicio, a.timeHoraFin)) as horasTrabajadas" +
                "from dbo.Usuario u inner join dbo.Profesional p on p.intIdUsuario = u.intIdUsuario" +
                "inner join dbo.ProfesionalXEspecialidad pxe on pxe.intIdUsuario = p.intIdUsuario" +
                "inner join dbo.Especialidad e on e.intEspecialidadCodigo = pxe.intEspecialidadCodigo" +
                "inner join dbo.Agenda a on a.intIdProfesional = p.intIdUsuario" +
                "inner join dbo.Turno t on t.intIdDoctor = p.intIdUsuario" +
                "inner join dbo.Afiliado afi on afi.intIdUsuario = t.intIdPaciente" +
                "where afi.intCodigoPlan = 123 and e.varDescripcion = 'Traumatología' AND YEAR(t.datFechaTurno) = " + info.Ano + "AND MONTH(t.datFechaTurno) < 7"+
                "group by u.varApellido, u.varNombre" +
                "order by horasTrabajadas asc;";
                }
                if (info.Semestre == 2)
                {
                query = "select top 5 u.varApellido as apellido, u.varNombre as nombre, sum(DATEDIFF(minute, a.timeHoraInicio, a.timeHoraFin)) as horasTrabajadas" +
                "from dbo.Usuario u inner join dbo.Profesional p on p.intIdUsuario = u.intIdUsuario" +
                "inner join dbo.ProfesionalXEspecialidad pxe on pxe.intIdUsuario = p.intIdUsuario" +
                "inner join dbo.Especialidad e on e.intEspecialidadCodigo = pxe.intEspecialidadCodigo" +
                "inner join dbo.Agenda a on a.intIdProfesional = p.intIdUsuario" +
                "inner join dbo.Turno t on t.intIdDoctor = p.intIdUsuario" +
                "inner join dbo.Afiliado afi on afi.intIdUsuario = t.intIdPaciente" +
                "where afi.intCodigoPlan = 123 and e.varDescripcion = 'Traumatología' AND YEAR(t.datFechaTurno) = " + info.Ano + "AND MONTH(t.datFechaTurno) > 6" +
                "group by u.varApellido, u.varNombre" +
                "order by horasTrabajadas asc;";
                }
            }

                this.Command = new SqlCommand(query, this.Connector);

            SqlDataReader resultado = Command.ExecuteReader();


            while (resultado.Read())
            {
                Usuario user = new Usuario();
                user.Apellido = resultado["apellido"].ToString();
                user.Nombre = resultado["nombre"].ToString();
                vRetorno.Add(user);
            }


            this.Connector.Close();

            return vRetorno;
        }

  

        public List<Usuario> getAfiliadosQueCompraronMasBonos(InfoParaListado info)
        {
            List<Usuario> vRetorno = new List<Usuario>();
            this.Connector.Open();
            String query = "";

            if (info.Mes != 0) { 

                query = "select top 5 u.varNombre as nombre, u.varApellido as apellido, (select count(1) from dbo.Afiliado a2 where a2.intIdUsuario = a.intIdUsuario +1 OR a2.intIdUsuario = a.intIdUsuario -1) as tieneIntegrantes" +
                "from dbo.Usuario u inner join dbo.Afiliado a on u.intIdUsuario = a.intIdUsuario" +
                "inner join dbo.Bono b on b.intIdAfiliadoCompro = a.intIdUsuario" +
                "where year(b.datFechaCompra) = "+ 2015 + "and month(b.datFechaCompra) = " + info.Mes +
                "group by u.varNombre, u.varApellido, a.intIdUsuario" +
                "order by count(b.intIdBono) desc; ";
            }
            if (info.Mes == 0)
            {
                if (info.Semestre == 1)
                {
                    query = "select top 5 u.varNombre as nombre, u.varApellido as apellido, (select count(1) from dbo.Afiliado a2 where a2.intIdUsuario = a.intIdUsuario +1 OR a2.intIdUsuario = a.intIdUsuario -1) as tieneIntegrantes" +
                "from dbo.Usuario u inner join dbo.Afiliado a on u.intIdUsuario = a.intIdUsuario" +
                "inner join dbo.Bono b on b.intIdAfiliadoCompro = a.intIdUsuario" +
                "where year(b.datFechaCompra) = " + 2015 + "and month(b.datFechaCompra) < 7" +
                "group by u.varNombre, u.varApellido, a.intIdUsuario" +
                "order by count(b.intIdBono) desc; ";
                }
                if (info.Semestre == 2)
                {
                    query = "select top 5 u.varNombre as nombre, u.varApellido as apellido, (select count(1) from dbo.Afiliado a2 where a2.intIdUsuario = a.intIdUsuario +1 OR a2.intIdUsuario = a.intIdUsuario -1) as tieneIntegrantes" +
                "from dbo.Usuario u inner join dbo.Afiliado a on u.intIdUsuario = a.intIdUsuario" +
                "inner join dbo.Bono b on b.intIdAfiliadoCompro = a.intIdUsuario" +
                "where year(b.datFechaCompra) = " + 2015 + "and month(b.datFechaCompra) > 6" +
                "group by u.varNombre, u.varApellido, a.intIdUsuario" +
                "order by count(b.intIdBono) desc; ";
                }
            }
              

                this.Command = new SqlCommand(query, this.Connector);

            SqlDataReader resultado = Command.ExecuteReader();


            while (resultado.Read())
            {
                Usuario user = new Usuario();
                user.Apellido = resultado["apellido"].ToString();
                user.Nombre = resultado["nombre"].ToString();
                user.CantidadFamiliaresACargo = Int32.Parse(resultado["tieneIntegrantes"].ToString());
                vRetorno.Add(user);
            }


           this.Connector.Close();

           return vRetorno;
        }



        public override void Add(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Usuario entidad)
        {
            throw new NotImplementedException();
        }

    }
}
