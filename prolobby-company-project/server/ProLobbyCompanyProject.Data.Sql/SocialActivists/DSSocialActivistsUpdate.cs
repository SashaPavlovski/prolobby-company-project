using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using Utilities.Logger;


// file:	SocialActivists\DSSocialActivistsUpdate.cs
// summary:	Implements the ds social activists update class

namespace ProLobbyCompanyProject.Data.Sql.SocialActivists
{
    public class DSSocialActivistsUpdate: BaseDataSql
    {
        SqlQueryUpdate sqlQuery;
        public DSSocialActivistsUpdate(Logger Logger) : base(Logger)
        {
            sqlQuery = new SqlQueryUpdate();
        }

        /// <summary>   Updates the new data. </summary>
        /// <param name="command">      The command. </param>
        /// <param name="newUserData">  Information describing the new user. </param>
        public void UpdateNewData(System.Data.SqlClient.SqlCommand command, object newUserData)
        {
            Logger.LogEvent("Enter into UpdateNewData function");

            Logger.LogEvent("Update the details of the social operator");

            if (command == null && (newUserData == null)) return;
            {
                if (newUserData is TBSocialActivists)
                {
                    try
                    {
                        TBSocialActivists socialActivists = (TBSocialActivists)newUserData;
                        command.Parameters.AddWithValue("@SocialActivists_Id", socialActivists.SocialActivists_Id);
                        command.Parameters.AddWithValue("@FirstName", socialActivists.FirstName);
                        command.Parameters.AddWithValue("@LastName", socialActivists.LastName);
                        command.Parameters.AddWithValue("@Address", socialActivists.Address);
                        command.Parameters.AddWithValue("@Email", socialActivists.Email);
                        command.Parameters.AddWithValue("@Twitter_user", socialActivists.Twitter_user);
                        command.Parameters.AddWithValue("@Phone_number", socialActivists.Phone_number);

                        int rows = command.ExecuteNonQuery();

                        Logger.LogEvent("The operation was performed successfully");

                    }
                    catch (System.Exception EX)
                    {

                        throw;
                    }
                }
            }

            Logger.LogEvent("End UpdateNewData function");

        }

        /// <summary>   The social activists id]. </summary>
        string insertUpdate = "update [dbo].[TBSocialActivists] set [FirstName] = @FirstName , [LastName] = @LastName, [Address] = @Address,\r\n[Email]=@Email, [Twitter_user] = @Twitter_user,[Phone_number] = @Phone_number\r\nwhere [SocialActivists_Id] =  @SocialActivists_Id";

        /// <summary>   Updates the users data described by NewData. </summary>
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        /// <param name="NewData">  Information describing the new. </param>
        public void UpdateUsersData(TBSocialActivists NewData)
        {
            Logger.LogEvent("Enter into UpdateUsersData function");
            
            try
            {
                sqlQuery.RunUpdateData(insertUpdate, UpdateNewData, NewData);
            }
            catch (System.Exception EX)
            {

                throw;
            }
        }
    }
}
