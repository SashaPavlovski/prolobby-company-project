using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.NonProfitOrganizations
{
    public class DSNonProfitOrganizationsUpdate
    {
        public DSNonProfitOrganizationsUpdate () { }
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


        string insertUpdate = "update [dbo].[TBNonProfitOrganizations] set [NonProfitOrganizationName] = @NonProfitOrganizationName,[Url] = @Url,\r\n[decreption] = @decreption, [Email] = @Email,[RepresentativeFirstName] = @RepresentativeFirstName,\r\n[RepresentativeLastName] = @RepresentativeLastName,[Phone_number] = @Phone_number\r\nwhere [NonProfitOrganization_Id] = @NonProfitOrganization_Id";


        public void UpdateUsersData(TBNonProfitOrganization NewData)
        {
            SqlQueryUpdate sqlQuery = new SqlQueryUpdate();
            sqlQuery.RunUpdateData(insertUpdate, UpdateNewData, NewData);
        }
    }
}
