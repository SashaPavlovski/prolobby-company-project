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
        string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProLobbyCompanyProject;Data Source=localhost\\SQLEXPRESS";
        SqlConnection connection;
        public SqlQuery()
        {
            connection = new SqlConnection(connectionString);
        }

        public bool Connect()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        public void CreateTables()
        {
            ConnectionWithSql._ConnectionWithSql.CreateTables();
        }

        public delegate object SetDataReader_delegate(SqlDataReader reader, SqlCommand command,string userID);

        public object RunCommand(string sqlQuerey, SetDataReader_delegate func, string userID)
        {
            if (!Connect()) return null;
            object userList = null;

            string insert = sqlQuerey;


            using (SqlCommand command = new SqlCommand(insert, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader()) userList = func(reader, command, userID);
            }
            return userList;
        }




















    }
}
