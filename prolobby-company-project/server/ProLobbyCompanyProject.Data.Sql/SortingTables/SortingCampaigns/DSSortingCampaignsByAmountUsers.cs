using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model.SortingTables.SortingCampaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.SortingTables.SortingCampaigns
{
    public class DSSortingCampaignsByAmountUsers
    {
        public DSSortingCampaignsByAmountUsers() { }
        public object AddSortingCampaigns(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string campaignName)
        {
            List<TBSortingCampaigns> sortingCampaigns = new List<TBSortingCampaigns>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    sortingCampaigns.Add(new TBSortingCampaigns() { Campaigns_Name = reader["Campaigns_Name"].ToString(), ActivistAmount = int.Parse(reader["ActivistAmount"].ToString()) });

                }
                return sortingCampaigns;
            }
            return null;
        }



        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            return;
        }

            string insert = "select COUNT([SocialActivists_Id]) as ActivistAmount,\r\n[dbo].[TBCampaigns].Campaigns_Name\r\nfrom [dbo].[TBMoneyTrackings] inner join [dbo].[TBCampaigns]\r\non [dbo].[TBMoneyTrackings].Campaigns_Id = [dbo].[TBCampaigns].Campaigns_Id\r\ngroup by [dbo].[TBCampaigns].Campaigns_Name \r\nORDER BY COUNT([SocialActivists_Id]) desc";
     

        public List<TBSortingCampaigns> GetSortingCampaignsByAmountUsers()
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBSortingCampaigns> sortingCampaigns = null;

            object listSortingCampaigns = sqlQuery1.RunCommand(insert, AddSortingCampaigns, SetValues, null, null, null, null);
            if (listSortingCampaigns != null)
            {

                if (listSortingCampaigns is List<TBSortingCampaigns>)
                {
                    sortingCampaigns = (List<TBSortingCampaigns>)listSortingCampaigns;
                }
            }
            return sortingCampaigns;
        }
    }
}
