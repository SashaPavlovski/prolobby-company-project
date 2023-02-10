using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using Utilities.Logger;


// file:	ProLobbyOwner\DSProLobbyOwnerGet.cs
// summary:	Implements the ds pro lobby owner get class

namespace ProLobbyCompanyProject.Data.Sql
{
    /// <summary>  Checking whether it exists prolobby owner . </summary>
    /// <summary>  If exists, receiving the details . </summary>
    public class DSProLobbyOwnerGet: BaseDataSql
    {
        SqlQuery SqlQuery;
        public DSProLobbyOwnerGet(Logger Logger) : base(Logger)
        {
            SqlQuery = new SqlQuery();
        }

        /// <summary>
        /// Adds a prolobby owner information.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="command"></param>
        /// <param name="UserId"> Identifier for the user. </param>
        /// <returns> List TBProLobbyOwner. </returns>

        public object AddProLobbyOwnerInformation(SqlDataReader reader, SqlCommand command, string UserId)
        {
            Logger.LogEvent("Enter into AddProLobbyOwnerInformation function");

            try
            {
                List<TBProLobbyOwner> proLobbyOwner = new List<TBProLobbyOwner>();

                if (reader.HasRows)
                {
                    Logger.LogEvent("Get the data of the owner if it exists");

                    while (reader.Read())
                    {
                        proLobbyOwner.Add(new TBProLobbyOwner
                        {
                            ProLobbyOwner_Id = int.Parse(reader["ProLobbyOwner_Id"].ToString()),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Phone_number = reader["Phone_number"].ToString(),
                            Email = reader["Email"].ToString()
                        });
                    }

                    Logger.LogEvent("End AddProLobbyOwnerInformation function successfully");

                    return proLobbyOwner;
                }
            }
            catch (SqlException EX)
            {

                throw;
            }
            catch (System.Exception EX)
            {

                throw;
            }

            Logger.LogEvent("End PostUsersOrganization function return null");

            return null;
        }

        public void SetValues(SqlCommand command, string key, string value, string key2, string value2)
        {
            Logger.LogEvent("Enter into SetValues function");

            Logger.LogEvent("data entry");

            try
            {
                command.Parameters.AddWithValue($"@{key}", value);

                Logger.LogEvent("End SetValues function successfully");

            }
            catch (SqlException EX)
            {

                throw;
            }
            catch (System.Exception EX)
            {

                throw;
            }
        }

        /// <summary>   sql query. </summary>
        string insertProLobbyOwner = "if exists (select  [User_Id]  from [dbo].[TBProLobbyOwners] where [User_Id] = @User_Id)\r\nbegin\r\n select ProLobbyOwner_Id,[FirstName],[LastName],[Email],[Phone_number]\r\n\t   from [dbo].[TBProLobbyOwners]\r\n\t   where [User_Id] = @User_Id\r\nend";


        /// <summary>   Gets prolobby owner user data. </summary>
        /// <param name="IdUser">   The identifier user. </param>
        /// <returns>   The pro lobby owner user data. </returns>
        public List<TBProLobbyOwner> GetProLobbyOwnerUserRow(string IdUser)
        {
            Logger.LogEvent("Enter into GetProLobbyOwnerUserRow function");

            List<TBProLobbyOwner> ProLobbyOwnerList = null;

            object listProLobbyOwner;

            try
            {
                listProLobbyOwner = SqlQuery.RunCommand(insertProLobbyOwner, AddProLobbyOwnerInformation, SetValues, "User_Id", IdUser, null, null);


                if (listProLobbyOwner != null && listProLobbyOwner is List<TBProLobbyOwner>)
                {
                    ProLobbyOwnerList = (List<TBProLobbyOwner>)listProLobbyOwner;

                    Logger.LogEvent("End GetProLobbyOwnerUserRow function, return ProLobby Owner List");


                    return ProLobbyOwnerList;

                }
            }
            catch (System.Exception EX)
            {

                throw;
            }

            Logger.LogEvent("End GetProLobbyOwnerUserRow function, return null");


            return ProLobbyOwnerList;
        }

    }
}
