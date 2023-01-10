using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Dal.SqlQueryClasses
{
    public class SqlQueryDelete
    {
        public SqlQueryDelete() { }
        OpenConnection openConnection = new OpenConnection();

        public void CreateTables()
        {
            ConnectionWithSql._ConnectionWithSql.CreateTables();
        }

        public delegate void func_delegate(SqlCommand command, string UpdateData);
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