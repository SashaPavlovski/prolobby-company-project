using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.ProLobbyOwner
{
    public class DSProLobbyOwnerPost
    {
        public DSProLobbyOwnerPost() { }

        public void AddUserData(object userData, System.Data.SqlClient.SqlCommand command)
        {
            if (userData is TBProLobbyOwner)
            {
                TBProLobbyOwner proLobbyOwnerPost = (TBProLobbyOwner)userData;

                command.Parameters.AddWithValue("@FirstName", proLobbyOwnerPost.FirstName);
                command.Parameters.AddWithValue("@LastName", proLobbyOwnerPost.LastName);
                command.Parameters.AddWithValue("@Email", proLobbyOwnerPost.Email);
                command.Parameters.AddWithValue("@Phone_number", proLobbyOwnerPost.Phone_number);
                command.Parameters.AddWithValue("@User_Id", proLobbyOwnerPost.User_Id);
            }
            int rows = command.ExecuteNonQuery();
        }

        string insert = "insert into [dbo].[TBProLobbyOwners] values (@FirstName,@LastName,@Email,@Phone_number,@User_Id)";

        public void PostUsersData(TBProLobbyOwner userProLobbyOwnerPost)
        {
            SqlQueryPost sqlQuery = new SqlQueryPost();
            sqlQuery.RunAddUser(insert, AddUserData, userProLobbyOwnerPost);
        }
    }
}
