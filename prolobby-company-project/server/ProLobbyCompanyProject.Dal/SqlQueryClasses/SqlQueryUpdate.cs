////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	SqlQueryClasses\SqlQueryUpdate.cs
//
// summary:	Implements the SQL query update class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Dal.SqlQueryClasses
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A SQL query update. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SqlQueryUpdate
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SqlQueryUpdate() { }
        /// <summary>   The open connection. </summary>
        OpenConnection openConnection = new OpenConnection();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates the tables. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void CreateTables()
        {
            ConnectionWithSql._ConnectionWithSql.CreateTables();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the user delegate. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="command">      The command. </param>
        /// <param name="UpdateData">   Information describing the update. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void UpdateUser_delegate(SqlCommand command, object UpdateData);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the update data operation. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="sqlQuerey">    The SQL querey. </param>
        /// <param name="func">         The function. </param>
        /// <param name="updateData">   Information describing the update. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
