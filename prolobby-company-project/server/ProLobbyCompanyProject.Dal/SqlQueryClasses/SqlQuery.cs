﻿


using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//SqlQueryClasses\SqlQuery.cs
//Implements the SQL query class
namespace ProLobbyCompanyProject.Dal
{
    public class SqlQuery
    {
        /// <summary>   The open connection. </summary>
        OpenConnection openConnection = new OpenConnection();


        /// <summary>   Creates the tables. </summary>
        public void CreateTables()
        {
            ConnectionWithSql._ConnectionWithSql.CreateTables();
        }


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
            if (!(openConnection.Connect())) return null;
            object userList = null;

            string insert = sqlQuerey;


            using (SqlCommand command = new SqlCommand(insert, openConnection.connection))
            {
                setValues(command, key, userID, key2, value);

                using (SqlDataReader reader = command.ExecuteReader()) userList = func(reader, command, userID);
            }
            if (!(openConnection.CloseConnect())) return null;
            return userList;
        }

    }
}
