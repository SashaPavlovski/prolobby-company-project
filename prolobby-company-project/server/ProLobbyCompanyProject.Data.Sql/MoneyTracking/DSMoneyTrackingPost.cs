using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.MoneyTracking
{
    public class DSMoneyTrackingPost
    {
        public DSMoneyTrackingPost() { }

        public void AddUserData(object newData, System.Data.SqlClient.SqlCommand command)
        {
            if (newData is TBMoneyTracking)
            {
                TBMoneyTracking moneyTracking = (TBMoneyTracking)newData;

                command.Parameters.AddWithValue("@SocialActivists_Id", moneyTracking.SocialActivists_Id);
                command.Parameters.AddWithValue("@Campaigns_Id", moneyTracking.Campaigns_Id);
                command.Parameters.AddWithValue("@Accumulated_money", moneyTracking.Accumulated_money);
                command.Parameters.AddWithValue("@Active", moneyTracking.Active);

            }
            int rows = command.ExecuteNonQuery();
        }

        string insertNewData = "if not exists (select * from [dbo].[TBMoneyTrackings] where [SocialActivists_Id] = @SocialActivists_Id  and [Campaigns_Id] = @Campaigns_Id)\r\nbegin\r\ninsert into [dbo].[TBMoneyTrackings]\r\nvalues (@SocialActivists_Id ,@Campaigns_Id ,@Accumulated_money,@Active)\r\nend";

        public void PostMoneyTracking(TBMoneyTracking moneyTracking)
        {
            SqlQueryPost sqlQuery = new SqlQueryPost();
            sqlQuery.RunAddUser(insertNewData, AddUserData, moneyTracking);
        }

    }
}
