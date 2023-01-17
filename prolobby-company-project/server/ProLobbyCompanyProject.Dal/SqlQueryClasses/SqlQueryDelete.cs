
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//SqlQueryClasses\SqlQueryDelete.cs
//Implements the SQL query delete class
// <summary>   A SQL query delete. </summary>
namespace ProLobbyCompanyProject.Dal.SqlQueryClasses
{
    public class SqlQueryDelete
    {

        // <summary>   Default constructor. </summary>
        public SqlQueryDelete() { }
        /// <summary>   The open connection. </summary>
        OpenConnection openConnection = new OpenConnection();


        // <summary>   Creates the tables. </summary>
        public void CreateTables()
        {
            ConnectionWithSql._ConnectionWithSql.CreateTables();
        }


        // <summary>   Function delegate. </summary>
        /// <param name="command">      The command. </param>
        /// <param name="UpdateData">   Information describing the update. </param>
        public delegate void func_delegate(SqlCommand command, string UpdateData);


        /// <summary>   Executes the data operation. </summary>
        /// <param name="sqlQuerey">    The SQL querey. </param>
        /// <param name="selector">     The selector. </param>
        /// <param name="func">         The function. </param>
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