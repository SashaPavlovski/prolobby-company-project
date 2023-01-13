////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	BusinessCompanyRepresentatives\DSBusinessCompanyRepresentativesPost.cs
//
// summary:	Implements the ds business company representatives post class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.BusinessCompanyRepresentatives
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The ds business company representatives post. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DSBusinessCompanyRepresentativesPost
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DSBusinessCompanyRepresentativesPost() { }

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
            if (userData is TBBusinessCompanyRepresentative)
            {
                TBBusinessCompanyRepresentative businessCompanyRepresentative = (TBBusinessCompanyRepresentative)userData;

                command.Parameters.AddWithValue("@CompanyName", businessCompanyRepresentative.CompanyName);
                command.Parameters.AddWithValue("@Url", businessCompanyRepresentative.Url);
                command.Parameters.AddWithValue("@Email", businessCompanyRepresentative.Email);
                command.Parameters.AddWithValue("@RepresentativeFirstName", businessCompanyRepresentative.RepresentativeFirstName);
                command.Parameters.AddWithValue("@RepresentativeLastName", businessCompanyRepresentative.RepresentativeLastName);
                command.Parameters.AddWithValue("@Phone_number", businessCompanyRepresentative.Phone_number);
                command.Parameters.AddWithValue("@User_Id", businessCompanyRepresentative.User_Id);
            }
            int rows = command.ExecuteNonQuery();
        }

        /// <summary>   The insert. </summary>
        string insert = "insert into [dbo].[TBBusinessCompanyRepresentatives] values (@RepresentativeFirstName,@RepresentativeLastName,@CompanyName,@Url,@Email,@Phone_number,@User_Id)";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts the users data. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="userBusinessCompanyRepresentative">    The user business company representative. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PostUsersData(TBBusinessCompanyRepresentative userBusinessCompanyRepresentative)
        {
            SqlQueryPost sqlQuery = new SqlQueryPost();
            sqlQuery.RunAddUser(insert, AddUserData, userBusinessCompanyRepresentative);
        }
    }
}
