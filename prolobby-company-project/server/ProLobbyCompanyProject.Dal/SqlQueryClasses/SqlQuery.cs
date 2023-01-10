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

        public object RunCommand(string sqlQuerey, SetDataReader_delegate func,string key, string userID,string key2,string value)
        {
            if (!(openConnection.Connect())) return null;
            object userList = null;

            string insert = sqlQuerey;


            using (SqlCommand command = new SqlCommand(insert, openConnection.connection))
            {
                if (key != null && userID != null && key.Contains("Campaigns_Id"))
                    command.Parameters.AddWithValue($"@{key}", int.Parse(userID));

                else if (key != null && userID != null&& key2 != null && key2.Contains("Hashtag"))
                {
                    command.Parameters.AddWithValue($"@{key}", userID);
                    command.Parameters.AddWithValue($"@{key2}", value);
                }

                else if (key != null && userID != null) command.Parameters.AddWithValue($"@{key}", userID);

                using (SqlDataReader reader = command.ExecuteReader()) userList = func(reader, command, userID);
            }
            if (!(openConnection.CloseConnect())) return null;
            return userList;
        }

    }
}
