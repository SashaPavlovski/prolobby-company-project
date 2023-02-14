using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model.Twitter;
using System;
using System.Data.SqlClient;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql.MoneyTracking
{
    public class DSMoneyTrackingMoneyUpdate: BaseDataSql
    {
        SqlQueryPost sqlQuery;

        public DSMoneyTrackingMoneyUpdate(Logger Logger) : base(Logger)
        {
            sqlQuery = new SqlQueryPost();
        }


        /// <summary>
        /// Updating the money in the money tracking table
        /// </summary>
        /// <param name="newData"> User information. </param>
        /// <param name="command"> sql connection. </param>
        public void UpdateUserMoney(object newData, SqlCommand command)
        {
            Logger.LogEvent("Enter into UpdateUserMoney function");

            if (newData!= null && newData is MATwitter)
            {
                Logger.LogEvent("Updating the money in the money tracking table");

                try
                {
                    MATwitter TwitterMoney = (MATwitter)newData;
                    command.Parameters.AddWithValue("@MoneyTracking_Id", TwitterMoney.MoneyTracking_Id);
                    command.Parameters.AddWithValue("@Accumulated_money", TwitterMoney.Accumulated_money);

                    int rows = command.ExecuteNonQuery();

                    Logger.LogEvent("End UpdateUserMoney function successfully");

                }
                catch (SqlException Ex) { Logger.LogException(Ex.Message, Ex); throw; }

                catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }
            }
        }


        /// <summary>
        /// sql query - update activist money 
        /// </summary>
        string insertUpdate = "if exists (select * from [dbo].[TBMoneyTrackings] where [MoneyTracking_Id] = @MoneyTracking_Id and [Active] = 1 )\r\n   begin\r\n     update [dbo].[TBMoneyTrackings] set [Accumulated_money] = @Accumulated_money\r\n     where [MoneyTracking_Id] = @MoneyTracking_Id and [Active] = 1\r\n   end";


        /// <summary>
        /// Money update of the social activist, according to the amount of tweets
        /// </summary>
        /// <param name="UserTwitterMoney"> User information. </param>
        /// <param name="UserMoney"> The money earned on the tweets. </param>
        public void UpdateMoneyTracking(MATwitter UserTwitterMoney, double UserMoney)
        {
            Logger.LogEvent("\n\nEnter into UpdateMoneyTracking function");

            try
            {
                UserTwitterMoney.Accumulated_money = UserTwitterMoney.Accumulated_money + UserMoney;
                sqlQuery.RunAddUser(insertUpdate, UpdateUserMoney, UserTwitterMoney);

                Logger.LogEvent("End UpdateMoneyTracking function");

            }
            catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }
        }
    }
}
