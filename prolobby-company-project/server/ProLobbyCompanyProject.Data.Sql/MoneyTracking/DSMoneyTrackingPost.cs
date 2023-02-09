using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using Utilities.Logger;

// file:	MoneyTracking\DSMoneyTrackingPost.cs
// summary:	Implements the ds money tracking post class

namespace ProLobbyCompanyProject.Data.Sql.MoneyTracking
{
    /// <summary> money tracking post. </summary>
    public class DSMoneyTrackingPost: BaseDataSql
    {
        SqlQueryPost SqlQuery;

        /// <summary>   Default constructor. </summary>
        public DSMoneyTrackingPost(Logger Logger) : base(Logger)
        {
            SqlQuery = new SqlQueryPost();
        }
        // Entering the details of moneyTracking
        public void AddUserData(object newData, System.Data.SqlClient.SqlCommand command)
        {
            Logger.LogEvent("Enter into AddUserData function");

            Logger.LogEvent("Entering financial data");

            if (newData is TBMoneyTracking)
            {
                Logger.LogEvent("Entering financial data");

                try
                {
                    TBMoneyTracking moneyTracking = (TBMoneyTracking)newData;

                    command.Parameters.AddWithValue("@SocialActivists_Id", moneyTracking.SocialActivists_Id);
                    command.Parameters.AddWithValue("@Campaigns_Id", moneyTracking.Campaigns_Id);

                    int rows = command.ExecuteNonQuery();

                    Logger.LogEvent("End AddUserData function successfully");

                }
                catch (Exception EX)
                {

                    throw;
                }
            }

            Logger.LogError("End AddUserData function, invalid value was received");

        }



        /// <summary>   Information describing the insert new. </summary>
        string insertNewData = "if not exists (select * from [dbo].[TBMoneyTrackings] where [SocialActivists_Id] = @SocialActivists_Id  and [Campaigns_Id] = @Campaigns_Id)\r\nbegin\r\ninsert into [dbo].[TBMoneyTrackings]\r\nvalues (@SocialActivists_Id ,@Campaigns_Id ,0,1,getdate())\r\nend";

        public void PostMoneyTracking(TBMoneyTracking moneyTracking)
        {
            Logger.LogEvent("Enter into PostMoneyTracking function");

            try
            {
                SqlQuery.RunAddUser(insertNewData, AddUserData, moneyTracking);

                Logger.LogEvent("End PostMoneyTracking function Successfully");

            }
            catch (Exception EX)
            {

                throw;
            }
        }
    }
}
