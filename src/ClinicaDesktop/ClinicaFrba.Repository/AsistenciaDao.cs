using ClinicaFrba.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Repository
{
    public class AsistenciaDao : BaseDao<Asistencia>
    {

        public void generarAsistenciaConBono(int idBono, int idTurno)
        {
            String query = "INSERT INTO [INTERNAL_SERVER_ERROR].Asistencia (intIdTurno, datFechaYHora, varBono) VALUES (@turno, GETDATE(), @bono)";
            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@turno", SqlDbType.Int).Value = idTurno;
            this.Command.Parameters.Add("@bono", SqlDbType.Int).Value = idBono;

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public void generarAsistenciaSinBono(int idTurno)
        {
            String query = "INSERT INTO [INTERNAL_SERVER_ERROR].Asistencia (intIdTurno, datFechaYHora ) VALUES (@turno, GETDATE())";
            this.Command = new SqlCommand(query, this.Connector);

            this.Command.Parameters.Add("@turno", SqlDbType.Int).Value = idTurno;     

            this.Connector.Open();
            this.Command.ExecuteNonQuery();
            this.Connector.Close();
        }

        public override void Add(Asistencia entidad)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Asistencia GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Asistencia entidad)
        {
            throw new NotImplementedException();
        }
    }
}
