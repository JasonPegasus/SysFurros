using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using Shared;

namespace Logic
{
    internal abstract class Connection
    {
        static readonly string serverAddress = "localhost";
        static readonly string dbName = "FurrosDB";
        static readonly string connString = $"Server={serverAddress};Database={dbName};Trusted_Connection=True;";

        private SqlConnection? MakeConnection()
        {
            try { return new SqlConnection(connString); }
            catch (Exception ex) { throw DevHelper.FormatError("Error while connecting to DataBase", ex); }
        }

        private SqlCommand? MakeCommand(SqlConnection connection, SqlParameter[] parameters)
        {
            try
            {
                SqlCommand cm = new SqlCommand("sp_InsertEmployee", connection);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.AddRange(parameters);
                return cm;
            }
            catch (Exception ex) { throw DevHelper.FormatError("Error while making command", ex); }
        }

        protected enum QueryType { Read, ReadSingle, Write }

        protected Object? RunProcedure(string query, SqlParameter[] parameters, QueryType queryType = QueryType.Read)
        {
            try
            {
                using (SqlConnection connection = MakeConnection())
                {
                    using (SqlCommand command = MakeCommand(connection, parameters))
                    {
                        connection.Open();

                        switch (queryType)
                        {
                            case QueryType.Read:
                                DataTable dTable = new DataTable();
                                dTable.Load(command.ExecuteReader());
                                return dTable;
                            break;
                            case QueryType.ReadSingle:
                                return command.ExecuteScalar();
                            break;
                            case QueryType.Write:
                                return command.ExecuteNonQuery();
                            break;
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex) { throw new Exception($"Error Running Procedure:\n{ex.Message}\n\n"); }
        }
    }
}