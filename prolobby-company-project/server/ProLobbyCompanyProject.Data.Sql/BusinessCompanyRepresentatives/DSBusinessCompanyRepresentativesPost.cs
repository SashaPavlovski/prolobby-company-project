
using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// file:	BusinessCompanyRepresentatives\DSBusinessCompanyRepresentativesPost.cs

// summary:	Implements the ds business company representatives post class

namespace ProLobbyCompanyProject.Data.Sql.BusinessCompanyRepresentatives
{
    /// <summary>   The business company representatives post login new data . </summary>
    public class DSBusinessCompanyRepresentativesPost
    {

        /// <summary>   Default constructor. </summary>
        public DSBusinessCompanyRepresentativesPost() { }

        /// <summary>   Adds a user data to DB. </summary>
        /// <param name="userData"> Information describing the user. </param>
        /// <param name="command">  The command. </param>
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

        /// <summary>   The insert data of company. </summary>
        string insert = "insert into [dbo].[TBBusinessCompanyRepresentatives] values (@RepresentativeFirstName,@RepresentativeLastName,@CompanyName,@Url,@Email,@Phone_number,@User_Id,getdate())";

        /// <summary>   Posts the users data. </summary>
        /// <param name="userBusinessCompanyRepresentative">    The user business company new data. </param>
        public void PostUsersData(TBBusinessCompanyRepresentative userBusinessCompanyRepresentative)
        {
            SqlQueryPost sqlQuery = new SqlQueryPost();
            sqlQuery.RunAddUser(insert, AddUserData, userBusinessCompanyRepresentative);
        }
    }
}
