////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	BusinessCompanyRepresentatives\DSBusinessCompanyRepresentativesUpdate.cs
//
// summary:	Implements the ds business company representatives update class
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
    /// <summary>   The ds business company representatives update. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DSBusinessCompanyRepresentativesUpdate
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DSBusinessCompanyRepresentativesUpdate() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the new data. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="command">      The command. </param>
        /// <param name="newUserData">  Information describing the new user. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void UpdateNewData(System.Data.SqlClient.SqlCommand command, object newUserData)
        {

            if (command == null && (newUserData == null)) return;
            {
                if (newUserData is TBBusinessCompanyRepresentative)
                {
                    TBBusinessCompanyRepresentative businessCompanyRepresentative = (TBBusinessCompanyRepresentative)newUserData;

                    command.Parameters.AddWithValue("@BusinessCompany_Id", businessCompanyRepresentative.BusinessCompany_Id);
                    command.Parameters.AddWithValue("@CompanyName", businessCompanyRepresentative.CompanyName);
                    command.Parameters.AddWithValue("@Url", businessCompanyRepresentative.Url);
                    command.Parameters.AddWithValue("@Email", businessCompanyRepresentative.Email);
                    command.Parameters.AddWithValue("@RepresentativeFirstName", businessCompanyRepresentative.RepresentativeFirstName);
                    command.Parameters.AddWithValue("@RepresentativeLastName", businessCompanyRepresentative.RepresentativeLastName);
                    command.Parameters.AddWithValue("@Phone_number", businessCompanyRepresentative.Phone_number);


                }
            }
            int rows = command.ExecuteNonQuery();
        }


        /// <summary>   The business company id]. </summary>
        string insertUpdate = "update  [dbo].[TBBusinessCompanyRepresentatives] set [RepresentativeFirstName]= @RepresentativeFirstName,\r\n[RepresentativeLastName]= @RepresentativeLastName, [CompanyName] = @CompanyName,\r\n[Url] = @Url,[Email] = @Email,[Phone_number] = @Phone_number\r\nwhere [BusinessCompany_Id] = @BusinessCompany_Id";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the users data described by NewData. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="NewData">  Information describing the new. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void UpdateUsersData(TBBusinessCompanyRepresentative NewData)
        {
            SqlQueryUpdate sqlQuery = new SqlQueryUpdate();
            sqlQuery.RunUpdateData(insertUpdate, UpdateNewData, NewData);
        }
    }
}
