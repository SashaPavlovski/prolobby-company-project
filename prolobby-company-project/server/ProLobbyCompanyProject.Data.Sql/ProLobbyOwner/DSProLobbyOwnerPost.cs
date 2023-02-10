using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System.Data.SqlClient;
using Utilities.Logger;

// file:ProLobbyOwner\DSProLobbyOwnerPost.cs
// summary:	Implements the ds pro lobby owner post class

namespace ProLobbyCompanyProject.Data.Sql.ProLobbyOwner
{
    /// <summary> post new data of prolobby owner. </summary>
    public class DSProLobbyOwnerPost: BaseDataSql
    {
        SqlQueryPost sqlQuery;
        public DSProLobbyOwnerPost(Logger Logger) : base(Logger)
        {
            sqlQuery = new SqlQueryPost();
        }

        /// <summary>
        /// Entering proLobby owner data.
        /// </summary>
        /// <param name="userData"> The data of the owner. </param>
        /// <param name="command"> SQL connection. </param>
        public void AddUserData(object userData, System.Data.SqlClient.SqlCommand command)
        {
            Logger.LogEvent("Enter into AddUserData function");

            if (userData!= null && userData is TBProLobbyOwner)
            {
                Logger.LogEvent("Entering proLobby owner data");

                try
                {
                    TBProLobbyOwner proLobbyOwnerPost = (TBProLobbyOwner)userData;

                    command.Parameters.AddWithValue("@FirstName", proLobbyOwnerPost.FirstName);
                    command.Parameters.AddWithValue("@LastName", proLobbyOwnerPost.LastName);
                    command.Parameters.AddWithValue("@Email", proLobbyOwnerPost.Email);
                    command.Parameters.AddWithValue("@Phone_number", proLobbyOwnerPost.Phone_number);
                    command.Parameters.AddWithValue("@User_Id", proLobbyOwnerPost.User_Id);

                    int rows = command.ExecuteNonQuery();

                    Logger.LogEvent("End AddUserData function successfully");

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
        }

        /// <summary>   sql query. </summary>
        
        string insert = "insert into [dbo].[TBProLobbyOwners] values (@FirstName,@LastName,@Email,@Phone_number,@User_Id,getdate())";

        /// <summary>
        /// Entering the owner's data.
        /// </summary>
        /// <param name="userProLobbyOwnerPost"> Sending the details to dal file. </param>

        public void PostUsersData(TBProLobbyOwner userProLobbyOwnerPost)
        {
            Logger.LogEvent("Enter into PostUsersData function");

            try
            {
                sqlQuery.RunAddUser(insert, AddUserData, userProLobbyOwnerPost);

                Logger.LogEvent("End PostUsersData function successfully");

            }
            catch (System.Exception EX)
            {

                throw;
            }
        }
    }
}
