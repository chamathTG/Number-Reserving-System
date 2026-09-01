using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Text;

namespace Number_Reserving_System.Database
{
    internal class DataBase
    {
        private readonly string connectionString;

        public DataBase()
        {
            connectionString = ConfigurationManager
                .ConnectionStrings["dbConnection"]
                .ConnectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
