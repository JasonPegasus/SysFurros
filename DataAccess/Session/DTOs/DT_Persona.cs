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
        public int ID            { get => (int)    VALUES["id"];         private set => VALUES["id"] =         value; }
        public string Nombres    { get => (string) VALUES["nombres"];    private set => VALUES["nombres"] =    value; }
        public string Apellidos  { get => (string) VALUES["apellidos"];  private set => VALUES["apellidos"] =  value; }
        public int DNI           { get => (int)    VALUES["dni"];        private set => VALUES["dni"] =        value; }
        public string Telefono   { get => (string) VALUES["telefono"];   private set => VALUES["telefono"] =   value; }
        public int Direccion     { get => (int)    VALUES["direccion"];  private set => VALUES["direccion"] =  value; }
        public string Imagen_URL { get => (string) VALUES["imagen_url"]; private set => VALUES["imagen_url"] = value; }
        public int Legajo        { get => (int)    VALUES["legajo"];     private set => VALUES["legajo"] =     value; }
        public bool Activo       { get => (bool)   VALUES["activo"];     private set => VALUES["activo"] =     value; }

        static readonly string createProcedure = "RegisterPersona";
        static readonly string getDataProcedure = "GetPersonaData";


        public DT_Persona(string nombres, string apellidos, int dni, string telefono, int direccion, string imagen, int legajo)
        {
            SqlParameter idParam = new SqlParameter
            {
                ParameterName = "@PersonaID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output,
                Value = -1
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

            RunProcedure(createProcedure, sqlParameters, QueryType.Write);
            if (int.TryParse(idParam.Value.ToString(), out int v) && v >= 0)
            {
                DevHelper.Print($"Added Person to ID {v}");
                ID = v;
                UpdateData();
            }
            else { DevHelper.Print($"Person Creation Output Parameter was -1, or wasn't parseable", DevHelper.PrintType.Error); }
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
