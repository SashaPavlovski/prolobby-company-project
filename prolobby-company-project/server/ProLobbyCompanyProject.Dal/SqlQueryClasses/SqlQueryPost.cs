using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Dal.SqlQueryClasses
{
    public class SqlQueryPost
    {
        public SqlQueryPost() { }

        OpenConnection openConnection = new OpenConnection();

        public void CreateTables()
        {
            ConnectionWithSql._ConnectionWithSql.CreateTables();
        }
        
        public delegate void PostData_delegate(object userData, SqlCommand command);
        public delegate int TestPostData_delegate(object userData, SqlCommand command);

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

        public int? RunAdd(string sqlQuerey, TestPostData_delegate func, object userData)
        {
            if (!(openConnection.Connect())) return null;
            int? answer = null;
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
