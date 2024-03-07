using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Utilities
    {
    public class DatabaseHelper
        {
        private static string connectionString = @"Server=(localDB)\MSSQLLocalDB;Database=StudentInfoDB;Trusted_Connection=True;";
        public static IDbConnection GetConnection()
            {
            return new SqlConnection(connectionString);
            }

        }
    }
