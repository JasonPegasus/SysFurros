using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using Microsoft.Data.SqlClient;
using Shared;

namespace DataAccess.Session.DTOs
{
    public class DT_Persona : ConnectedObject
    {
        public int ID            { get; private set; }
        public string Nombres    { get; private set; }
        public string Apellidos  { get; private set; }
        public int DNI           { get; private set; }
        public string Telefono   { get; private set; }
        public int Direccion     { get; private set; }
        public string Imagen_URL { get; private set; }
        public int Legajo        { get; private set; }
        public bool Activo       { get; private set; }

        static readonly string createProcedure = "RegisterPersona";
        static readonly string getDataProcedure = "GetPersonaData";


        public DT_Persona(string nombres, string apellidos, int dni, string telefono, int direccion, string imagen, int legajo)
        {
            SqlParameter idParam = new SqlParameter
            {
                ParameterName = "@PersonaID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            SqlParameter[] sqlParameters = {
                new SqlParameter { ParameterName = "@Nombres",   SqlDbType = SqlDbType.NVarChar, Value = nombres },
                new SqlParameter { ParameterName = "@Apellidos", SqlDbType = SqlDbType.NVarChar, Value = apellidos },
                new SqlParameter { ParameterName = "@DNI",       SqlDbType = SqlDbType.Int,      Value = dni },
                new SqlParameter { ParameterName = "@Telefono",  SqlDbType = SqlDbType.VarChar,  Value = telefono },
                new SqlParameter { ParameterName = "@Img",       SqlDbType = SqlDbType.NVarChar, Value = imagen },
                new SqlParameter { ParameterName = "@Legajo",    SqlDbType = SqlDbType.Int,      Value = legajo },

                new SqlParameter { ParameterName = "@Provincia",  SqlDbType = SqlDbType.Int,      Value = 1 },
                new SqlParameter { ParameterName = "@Ciudad",    SqlDbType = SqlDbType.Int,      Value = 1 },
                new SqlParameter { ParameterName = "@Calle",     SqlDbType = SqlDbType.NVarChar, Value = "TEST" },
                new SqlParameter { ParameterName = "@Altura",    SqlDbType = SqlDbType.Int,      Value = 35 },
                new SqlParameter { ParameterName = "@PD",        SqlDbType = SqlDbType.VarChar,  Value = "TT" },
                idParam,
            };

            int? returned = Convert.ToInt32(RunProcedure(createProcedure, sqlParameters, QueryType.Write));
            if (returned != null && returned > 0)
            {
                DevHelper.Print($"Added Person to ID {Convert.ToInt32(idParam.Value)}");
                ID = Convert.ToInt32(idParam.Value);
                UpdateData();
            }
        }

        public DT_Persona(int id)
        {
            this.ID = id;
            UpdateData();
            DevHelper.Print(this.DNI.ToString());
        }

        public DT_Persona UpdateData()
        {
            SqlParameter[] sqlParameters = {
                new SqlParameter
                {
                    ParameterName = "@ID",
                    SqlDbType = SqlDbType.Int,
                    Value = ID,
                    Direction = ParameterDirection.Input,
                },
                new SqlParameter
                {
                    ParameterName = "@AllowInactives",
                    SqlDbType = SqlDbType.Bit,
                    Value = true,
                    Direction = ParameterDirection.Input,
                },
            };
            if (RunProcedure(getDataProcedure, sqlParameters) is DataTable dt)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    ID = Convert.ToInt32(row["ID"]);
                    Nombres = Convert.ToString(row["Nombres"])!;
                    Apellidos = Convert.ToString(row["Apellidos"])!;
                    DNI = Convert.ToInt32(row["DNI"]);
                    Telefono = Convert.ToString(row["Telefono"])!;
                    Direccion = Convert.ToInt32(row["Direccion"]);
                    Imagen_URL = Convert.ToString(row["Imagen_URL"])!;
                    Legajo = Convert.ToInt32(row["Legajo"]);
                    Activo = Convert.ToBoolean(row["Activo"]);
                }
                else { DevHelper.Print($"Updating data in Person ID {this.ID} - Row count below 0", DevHelper.PrintType.Error); }
            }
            else { DevHelper.Print($"Updating data in Person ID {this.ID} - Returned Null Object", DevHelper.PrintType.Error); }
            return this;
        }
    }
}
