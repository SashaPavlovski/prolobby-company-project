using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using ProLobbyCompanyProject.Model.Twitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.Twitter
{
    public class DSTwitterGet
    {
        public DSTwitterGet () { }
        public object AddNonProfitOrganizationInformation(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            List<MATwitter> twittwrData = new List<MATwitter>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    twittwrData.Add(new MATwitter() { MoneyTracking_Id = int.Parse(reader["MoneyTracking_Id"].ToString()), SocialActivists_Id = int.Parse(reader["SocialActivists_Id"].ToString()), Twitter_user = reader["Twitter_user"].ToString(), Hashtag = reader["Hashtag"].ToString(), Accumulated_money = double.Parse(reader["Accumulated_money"].ToString()) });
                }
                return twittwrData;
            }
            return null;
        }



        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            return;
        }


        string insertGetData = "select TB1.[SocialActivists_Id],TB2.Twitter_user,TB3.Hashtag,TB1.Accumulated_money,\r\nTB1.MoneyTracking_Id\r\nfrom [dbo].[TBMoneyTrackings] TB1 inner join [dbo].[TBSocialActivists] TB2\r\non TB2.SocialActivists_Id = TB1.SocialActivists_Id\r\ninner join [dbo].[TBCampaigns] TB3 on TB3.Campaigns_Id = TB1.Campaigns_Id";

        public List<MATwitter> GetTwitterUserRow()
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<MATwitter> newData = null;
            object listNewData = sqlQuery1.RunCommand(insertGetData, AddNonProfitOrganizationInformation, SetValues, null, null, null, null);

            if (listNewData is List<MATwitter>)
            {
                newData = (List<MATwitter>)listNewData;
            }
            return newData;
        }


    }
}
