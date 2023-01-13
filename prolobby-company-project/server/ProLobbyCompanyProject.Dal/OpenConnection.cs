////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	OpenConnection.cs
//
// summary:	Implements the open connection class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Dal
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An open connection. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class OpenConnection
    {
        /// <summary>   The security. </summary>
        string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProLobbyCompanyProject;Data Source=localhost\\SQLEXPRESS";
        /// <summary>    The connection. </summary>
        public SqlConnection connection;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public OpenConnection()
        {
            connection = new SqlConnection(connectionString);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Connects this object. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Closes the connect. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
