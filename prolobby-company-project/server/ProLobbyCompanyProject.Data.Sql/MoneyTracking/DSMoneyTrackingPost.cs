
using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// file:	MoneyTracking\DSMoneyTrackingPost.cs
// summary:	Implements the ds money tracking post class

namespace ProLobbyCompanyProject.Data.Sql.MoneyTracking
{
    /// <summary> money tracking post. </summary>
    public class DSMoneyTrackingPost
    {
        /// <summary>   Default constructor. </summary>
        public DSMoneyTrackingPost() { }
        // Entering the details of moneyTracking
        public void AddUserData(object newData, System.Data.SqlClient.SqlCommand command)
        {
            if (newData is TBMoneyTracking)
            {
                TBMoneyTracking moneyTracking = (TBMoneyTracking)newData;

                command.Parameters.AddWithValue("@SocialActivists_Id", moneyTracking.SocialActivists_Id);
                command.Parameters.AddWithValue("@Campaigns_Id", moneyTracking.Campaigns_Id);

            }
            int rows = command.ExecuteNonQuery();
        }

    

        /// <summary>   Information describing the insert new. </summary>
        string insertNewData = "if not exists (select * from [dbo].[TBMoneyTrackings] where [SocialActivists_Id] = @SocialActivists_Id  and [Campaigns_Id] = @Campaigns_Id)\r\nbegin\r\ninsert into [dbo].[TBMoneyTrackings]\r\nvalues (@SocialActivists_Id ,@Campaigns_Id ,0,1,getdate())\r\nend";

        public void PostMoneyTracking(TBMoneyTracking moneyTracking)
        {
            SqlQueryPost sqlQuery = new SqlQueryPost();
            sqlQuery.RunAddUser(insertNewData, AddUserData, moneyTracking);
        }

    }
}
