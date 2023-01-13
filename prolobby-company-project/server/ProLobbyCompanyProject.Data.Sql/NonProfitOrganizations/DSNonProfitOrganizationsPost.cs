////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	NonProfitOrganizations\DSNonProfitOrganizationsPost.cs
//
// summary:	Implements the ds non profit organizations post class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The ds non profit organizations post. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DSNonProfitOrganizationsPost
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DSNonProfitOrganizationsPost() { }

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
            if (userData is TBNonProfitOrganization)
            {
                TBNonProfitOrganization nonProfitOrganization = (TBNonProfitOrganization)userData;

                command.Parameters.AddWithValue("@NonProfitOrganizationName", nonProfitOrganization.NonProfitOrganizationName);
                command.Parameters.AddWithValue("@Url", nonProfitOrganization.Url);
                command.Parameters.AddWithValue("@decreption", nonProfitOrganization.decreption);
                command.Parameters.AddWithValue("@Email", nonProfitOrganization.Email);
                command.Parameters.AddWithValue("@RepresentativeFirstName", nonProfitOrganization.RepresentativeFirstName);
                command.Parameters.AddWithValue("@RepresentativeLastName", nonProfitOrganization.RepresentativeLastName);
                command.Parameters.AddWithValue("@Phone_number", nonProfitOrganization.Phone_number);
                //  command.Parameters.AddWithValue("@Logo", null);
                command.Parameters.AddWithValue("@User_Id", nonProfitOrganization.User_Id);
            }
            int rows = command.ExecuteNonQuery();
        }

        /// <summary>   The insert. </summary>
        string insert = "insert into [dbo].[TBNonProfitOrganizations] ([NonProfitOrganizationName],[Url],[decreption],[Email],[RepresentativeFirstName],\r\n[RepresentativeLastName],[Phone_number],[User_Id])\r\nvalues (@NonProfitOrganizationName,@Url,@decreption,@Email,@RepresentativeFirstName,\r\n@RepresentativeLastName,@Phone_number,@User_Id)";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts the users data. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="userNonProfitOrganization">    The user non profit organization. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PostUsersData(TBNonProfitOrganization userNonProfitOrganization)
        {
            SqlQueryPost sqlQuery = new SqlQueryPost();
            sqlQuery.RunAddUser(insert, AddUserData, userNonProfitOrganization);
        }
    }
}
