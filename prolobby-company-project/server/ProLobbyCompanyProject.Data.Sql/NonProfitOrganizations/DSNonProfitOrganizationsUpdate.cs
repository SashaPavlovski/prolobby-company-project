using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System.Data.SqlClient;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql.NonProfitOrganizations
{
    public class DSNonProfitOrganizationsUpdate: BaseDataSql
    {
        SqlQueryUpdate sqlQuery;
        public DSNonProfitOrganizationsUpdate(Logger Logger) : base(Logger) 
        {
            sqlQuery = new SqlQueryUpdate();
        }

        //Updating organization representative data
        public void UpdateNewData(System.Data.SqlClient.SqlCommand command, object newUserData)
        {
            Logger.LogEvent("Enter into UpdateNewData function");

            if (command == null && (newUserData == null)) return;
            {
                if (newUserData is TBNonProfitOrganization)
                {
                    Logger.LogEvent("Entering new data of an organization representative");

                    try
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

                        int rows = command.ExecuteNonQuery();

                        Logger.LogEvent("End UpdateNewData function successfully");

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
        }


        // Update sql query 
        string insertUpdate = "update [dbo].[TBNonProfitOrganizations] set [NonProfitOrganizationName] = @NonProfitOrganizationName,[Url] = @Url,\r\n[decreption] = @decreption, [Email] = @Email,[RepresentativeFirstName] = @RepresentativeFirstName,\r\n[RepresentativeLastName] = @RepresentativeLastName,[Phone_number] = @Phone_number\r\nwhere [NonProfitOrganization_Id] = @NonProfitOrganization_Id";

        //Updating organization representative data
        //Sending the data to a Dal file 
        public void UpdateUsersData(TBNonProfitOrganization NewData)
        {
            Logger.LogEvent("Enter into UpdateUsersData function");

            try
            {
                sqlQuery.RunUpdateData(insertUpdate, UpdateNewData, NewData);

                Logger.LogEvent("End UpdateUsersData function successfully");

            }
            catch (System.Exception EX)
            {

                throw;
            }
        }
    }
}
