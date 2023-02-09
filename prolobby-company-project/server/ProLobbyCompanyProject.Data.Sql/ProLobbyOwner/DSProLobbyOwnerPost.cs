using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using Utilities.Logger;
// file:ProLobbyOwner\DSProLobbyOwnerPost.cs
// summary:	Implements the ds pro lobby owner post class

namespace ProLobbyCompanyProject.Data.Sql.ProLobbyOwner
{
    /// <summary> post new data of prolobby owner. </summary>
    public class DSProLobbyOwnerPost: BaseDataSql
    {
        /// <summary>   Default constructor. </summary>
        public DSProLobbyOwnerPost(Logger Logger) : base(Logger) { }

        //Entering new data
        public void AddUserData(object userData, System.Data.SqlClient.SqlCommand command)
        {
            if (userData is TBProLobbyOwner)
            {
                try
                {
                    TBProLobbyOwner proLobbyOwnerPost = (TBProLobbyOwner)userData;

                    command.Parameters.AddWithValue("@FirstName", proLobbyOwnerPost.FirstName);
                    command.Parameters.AddWithValue("@LastName", proLobbyOwnerPost.LastName);
                    command.Parameters.AddWithValue("@Email", proLobbyOwnerPost.Email);
                    command.Parameters.AddWithValue("@Phone_number", proLobbyOwnerPost.Phone_number);
                    command.Parameters.AddWithValue("@User_Id", proLobbyOwnerPost.User_Id);
                    int rows = command.ExecuteNonQuery();
                }
                catch (System.Exception EX)
                {

                    throw;
                }
            }
        }

        /// <summary>   The insert. </summary>
        string insert = "insert into [dbo].[TBProLobbyOwners] values (@FirstName,@LastName,@Email,@Phone_number,@User_Id,getdate())";
        //Sending the details to dal
        public void PostUsersData(TBProLobbyOwner userProLobbyOwnerPost)
        {
            try
            {
                SqlQueryPost sqlQuery = new SqlQueryPost();
                sqlQuery.RunAddUser(insert, AddUserData, userProLobbyOwnerPost);
            }
            catch (System.Exception EX)
            {

                throw;
            }
        }
    }
}
