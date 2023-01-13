using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using ProLobbyCompanyProject.Model.Twitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.MoneyTracking
{
    public class DSMoneyTrackingMoneyUpdate
    {
        public DSMoneyTrackingMoneyUpdate() { }
        public void UpdateUserMoney(object newData, System.Data.SqlClient.SqlCommand command)
        {
            if (newData is MATwitter)
            {
                MATwitter TwitterMoney = (MATwitter)newData;
                command.Parameters.AddWithValue("@MoneyTracking_Id", TwitterMoney.MoneyTracking_Id);
                command.Parameters.AddWithValue("@Accumulated_money", TwitterMoney.Accumulated_money);
            }
            int rows = command.ExecuteNonQuery();
        }

        string insertUpdate = "if exists (select * from [dbo].[TBMoneyTrackings] where [MoneyTracking_Id] = @MoneyTracking_Id and [Active] = 1 )\r\n   begin\r\n     update [dbo].[TBMoneyTrackings] set [Accumulated_money] = @Accumulated_money\r\n     where [MoneyTracking_Id] = @MoneyTracking_Id and [Active] = 1\r\n   end";

        public void UpdateMoneyTracking(MATwitter UserTwitterMoney, double UserMoney)
        {
            SqlQueryPost sqlQuery = new SqlQueryPost();
            UserTwitterMoney.Accumulated_money = UserTwitterMoney.Accumulated_money + UserMoney;
            sqlQuery.RunAddUser(insertUpdate, UpdateUserMoney, UserTwitterMoney);
        }
    }
}
