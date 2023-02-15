using System;
using System.Data.SqlClient;
using Utilities.Logger;

//SqlQueryClasses\SqlQuery.cs
//Implements the SQL query class
namespace ProLobbyCompanyProject.Dal
{
    public class SqlQuery
    {
        /// <summary>   The open connection. </summary>
        OpenConnection openConnection = new OpenConnection();


        /// <param name="reader">   The reader. </param>
        /// <param name="command">  The command. </param>
        /// <param name="userID">   Identifier for the user. </param>

        /// <returns>   An object. </returns>

        public delegate object SetDataReader_delegate(SqlDataReader reader, SqlCommand command, string userID);


        /// <param name="command">  The command. </param>
        /// <param name="key">      The key. </param>
        /// <param name="userID">   Identifier for the user. </param>
        /// <param name="key2">     The second key. </param>
        /// <param name="value">    The value. </param>

        public delegate void SetValues_delegate(SqlCommand command, string key, string userID, string key2, string value);


        /// <param name="sqlQuerey">    The SQL querey. </param>
        /// <param name="func">         The function. </param>
        /// <param name="setValues">    The set values. </param>
        /// <param name="key">          The key. </param>
        /// <param name="userID">       Identifier for the user. </param>
        /// <param name="key2">         The second key. </param>
        /// <param name="value">        The value. </param>
        /// <returns>   An object. </returns>
        public object RunCommand(string sqlQuerey, SetDataReader_delegate func, SetValues_delegate setValues, string key, string userID, string key2, string value)
        {
            try
            {
                if (!(openConnection.Connect())) return null;
            }
            catch (SqlException)
            {

                throw;
            }
            catch (Exception)
            {

                throw;
            }
            object userList = null;

            string insert = sqlQuerey;

            try
            {
                using (SqlCommand command = new SqlCommand(insert, openConnection.connection))
                {
                    setValues(command, key, userID, key2, value);

                    using (SqlDataReader reader = command.ExecuteReader()) userList = func(reader, command, userID);
                }
            }
            catch (SqlException)
            {

                throw;
            }
            catch (Exception)
            {

               throw;
            }


            try
            {
                if (!(openConnection.CloseConnect())) return null;

            }
            catch (SqlException)
            {

                throw;
            }
            catch (Exception)
            {

                throw;
            }

            return userList;
        }
    }
}
