using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Repository.Entities;

namespace ClinicaFrba.Repository
{
    public class ListadoEspecialidadesDao : BaseDao<Especialidad>
    {


        public List<string> getEspecialidadesMasCanceladas(InfoParaListado info)
        {
            List<string> vRetorno = new List<string>();
            this.Connector.Open();
            String query;
            if (info.Mes != 0) { 
            query = "select top 5 e.varDescripcion as descripcion, count(t.bitEstado) as desertores " +
                "from dbo.Especialidad as e inner join dbo.ProfesionalXEspecialidad as pxe on e.intEspecialidadCodigo = pxe.intEspecialidadCodigo " +
                "inner join dbo.Profesional as p on p.intIdUsuario = pxe.intIdUsuario "+
                "inner join dbo.Turno as t on p.intIdUsuario = t.intIdDoctor AND YEAR(t.datFechaTurno) ="+ info.Ano + "AND MONTH(t.datFechaTurno) = " + info.Mes + 
                "where t.bitEstado = 0 " +
                "group by e.varDescripcion " +
                "order by desertores desc;";
            }
            if(info.Mes == 0)
            {
                if(info.Semestre == 1) { 
                query = "select top 5 e.varDescripcion as descripcion, count(t.bitEstado) as desertores " +
                "from dbo.Especialidad as e inner join dbo.ProfesionalXEspecialidad as pxe on e.intEspecialidadCodigo = pxe.intEspecialidadCodigo " +
                "inner join dbo.Profesional as p on p.intIdUsuario = pxe.intIdUsuario " +
                "inner join dbo.Turno as t on p.intIdUsuario = t.intIdDoctor AND YEAR(t.datFechaTurno) =" + info.Ano + "AND MONTH(t.datFechaTurno) < 7 " +
                "where t.bitEstado = 0 " +
                "group by e.varDescripcion " +
                "order by desertores desc;";
                }
                else
                {
                query = "select top 5 e.varDescripcion as descripcion, count(t.bitEstado) as desertores " +
                "from dbo.Especialidad as e inner join dbo.ProfesionalXEspecialidad as pxe on e.intEspecialidadCodigo = pxe.intEspecialidadCodigo " +
                "inner join dbo.Profesional as p on p.intIdUsuario = pxe.intIdUsuario " +
                "inner join dbo.Turno as t on p.intIdUsuario = t.intIdDoctor AND YEAR(t.datFechaTurno) =" + info.Ano + "AND MONTH(t.datFechaTurno) > 6" +
                "where t.bitEstado = 0 " +
                "group by e.varDescripcion " +
                "order by desertores desc;";
                }
            }
            this.Command = new SqlCommand(query, this.Connector);

            SqlDataReader resultado = Command.ExecuteReader();


            while (resultado.Read())
            {
                vRetorno.Add(resultado["descripcion"].ToString());
            }


            this.Connector.Close();

            return vRetorno;

        }

        public List<string> getEspecialidadesMasConsultadas(InfoParaListado info)
        {
            List<string> vRetorno = new List<string>();
            this.Connector.Open();
            String query;
            if (info.Mes != 0)
            {
                query = "select top 5 e.varDescripcion as descripcion, count(t.bitEstado) as consultasHechas " +
                "from dbo.Especialidad as e inner join dbo.ProfesionalXEspecialidad as pxe on e.intEspecialidadCodigo = pxe.intEspecialidadCodigo " +
                "inner join dbo.Profesional as p on p.intIdUsuario = pxe.intIdUsuario " +
                "inner join dbo.Turno as t on p.intIdUsuario = t.intIdDoctor AND YEAR(t.datFechaTurno) =" + info.Ano + "AND MONTH(t.datFechaTurno) = " + info.Mes +
                "inner join dbo.Asistencia as a on a.intIdTurno = t.intIdTurno" +
                "where a.bitAtendido = 1 " +
                "group by e.varDescripcion " +
                "order by consultasHechas desc;";
            }
            if (info.Mes == 0)
            {
                if (info.Semestre == 1)
                {
                    query = "select top 5 e.varDescripcion as descripcion, count(t.bitEstado) as consultasHechas " +
                    "from dbo.Especialidad as e inner join dbo.ProfesionalXEspecialidad as pxe on e.intEspecialidadCodigo = pxe.intEspecialidadCodigo " +
                    "inner join dbo.Profesional as p on p.intIdUsuario = pxe.intIdUsuario " +
                    "inner join dbo.Turno as t on p.intIdUsuario = t.intIdDoctor AND YEAR(t.datFechaTurno) =" + info.Ano + "AND MONTH(t.datFechaTurno) < 7 " +
                    "inner join dbo.Asistencia as a on a.intIdTurno = t.intIdTurno" +
                    "where a.bitAtendido = 1 " +
                    "group by e.varDescripcion " +
                    "order by consultasHechas desc;";
                }
                else
                {
                    query = "select top 5 e.varDescripcion as descripcion, count(t.bitEstado) as consultasHechas " +
                    "from dbo.Especialidad as e inner join dbo.ProfesionalXEspecialidad as pxe on e.intEspecialidadCodigo = pxe.intEspecialidadCodigo " +
                    "inner join dbo.Profesional as p on p.intIdUsuario = pxe.intIdUsuario " +
                    "inner join dbo.Turno as t on p.intIdUsuario = t.intIdDoctor AND YEAR(t.datFechaTurno) =" + info.Ano + "AND MONTH(t.datFechaTurno) > 6 " +
                    "inner join dbo.Asistencia as a on a.intIdTurno = t.intIdTurno" +
                    "where a.bitAtendido = 1 " +
                    "group by e.varDescripcion " +
                    "order by consultasHechas desc;";
                }
            }

            this.Command = new SqlCommand(query, this.Connector);

            SqlDataReader resultado = Command.ExecuteReader();


            while (resultado.Read())
            {
                vRetorno.Add(resultado["descripcion"].ToString());
            }


            this.Connector.Close();

            return vRetorno;

        }


        public override void Add(Especialidad entidad)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Especialidad GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Especialidad entidad)
        {
            throw new NotImplementedException();
        }
    }
    

}
