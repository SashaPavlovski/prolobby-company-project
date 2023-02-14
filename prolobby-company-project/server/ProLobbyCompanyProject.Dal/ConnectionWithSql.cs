using System;
using System.Linq;

// ConnectionWithSql.cs
// Implements the connection with SQL class
namespace ProLobbyCompanyProject.Dal
{
    /// <summary>   A connection with sql. </summary>
    public class ConnectionWithSql
    {
        /// <summary>   Default constructor. </summary>
        public ConnectionWithSql() { }

        /// <summary>   The connection with SQL. </summary>
        private readonly static ConnectionWithSql connectionWithSql = new ConnectionWithSql();


        /// <summary>   Gets the connection with SQL. </summary>
        /// <value> The connection with SQL. </value>
        public static ConnectionWithSql _ConnectionWithSql
        {
            get { return connectionWithSql; }
        }


        /// <summary>   Creates the tables. </summary>
        public void CreateTables()
        {
            //Logger.LogEvent("Enter into Init function");

            try
            {
                CreateSqlTables.Data.ProLobbyOwner.ToList();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                Console.WriteLine(Ex.StackTrace);
                throw;
            }
        }
    }
}
