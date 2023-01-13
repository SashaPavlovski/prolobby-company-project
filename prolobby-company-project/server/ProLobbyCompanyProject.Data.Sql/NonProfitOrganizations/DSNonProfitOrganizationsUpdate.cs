////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	NonProfitOrganizations\DSNonProfitOrganizationsUpdate.cs
//
// summary:	Implements the ds non profit organizations update class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.NonProfitOrganizations
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The ds non profit organizations update. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DSNonProfitOrganizationsUpdate
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DSNonProfitOrganizationsUpdate() { }

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
                if (newUserData is TBNonProfitOrganization)
                {
                    TBNonProfitOrganization nonProfitOrganization = (TBNonProfitOrganization)newUserData;
                    command.Parameters.AddWithValue("@NonProfitOrganization_Id", nonProfitOrganization.NonProfitOrganization_Id);
                    command.Parameters.AddWithValue("@NonProfitOrganizationName", nonProfitOrganization.NonProfitOrganizationName);
                    command.Parameters.AddWithValue("@Url", nonProfitOrganization.Url);
                    command.Parameters.AddWithValue("@decreption", nonProfitOrganization.decreption);
                    command.Parameters.AddWithValue("@Email", nonProfitOrganization.Email);
                    command.Parameters.AddWithValue("@RepresentativeFirstName", nonProfitOrganization.RepresentativeFirstName);
                    command.Parameters.AddWithValue("@RepresentativeLastName", nonProfitOrganization.RepresentativeLastName);
                    command.Parameters.AddWithValue("@Phone_number", nonProfitOrganization.Phone_number);

                }
            }
            int rows = command.ExecuteNonQuery();
        }


        /// <summary>   The non profit organization id]. </summary>
        string insertUpdate = "update [dbo].[TBNonProfitOrganizations] set [NonProfitOrganizationName] = @NonProfitOrganizationName,[Url] = @Url,\r\n[decreption] = @decreption, [Email] = @Email,[RepresentativeFirstName] = @RepresentativeFirstName,\r\n[RepresentativeLastName] = @RepresentativeLastName,[Phone_number] = @Phone_number\r\nwhere [NonProfitOrganization_Id] = @NonProfitOrganization_Id";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the users data described by NewData. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="NewData">  Information describing the new. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void UpdateUsersData(TBNonProfitOrganization NewData)
        {
            SqlQueryUpdate sqlQuery = new SqlQueryUpdate();
            sqlQuery.RunUpdateData(insertUpdate, UpdateNewData, NewData);
        }
    }
}
