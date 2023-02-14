using System.Data.SqlClient;

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
            try
            {
                if (!openConnection.Connect()) return;
            }
            catch (SqlException SE)
            {

                throw;
            }
            catch (System.Exception Ex)
            {

                throw;
            }

            string insert = sqlQuerey;

            try
            {
                using (SqlCommand command = new SqlCommand(insert, openConnection.connection))
                {
                    func(command, selector);
                }
            }
            catch (System.Exception Ex)
            {

                throw;
            }

            try
            {
                if (!(openConnection.CloseConnect())) return;
            }
            catch (SqlException SE)
            {

                throw;
            }
            catch (System.Exception Ex)
            {

                throw;
            }

        }
    }
}