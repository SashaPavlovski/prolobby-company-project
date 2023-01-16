using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model.Twitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.PostsTracking
{
    public class DSPostsTrackingPost
    {
        public DSPostsTrackingPost() { }
        public void PostTracking(object newData, System.Data.SqlClient.SqlCommand command)
        {
            if (newData is MATwitter)
            {
                MATwitter TwitterMoney = (MATwitter)newData;
                command.Parameters.AddWithValue("@MoneyTracking_Id", TwitterMoney.MoneyTracking_Id);
                command.Parameters.AddWithValue("@SocialActivists_Id", TwitterMoney.SocialActivists_Id);
                command.Parameters.AddWithValue("@Amount_publications", TwitterMoney.Accumulated_money);
            }
            int rows = command.ExecuteNonQuery();
        }

        string insertPost = "declare @Campaigns_Id int\r\nif exists (select * from [dbo].[TBMoneyTrackings] where [MoneyTracking_Id] = @MoneyTracking_Id and [Active] = 1 )\r\n   begin\r\n   SET @Campaigns_Id = (select Campaigns_Id from [dbo].[TBMoneyTrackings] where [MoneyTracking_Id] = @MoneyTracking_Id\r\n   and [Active] = 1)\r\n   insert into [dbo].[TBPostsTrackings]\r\n   values ( @Campaigns_Id,@SocialActivists_Id,@Amount_publications,getdate()-1,1)\r\n   end";

        public void PostPostsTracking(MATwitter UserTwitterMoney, double UserPosts)
        {
            SqlQueryPost sqlQuery = new SqlQueryPost();
            UserTwitterMoney.Accumulated_money = UserPosts;
            sqlQuery.RunAddUser(insertPost, PostTracking, UserTwitterMoney);
        }
    }
}
