using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System.Data.SqlClient;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql
{

    public class DSNonProfitOrganizationsPost: BaseDataSql
    {
        SqlQueryPost sqlQuery = new SqlQueryPost();
        public DSNonProfitOrganizationsPost(Logger Logger) : base(Logger)
        {
            sqlQuery = new SqlQueryPost();
        }

        //Entering data of the organization representative
        public void AddUserData(object userData, System.Data.SqlClient.SqlCommand command)
        {
            Logger.LogEvent("Enter into AddUserData function");

            if (userData is TBNonProfitOrganization)
            {
                Logger.LogEvent("Entering data of the organization representative");

                try
                {
                    TBNonProfitOrganization nonProfitOrganization = (TBNonProfitOrganization)userData;

                    command.Parameters.AddWithValue("@NonProfitOrganizationName", nonProfitOrganization.NonProfitOrganizationName);
                    command.Parameters.AddWithValue("@Url", nonProfitOrganization.Url);
                    command.Parameters.AddWithValue("@decreption", nonProfitOrganization.decreption);
                    command.Parameters.AddWithValue("@Email", nonProfitOrganization.Email);
                    command.Parameters.AddWithValue("@RepresentativeFirstName", nonProfitOrganization.RepresentativeFirstName);
                    command.Parameters.AddWithValue("@RepresentativeLastName", nonProfitOrganization.RepresentativeLastName);
                    command.Parameters.AddWithValue("@Phone_number", nonProfitOrganization.Phone_number);
                    command.Parameters.AddWithValue("@User_Id", nonProfitOrganization.User_Id);

                    int rows = command.ExecuteNonQuery();

                    Logger.LogEvent("End AddUserData function successfully");

                }
                catch (SqlException EX)
                {

                    throw;
                }
                catch (System.Exception EX)
                {

                    throw;
                }
            }
        }

        /// <summary>   The insert. </summary>
        string insert = "insert into [dbo].[TBNonProfitOrganizations] ([NonProfitOrganizationName],[Url],[decreption],[Email],[RepresentativeFirstName],[RepresentativeLastName],[Phone_number],[User_Id],[Date])\r\nvalues (@NonProfitOrganizationName,@Url,@decreption,@Email,@RepresentativeFirstName,\r\n@RepresentativeLastName,@Phone_number,@User_Id,getdate())";

        //Entering data of the organization representative
        //Sending to dal file
        public void PostUsersData(TBNonProfitOrganization userNonProfitOrganization)
        {
            Logger.LogEvent("Enter into PostUsersData function");

            try
            {
                sqlQuery.RunAddUser(insert, AddUserData, userNonProfitOrganization);

                Logger.LogEvent("End PostUsersData function successfully");

            }
            catch (System.Exception EX)
            {

                throw;
            }
        }
    }
}
