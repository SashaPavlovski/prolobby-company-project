using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using Utilities.Logger;


// file:	BusinessCompanyRepresentatives\DSBusinessCompanyRepresentativesUpdate.cs
// summary:	Implements the ds business company representatives update class
namespace ProLobbyCompanyProject.Data.Sql.BusinessCompanyRepresentatives
{
    /// <summary>   The ds business company representatives update. </summary>
    public class DSBusinessCompanyRepresentativesUpdate: BaseDataSql
    {
        /// <summary>   Default constructor. </summary>
        public DSBusinessCompanyRepresentativesUpdate(Logger Logger) : base(Logger) { }

        /// <summary>   Updates the new data. </summary>
        /// <param name="command">      The command. </param>
        /// <param name="newUserData">  Information describing the new user. </param>
        public void UpdateNewData(System.Data.SqlClient.SqlCommand command, object newUserData)
        {
            Logger.LogEvent("Enter into UpdateNewData function");

            if (command == null && (newUserData == null)) return;
            {
                if (newUserData is TBBusinessCompanyRepresentative)
                {
                    Logger.LogEvent("Updating the data of the representative business company");

                    try
                    {
                        TBBusinessCompanyRepresentative businessCompanyRepresentative = (TBBusinessCompanyRepresentative)newUserData;

                        command.Parameters.AddWithValue("@BusinessCompany_Id", businessCompanyRepresentative.BusinessCompany_Id);
                        command.Parameters.AddWithValue("@CompanyName", businessCompanyRepresentative.CompanyName);
                        command.Parameters.AddWithValue("@Url", businessCompanyRepresentative.Url);
                        command.Parameters.AddWithValue("@Email", businessCompanyRepresentative.Email);
                        command.Parameters.AddWithValue("@RepresentativeFirstName", businessCompanyRepresentative.RepresentativeFirstName);
                        command.Parameters.AddWithValue("@RepresentativeLastName", businessCompanyRepresentative.RepresentativeLastName);
                        command.Parameters.AddWithValue("@Phone_number", businessCompanyRepresentative.Phone_number);

                        int rows = command.ExecuteNonQuery();
                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                }
            }

            Logger.LogEvent("End UpdateNewData function and end of data update");
        }


        /// <summary> Update business company. </summary>
        string insertUpdate = "update  [dbo].[TBBusinessCompanyRepresentatives] set [RepresentativeFirstName]= @RepresentativeFirstName,\r\n[RepresentativeLastName]= @RepresentativeLastName, [CompanyName] = @CompanyName,\r\n[Url] = @Url,[Email] = @Email,[Phone_number] = @Phone_number\r\nwhere [BusinessCompany_Id] = @BusinessCompany_Id";

        /// <summary>   Updates the users data described by NewData. </summary>
        /// <param name="NewData">  Information describing the new. </param>
        public void UpdateUsersData(TBBusinessCompanyRepresentative NewData)
        {
            Logger.LogEvent("Enter into UpdateUsersData function");

            try
            {
                SqlQueryUpdate sqlQuery = new SqlQueryUpdate();
                sqlQuery.RunUpdateData(insertUpdate, UpdateNewData, NewData);
            }
            catch (System.Exception)
            {

                throw;
            }

            Logger.LogEvent("End UpdateUsersData function");

        }
    }
}
