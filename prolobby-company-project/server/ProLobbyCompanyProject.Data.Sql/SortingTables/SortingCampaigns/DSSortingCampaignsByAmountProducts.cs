using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model.SortingTables.SortingCampaigns;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql.SortingTables.SortingCampaigns
{
    public class DSSortingCampaignsByAmountProducts: BaseDataSql
    {
        //Sorting of the campaigns according to the amount of products donated to them
        public DSSortingCampaignsByAmountProducts(Logger Logger) : base(Logger) { }
        public object AddSortingCampaigns(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string campaignName)
        {
            List<TBSortingCampaigns> sortingCampaigns = new List<TBSortingCampaigns>();
            if (reader.HasRows)
            {
                try
                {
                    while (reader.Read())
                    {
                        sortingCampaigns.Add(new TBSortingCampaigns
                        {
                            Campaigns_Name = reader["Campaigns_Name"].ToString(),
                            ProductAmount = int.Parse(reader["ProductAmount"].ToString())
                        });

                    }
                }
                catch (System.Exception EX)
                {

                    throw;
                }

                return sortingCampaigns;
            }
            return null;
        }


        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            return;
        }

        string insert = "select COUNT([dbo].[TBDonatedProducts].DonatedProducts_Id) as ProductAmount,\r\n[dbo].[TBCampaigns].Campaigns_Name\r\nfrom [dbo].[TBDonatedProducts] inner join [dbo].[TBCampaigns]\r\non [dbo].[TBDonatedProducts].Campaigns_Id = [dbo].[TBCampaigns].Campaigns_Id\r\ngroup by [dbo].[TBCampaigns].Campaigns_Name\r\nORDER BY COUNT([dbo].[TBDonatedProducts].DonatedProducts_Id) desc";


        public List<TBSortingCampaigns> GetSortingCampaignsByProductAmount()
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBSortingCampaigns> sortingCampaigns = null;

            object listSortingCampaigns;

            try
            {
                listSortingCampaigns = sqlQuery1.RunCommand(insert, AddSortingCampaigns, SetValues, null, null, null, null);
            }
            catch (System.Exception EX)
            {

                throw;
            }

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
