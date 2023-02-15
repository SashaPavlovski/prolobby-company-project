using System.Data.SqlClient;

// OpenConnection.cs
// Implements the open connection class
namespace ProLobbyCompanyProject.Dal
{
    /// <summary>   An open connection. </summary>
    public class OpenConnection: BaseDal
    {
        /// <summary> Creating a new database </summary>
      //  public static string connectionString = Environment.GetEnvironmentVariable("connectionString");

        /// <summary> The connection. </summary>
        public SqlConnection connection;

        /// <summary>   Default constructor. </summary>
        public OpenConnection():base(connectionString)
        {
            try
            {
                connection = new SqlConnection(connectionString);
            }
            catch (SqlException)
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
            catch (SqlException)
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
            catch (SqlException)
            {
                return false;
            }
        }
    }
}
