using System;
using System.Collections.Generic;
using System.Data.SqlClient;

// SqlQueryClasses\SqlQueryUpdate.cs
//Implements the SQL query update class
namespace ProLobbyCompanyProject.Dal.SqlQueryClasses
{
    /// <summary>   A SQL query update. </summary>
    public class SqlQueryUpdate
    {
        /// <summary>   Default constructor. </summary>
        public SqlQueryUpdate() { }
        /// <summary>   The open connection. </summary>
        OpenConnection openConnection = new OpenConnection();

        /// <summary>   Updates the user delegate. </summary>

        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        /// <param name="command">      The command. </param>
        /// <param name="UpdateData">   Information describing the update. </param>

        public delegate void UpdateUser_delegate(SqlCommand command, object UpdateData);



        /// <summary>   Executes the update data operation. </summary>
        /// <param name="sqlQuerey">    The SQL querey. </param>
        /// <param name="func">         The function. </param>
        /// <param name="updateData">   Information describing the update. </param>
        public void RunUpdateData(string sqlQuerey, UpdateUser_delegate func, object updateData)
        {
            try
            {
                if (!openConnection.Connect()) return;
            }
            catch (Exception EX)
            {

                throw;
            }

            string insert = sqlQuerey;

            try
            {
                using (SqlCommand command = new SqlCommand(insert, openConnection.connection))
                {
                    func(command, updateData);
                }
            }
            catch (Exception EX)
            {

                throw;
            }
            

            try
            {
                if (!(openConnection.CloseConnect())) return;
            }
            catch (Exception EX)
            {

                throw;
            }
        }
    }
}
