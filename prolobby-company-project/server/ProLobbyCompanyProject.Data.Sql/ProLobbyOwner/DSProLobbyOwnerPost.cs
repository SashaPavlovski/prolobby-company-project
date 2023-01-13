////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	ProLobbyOwner\DSProLobbyOwnerPost.cs
//
// summary:	Implements the ds pro lobby owner post class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.ProLobbyOwner
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The ds pro lobby owner post. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DSProLobbyOwnerPost
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DSProLobbyOwnerPost() { }

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

        /// <summary>   The insert. </summary>
        string insert = "insert into [dbo].[TBProLobbyOwners] values (@FirstName,@LastName,@Email,@Phone_number,@User_Id)";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts the users data. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="userProLobbyOwnerPost">    The user pro lobby owner post. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PostUsersData(TBProLobbyOwner userProLobbyOwnerPost)
        {
            SqlQueryPost sqlQuery = new SqlQueryPost();
            sqlQuery.RunAddUser(insert, AddUserData, userProLobbyOwnerPost);
        }
    }
}
