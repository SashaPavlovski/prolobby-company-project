using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.SocialActivists
{
    public class DSSocialActivistsPost
    {
        public DSSocialActivistsPost() { }

        public void AddUserData(object userData, System.Data.SqlClient.SqlCommand command)
        {
            if (userData is TBSocialActivists)
            {
                TBSocialActivists socialActivists = (TBSocialActivists)userData;

                command.Parameters.AddWithValue("@FirstName", socialActivists.FirstName);
                command.Parameters.AddWithValue("@LastName", socialActivists.LastName);
                command.Parameters.AddWithValue("@Address", socialActivists.Address);
                command.Parameters.AddWithValue("@Email", socialActivists.Email);
                command.Parameters.AddWithValue("@Twitter_user", socialActivists.Twitter_user);
                command.Parameters.AddWithValue("@Phone_number", socialActivists.Phone_number);
                command.Parameters.AddWithValue("@User_Id", socialActivists.User_Id);
            }
            int rows = command.ExecuteNonQuery();
        }

        string insert = "insert into [dbo].[TBSocialActivists] values (@FirstName,@LastName,@Address,@Email,@Twitter_user,@Phone_number,@User_Id)";

        public void PostUsersData(TBSocialActivists userSocialActivists)
        {
            SqlQueryPost sqlQuery = new SqlQueryPost();
            sqlQuery.RunAddUser(insert, AddUserData, userSocialActivists);
        }
    }
}
