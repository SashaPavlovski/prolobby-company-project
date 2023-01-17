
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//SqlQueryClasses\SqlQueryPost.cs
// Implements the SQL query post class
namespace ProLobbyCompanyProject.Dal.SqlQueryClasses
{
    /// <summary>   A SQL query post. </summary>
    public class SqlQueryPost
    {
        /// <summary>   Default constructor. </summary>
        public SqlQueryPost() { }

        /// <summary>   The open connection. </summary>
        OpenConnection openConnection = new OpenConnection();

        /// <summary>   Creates the tables. </summary>
        public void CreateTables()
        {
            ConnectionWithSql._ConnectionWithSql.CreateTables();
        }


        /// <summary>   Posts a data delegate. </summary>
        /// <param name="userData"> Information describing the user. </param>
        /// <param name="command">  The command. </param>

        public delegate void PostData_delegate(object userData, SqlCommand command);


        /// <summary>   Tests post data delegate. </summary>
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        /// <param name="userData"> Information describing the user. </param>
        /// <param name="command">  The command. </param>
        /// <returns>   An int. </returns>

        public delegate int TestPostData_delegate(object userData, SqlCommand command);


        /// <summary>   Posts a delegate. </summary>
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        /// <param name="userData"> Information describing the user. </param>
        /// <param name="command">  The command. </param>
        /// <returns>   A string. </returns>
        public delegate string Post_delegate(object userData, SqlCommand command);


        /// <summary>   Executes the add user operation. </summary>
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        /// <param name="sqlQuerey">    The SQL querey. </param>
        /// <param name="func">         The function. </param>
        /// <param name="userData">     Information describing the user. </param>
        public void RunAddUser(string sqlQuerey, PostData_delegate func, object userData)
        {
            if (!(openConnection.Connect())) return;
            string insert = sqlQuerey;
            ;
            using (SqlCommand command = new SqlCommand(insert, openConnection.connection))
            {
                func(userData, command);

            }
            if (!(openConnection.CloseConnect())) return;
        }


        /// <summary>   Executes the add operation. </summary>
        /// <param name="sqlQuerey">    The SQL querey. </param>
        /// <param name="func">         The function. </param>
        /// <param name="userData">     Information describing the user. </param>
        /// <returns>   An int? </returns>


        public int? RunAdd(string sqlQuerey, TestPostData_delegate func, object userData)
        {
            if (!(openConnection.Connect())) return null;
            int? answer = null;
            string insert = sqlQuerey;
            
            using (SqlCommand command = new SqlCommand(insert, openConnection.connection))
            {
                answer = func(userData, command);

            }
            if (!(openConnection.CloseConnect())) return null;
            return answer;
        }


        /// <summary>   Executes the add data operation. </summary>
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        /// <param name="sqlQuerey">    The SQL querey. </param>
        /// <param name="func">         The function. </param>
        /// <param name="userData">     Information describing the user. </param>
        /// <returns>   A string. </returns>


        public string RunAddData(string sqlQuerey, Post_delegate func, object userData)
        {
            if (!(openConnection.Connect())) return null;
            string answer = null;
            string insert = sqlQuerey;
            ;
            using (SqlCommand command = new SqlCommand(insert, openConnection.connection))
            {
                answer = func(userData, command);

            }
            if (!(openConnection.CloseConnect())) return null;
            return answer;
        }

    }
}
