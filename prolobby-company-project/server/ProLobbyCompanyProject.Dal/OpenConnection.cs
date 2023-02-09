using System.Configuration;
using System.Data.SqlClient;

// OpenConnection.cs
// Implements the open connection class
namespace ProLobbyCompanyProject.Dal
{
    /// <summary>   An open connection. </summary>
    public class OpenConnection
    {
        /// <summary> Creating a new database </summary>
        public static string connectionString = ConfigurationManager.AppSettings["connectionString"];
        /// <summary> The connection. </summary>
        public SqlConnection connection;

        /// <summary>   Default constructor. </summary>
        public OpenConnection()
        {
            try
            {
                connection = new SqlConnection(connectionString);

            }
            catch (SqlException EX)
            {

                throw;
            }
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
            catch (SqlException EX)
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
