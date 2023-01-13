////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	SocialActivists\DSSocialActivistsPost.cs
//
// summary:	Implements the ds social activists post class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.SocialActivists
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The ds social activists post. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DSSocialActivistsPost
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DSSocialActivistsPost() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a user data to 'command'. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="userData"> Information describing the user. </param>
        /// <param name="command">  The command. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        /// <summary>   The insert. </summary>
        string insert = "insert into [dbo].[TBSocialActivists] values (@FirstName,@LastName,@Address,@Email,@Twitter_user,@Phone_number,@User_Id)";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts the users data. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="userSocialActivists">  The user social activists. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PostUsersData(TBSocialActivists userSocialActivists)
        {
            SqlQueryPost sqlQuery = new SqlQueryPost();
            sqlQuery.RunAddUser(insert, AddUserData, userSocialActivists);
        }
    }
}
