////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	SqlQueryClasses\SqlQueryDelete.cs
//
// summary:	Implements the SQL query delete class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Dal.SqlQueryClasses
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A SQL query delete. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SqlQueryDelete
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SqlQueryDelete() { }
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
        /// <summary>   Function delegate. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="command">      The command. </param>
        /// <param name="UpdateData">   Information describing the update. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void func_delegate(SqlCommand command, string UpdateData);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the data operation. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="sqlQuerey">    The SQL querey. </param>
        /// <param name="selector">     The selector. </param>
        /// <param name="func">         The function. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void RunData(string sqlQuerey, string selector, func_delegate func)
        {
            if (!openConnection.Connect()) return;
            string insert = sqlQuerey;

            using (SqlCommand command = new SqlCommand(insert, openConnection.connection))
            {
                func(command, selector);
            }
            if (!(openConnection.CloseConnect())) return;

        }
    }
}