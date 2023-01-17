
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// OpenConnection.cs
// Implements the open connection class
namespace ProLobbyCompanyProject.Dal
{
    /// <summary>   An open connection. </summary>
    public class OpenConnection
    {
        /// <summary> Creating a new database </summary>
        string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProLobbyCompanyProject;Data Source=localhost\\SQLEXPRESS";

        /// <summary> The connection. </summary>
        public SqlConnection connection;

        /// <summary>   Default constructor. </summary>
        public OpenConnection()
        {
            connection = new SqlConnection(connectionString);
        }



        /// <summary>   Connects with database. </summary>
        /// <returns>   True if it succeeds, false if it fails. </returns>
        public bool Connect()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }


        /// <summary>   Closes the connect. </summary>
        /// <returns>   True if it succeeds, false if it fails. </returns>
        public bool CloseConnect()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }
    }
}
