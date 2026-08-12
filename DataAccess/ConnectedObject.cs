using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using Shared;

namespace Logic
{
    public abstract class ConnectedObject
    {
        static readonly string serverAddress = @"localhost\SQLEXPRESS";
        static readonly string dbName = "FurrosDB";
        static readonly string connString = $"Server={serverAddress};Database={dbName};Integrated Security=True;TrustServerCertificate=True;";

        private SqlConnection? MakeConnection()
        {
            try { return new SqlConnection(connString); }
            catch (Exception ex) { throw DevHelper.FormatError("Error while connecting to DataBase", ex); }
        }

        private SqlCommand? MakeCommand(SqlConnection connection, string cmdline, SqlParameter[] parameters)
        {
            try
            {
                SqlCommand cm = new SqlCommand(cmdline, connection);
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
                DevHelper.Print($"Executing Query: {query}");
                using (SqlConnection connection = MakeConnection())
                {
                    DevHelper.Print("   Connected succesfully.");
                    using (SqlCommand command = MakeCommand(connection, query, parameters))
                    {
                        DevHelper.Print("   Created command.");
                        connection.Open();
                        DevHelper.Print("   Opened connection.");

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
            catch (Exception ex) 
            { 
                DevHelper.Print(DevHelper.FormatError("Error Running Procedure", ex).Message, DevHelper.PrintType.FatalError);
                return null; 
            }
        }
    }
}