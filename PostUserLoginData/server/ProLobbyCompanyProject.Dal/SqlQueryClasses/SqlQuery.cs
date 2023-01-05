using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProLobbyCompanyProject.Dal
{
    public class SqlQuery
    {
        OpenConnection openConnection =  new OpenConnection();
        public void CreateTables()
        {
            ConnectionWithSql._ConnectionWithSql.CreateTables();
        }

        public delegate object SetDataReader_delegate(SqlDataReader reader, SqlCommand command,string userID);

        public object RunCommand(string sqlQuerey, SetDataReader_delegate func, string userID)
        {
            if (!(openConnection.Connect())) return null;
            object userList = null;

            string insert = sqlQuerey;


            using (SqlCommand command = new SqlCommand(insert, openConnection.connection))
            {
                command.Parameters.AddWithValue("@User_Id", userID);

                using (SqlDataReader reader = command.ExecuteReader()) userList = func(reader, command, userID);
            }
            return userList;
        }

    }
}
