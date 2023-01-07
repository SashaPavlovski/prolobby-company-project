using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.BusinessCompanyRepresentatives
{
    public class DSBusinessCompanyRepresentativesPost
    {
        public DSBusinessCompanyRepresentativesPost() { }

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

        string insert = "insert into [dbo].[TBBusinessCompanyRepresentatives] values (@RepresentativeFirstName,@RepresentativeLastName,@CompanyName,@Url,@Email,@Phone_number,@User_Id)";

        public void PostUsersData(TBBusinessCompanyRepresentative userBusinessCompanyRepresentative)
        {
            SqlQueryPost sqlQuery = new SqlQueryPost();
            sqlQuery.RunAddUser(insert, AddUserData, userBusinessCompanyRepresentative);
        }
    }
}
