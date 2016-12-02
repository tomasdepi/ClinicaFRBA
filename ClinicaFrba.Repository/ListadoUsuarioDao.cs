﻿using ClinicaFrba.Repository.Entities;
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

       

        //public List<Usuario> getProfesionalesMasConsultados(InfoParaListado info)
        //{
        //    List<Usuario> vRetorno = new List<Usuario>();
        //    this.Connector.Open();

        //    String query;
        //    if (info.Mes != 0)
        //    {
        //        query = "select top 5 u.varNombre as nombre, u.varApellido as apellido, e.intEspecialidadCodigo as especialidad, count(t.bitEstado) as atendidos" +
        //        "from dbo.Especialidad as e inner join dbo.ProfesionalXEspecialidad as pxe on e.intEspecialidadCodigo = pxe.intEspecialidadCodigo " +
        //        "inner join dbo.Profesional as p on p.intIdUsuario = pxe.intIdUsuario " +
        //        "inner join dbo.Usuario as u on p.intIdUsuario = u.intIdUsuario" +
        //        "inner join dbo.Turno as t on p.intIdUsuario = t.intIdDoctor AND YEAR(t.datFechaTurno) =" + info.Ano + "AND MONTH(t.datFechaTurno) = " + info.Mes +
        //        "inner join dbo.Asistencia as a on a.intIdTurno = t.intIdTurno" +
        //        "inner join dbo.Afiliado as afi on afi.intIdUsuario = u.intIdUsuario" +
        //        "where a.bitAsistencia = 1 AND afi.intCodigoPlan =" + info.Plan +
        //        "group by u.intIdUsuario, e.varDescripcion " +
        //        "order by atendidos desc;";
        //    }
        //    if (info.Mes == 0)
        //    {
        //        if (info.Semestre == 1)
        //        {
        //            query = "select top 5 u.varNombre as nombre, u.varApellido as apellido, e.intEspecialidadCodigo as especialidad, count(t.bitEstado) as atendidos" +
        //        "from dbo.Especialidad as e inner join dbo.ProfesionalXEspecialidad as pxe on e.intEspecialidadCodigo = pxe.intEspecialidadCodigo " +
        //        "inner join dbo.Profesional as p on p.intIdUsuario = pxe.intIdUsuario " +
        //        "inner join dbo.Usuario as u on p.intIdUsuario = u.intIdUsuario" +
        //        "inner join dbo.Turno as t on p.intIdUsuario = t.intIdDoctor AND YEAR(t.datFechaTurno) =" + info.Ano + "AND MONTH(t.datFechaTurno) < 7 " +
        //        "inner join dbo.Asistencia as a on a.intIdTurno = t.intIdTurno" +
        //        "inner join dbo.Afiliado as afi on afi.intIdUsuario = u.intIdUsuario" +
        //        "where a.bitAsistencia = 1 AND afi.intCodigoPlan =" + info.Plan +
        //        "group by u.intIdUsuario, e.varDescripcion " +
        //        "order by atendidos desc;";
        //        }
        //        else
        //        {
        //            query = "select top 5 u.varNombre as nombre, u.varApellido as apellido, e.intEspecialidadCodigo as especialidad, count(t.bitEstado) as atendidos" +
        //           "from dbo.Especialidad as e inner join dbo.ProfesionalXEspecialidad as pxe on e.intEspecialidadCodigo = pxe.intEspecialidadCodigo " +
        //           "inner join dbo.Profesional as p on p.intIdUsuario = pxe.intIdUsuario " +
        //           "inner join dbo.Usuario as u on p.intIdUsuario = u.intIdUsuario" +
        //           "inner join dbo.Turno as t on p.intIdUsuario = t.intIdDoctor AND YEAR(t.datFechaTurno) =" + info.Ano + "AND MONTH(t.datFechaTurno) > 6 " +
        //           "inner join dbo.Asistencia as a on a.intIdTurno = t.intIdTurno" +
        //           "inner join dbo.Afiliado as afi on afi.intIdUsuario = u.intIdUsuario" +
        //           "where a.bitAsistencia = 1 AND afi.intCodigoPlan =" + info.Plan +
        //           "group by u.intIdUsuario, e.varDescripcion " +
        //           "order by atendidos desc;";
        //        }
        //    }


        //    this.Command = new SqlCommand(query, this.Connector);

        //    SqlDataReader resultado = Command.ExecuteReader();


        //    while (resultado.Read())
        //    {
        //        Usuario usuario = new Usuario();
        //        usuario.Nombre = resultado["nombre"].ToString();
        //        usuario.Apellido = resultado["apellido"].ToString();
        //        usuario.Especialidades[0] = Int32.Parse(resultado["especialidad"].ToString());
        //        vRetorno.Add(usuario);
        //    }


        //    this.Connector.Close();

        //    return vRetorno;

        //}

        //linea de recordatorio para que rompa y no cuelgue. Revisar horarios de agenda para esta query;

        public List<string> getProfesionalesConMenosHorasTrabajadas(InfoParaListado info)
        {
            List<string> vRetorno = new List<string>();
            this.Connector.Open();



            String query = "select top 5 u.varNombre as nombre, u.varApellido as apellido, e.varDescripcion as descripcion, count(t.bitEstado) as atendidos" +
                "from dbo.Especialidad as e inner join dbo.ProfesionalXEspecialidad as pxe on e.intEspecialidadCodigo = pxe.intEspecialidadCodigo " +
                "inner join dbo.Profesional as p on p.intIdUsuario = pxe.intIdUsuario " +
                "inner join dbo.Usuario as u on p.intIdUsuario = u.intIdUsuario" +
                "inner join dbo.Turno as t on p.intIdUsuario = t.intIdDoctor AND YEAR(t.datFechaTurno) =" + info.Ano + "AND MONTH(t.datFechaTurno) = " + info.Mes +
                "inner join dbo.Asistencia as a on a.intIdTurno = t.intIdTurno" +
                "inner join dbo.Afiliado as afi on afi.intIdUsuario = u.intIdUsuario" +
                "where a.bitAsistencia = 1 AND afi.intCodigoPlan =" + info.Plan +
                "group by u.intIdUsuario, e.varDescripcion " +
                "order by atendidos desc;";


            this.Command = new SqlCommand(query, this.Connector);

            SqlDataReader resultado = Command.ExecuteReader();


            while (resultado.Read())
            {
                vRetorno.Add(resultado["descripcion"].ToString());
            }


            this.Connector.Close();

            return vRetorno;
        }


        //linea de recordatorio para que rompa, preguntar grupo familiar;    

        //public List<Usuario> getAfiliadosQueCompraronMasBonos(InfoParaListado info)
        //{
        //    List<Usuario> vRetorno = new List<Usuario>();
        //    this.Connector.Open();

        //    String query = "select top 5 u.varNombre as nombre, u.varApellido as apellido, e.varDescripcion as descripcion, count(t.bitEstado) as atendidos" +
        //        "from dbo.Especialidad as e inner join dbo.ProfesionalXEspecialidad as pxe on e.intEspecialidadCodigo = pxe.intEspecialidadCodigo " +
        //        "inner join dbo.Profesional as p on p.intIdUsuario = pxe.intIdUsuario " +
        //        "inner join dbo.Usuario as u on p.intIdUsuario = u.intIdUsuario" +
        //        "inner join dbo.Turno as t on p.intIdUsuario = t.intIdDoctor AND YEAR(t.datFechaTurno) =" + info.Ano + "AND MONTH(t.datFechaTurno) = " + info.Mes +
        //        "inner join dbo.Asistencia as a on a.intIdTurno = t.intIdTurno" +
        //        "inner join dbo.Afiliado as afi on afi.intIdUsuario = u.intIdUsuario" +
        //        "where a.bitAsistencia = 1 AND afi.intCodigoPlan =" + info.Plan +
        //        "group by u.intIdUsuario, e.varDescripcion " +
        //        "order by atendidos desc;";


        //    this.Command = new SqlCommand(query, this.Connector);

        //    SqlDataReader resultado = Command.ExecuteReader();


        //    while (resultado.Read())
        //    {
        //        vRetorno.Add(resultado["descripcion"].ToString());
        //    }


        //    this.Connector.Close();

        //    return vRetorno;
        //}



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
