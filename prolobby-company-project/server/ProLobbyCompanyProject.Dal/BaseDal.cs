using System;
using System.Data.Entity;

namespace ProLobbyCompanyProject.Dal
{
    public class BaseDal: DbContext
    {
        public static string connectionString = Environment.GetEnvironmentVariable("connectionString");

        public BaseDal(string connectionString) : base(connectionString) { }

    }
}
