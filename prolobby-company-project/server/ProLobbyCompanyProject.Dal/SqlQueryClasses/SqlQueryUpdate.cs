

using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        /// <summary>   Creates the tables. </summary>
        public void CreateTables()
        {
            ConnectionWithSql._ConnectionWithSql.CreateTables();
        }


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
            if (!openConnection.Connect()) return;
            string insert = sqlQuerey;

            using (SqlCommand command = new SqlCommand(insert, openConnection.connection))
            {
                func(command, updateData);

            }
            if (!(openConnection.CloseConnect())) return;

        }
    }
}
