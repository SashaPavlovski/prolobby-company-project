using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.BusinessCompanyRepresentatives
{
    public class DSBusinessCompanyRepresentativesUpdate
    {
        public DSBusinessCompanyRepresentativesUpdate () { }    
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


        string insertUpdate = "update  [dbo].[TBBusinessCompanyRepresentatives] set [RepresentativeFirstName]= @RepresentativeFirstName,\r\n[RepresentativeLastName]= @RepresentativeLastName, [CompanyName] = @CompanyName,\r\n[Url] = @Url,[Email] = @Email,[Phone_number] = @Phone_number\r\nwhere [BusinessCompany_Id] = @BusinessCompany_Id";


        public void UpdateUsersData(TBBusinessCompanyRepresentative NewData)
        {
            SqlQueryUpdate sqlQuery = new SqlQueryUpdate();
            sqlQuery.RunUpdateData(insertUpdate, UpdateNewData, NewData);
        }
    }
}
