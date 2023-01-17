
using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// file:	SocialActivists\DSSocialActivistsUpdate.cs
// summary:	Implements the ds social activists update class

namespace ProLobbyCompanyProject.Data.Sql.SocialActivists
{

    public class DSSocialActivistsUpdate
    {

        public DSSocialActivistsUpdate() { }

        /// <summary>   Updates the new data. </summary>
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        /// <param name="command">      The command. </param>
        /// <param name="newUserData">  Information describing the new user. </param>
        public void UpdateNewData(System.Data.SqlClient.SqlCommand command, object newUserData)
        {

            if (command == null && (newUserData == null)) return;
            {
                if (newUserData is TBSocialActivists)
                {
                    TBSocialActivists socialActivists = (TBSocialActivists)newUserData;
                    command.Parameters.AddWithValue("@SocialActivists_Id", socialActivists.SocialActivists_Id);
                    command.Parameters.AddWithValue("@FirstName", socialActivists.FirstName);
                    command.Parameters.AddWithValue("@LastName", socialActivists.LastName);
                    command.Parameters.AddWithValue("@Address", socialActivists.Address);
                    command.Parameters.AddWithValue("@Email", socialActivists.Email);
                    command.Parameters.AddWithValue("@Twitter_user", socialActivists.Twitter_user);
                    command.Parameters.AddWithValue("@Phone_number", socialActivists.Phone_number);

                }
            }
            int rows = command.ExecuteNonQuery();
        }

        /// <summary>   The social activists id]. </summary>
        string insertUpdate = "update [dbo].[TBSocialActivists] set [FirstName] = @FirstName , [LastName] = @LastName, [Address] = @Address,\r\n[Email]=@Email, [Twitter_user] = @Twitter_user,[Phone_number] = @Phone_number\r\nwhere [SocialActivists_Id] =  @SocialActivists_Id";

        /// <summary>   Updates the users data described by NewData. </summary>
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        /// <param name="NewData">  Information describing the new. </param>
        public void UpdateUsersData(TBSocialActivists NewData)
        {
            SqlQueryUpdate sqlQuery = new SqlQueryUpdate();
            sqlQuery.RunUpdateData(insertUpdate, UpdateNewData, NewData);
        }

    }
}
