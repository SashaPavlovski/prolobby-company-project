using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Dal.SqlQueryClasses
{
    public class SqlQueryUpdate
    {
        public SqlQueryUpdate() { }
        OpenConnection openConnection = new OpenConnection();

        public void CreateTables()
        {
            ConnectionWithSql._ConnectionWithSql.CreateTables();
        }

        public delegate void UpdateUser_delegate(SqlCommand command, object UpdateData);
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
