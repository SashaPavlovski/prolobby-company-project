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
    public class DSNonProfitOrganizationsPost
    {
        public DSNonProfitOrganizationsPost() { }

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
        
        string insert = "insert into [dbo].[TBNonProfitOrganizations] ([NonProfitOrganizationName],[Url],[decreption],[Email],[RepresentativeFirstName],\r\n[RepresentativeLastName],[Phone_number],[User_Id])\r\nvalues (@NonProfitOrganizationName,@Url,@decreption,@Email,@RepresentativeFirstName,\r\n@RepresentativeLastName,@Phone_number,@User_Id)";

        public void PostUsersData(TBNonProfitOrganization userNonProfitOrganization)
        {
            SqlQueryPost sqlQuery = new SqlQueryPost();
            sqlQuery.RunAddUser(insert, AddUserData, userNonProfitOrganization);
        }
    }
}
