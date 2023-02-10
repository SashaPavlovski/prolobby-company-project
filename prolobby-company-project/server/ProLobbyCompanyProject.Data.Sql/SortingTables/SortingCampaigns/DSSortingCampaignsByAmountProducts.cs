using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model.SortingTables.SortingCampaigns;
using System.Collections.Generic;
using System.Data.SqlClient;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql.SortingTables.SortingCampaigns
{
    public class DSSortingCampaignsByAmountProducts: BaseDataSql
    {

        SqlQuery SqlQuery;

        //Sorting of the campaigns according to the amount of products donated to them
        public DSSortingCampaignsByAmountProducts(Logger Logger) : base(Logger)
        {
            SqlQuery = new SqlQuery();
        }


        /// <summary>
        /// Sorting the reports by the amount of products for the campaign.
        /// </summary>
        /// <param name="reader"> Get data from sql. </param>
        /// <param name="command"> SQL connection. </param>
        /// <param name="campaignName"></param>
        /// <returns> List of reports sorting campaigns by product amount. </returns>
        public object AddSortingCampaigns(SqlDataReader reader,SqlCommand command, string campaignName)
        {
            Logger.LogEvent("Enter into AddSortingCampaigns function");

            List<TBSortingCampaigns> sortingCampaigns = new List<TBSortingCampaigns>();

            sortingCampaigns.Clear();

            if (reader.HasRows)
            {
                try
                {
                    Logger.LogEvent("Starting sorting the reports by the amount of products for the campaign");

                    while (reader.Read())
                    {
                        sortingCampaigns.Add(new TBSortingCampaigns
                        {
                            Campaigns_Name = reader["Campaigns_Name"].ToString(),
                            ProductAmount = int.Parse(reader["ProductAmount"].ToString())
                        });

                    }

                    Logger.LogEvent("End AddSortingCampaigns function, return campaign list");

                    return sortingCampaigns;

                }
                catch (SqlException EX)
                {

                    throw;
                }
                catch (System.Exception EX)
                {

                    throw;
                }

            }

            Logger.LogEvent("End AddSortingCampaigns function, return null");

            return null;
        }


        public void SetValues(SqlCommand command, string key, string value, string key2, string value2)
        {
            return;
        }


        /// <summary>
        /// Sql query sorting campaigns by product amount.
        /// </summary>
        string insert = "select COUNT([dbo].[TBDonatedProducts].DonatedProducts_Id) as ProductAmount,\r\n[dbo].[TBCampaigns].Campaigns_Name\r\nfrom [dbo].[TBDonatedProducts] inner join [dbo].[TBCampaigns]\r\non [dbo].[TBDonatedProducts].Campaigns_Id = [dbo].[TBCampaigns].Campaigns_Id\r\ngroup by [dbo].[TBCampaigns].Campaigns_Name\r\nORDER BY COUNT([dbo].[TBDonatedProducts].DonatedProducts_Id) desc";



        /// <summary>
        /// Get sorting campaigns by product amount.
        /// </summary>
        /// <returns> List of reports sorting campaigns by product amount. </returns>
        public List<TBSortingCampaigns> GetSortingCampaignsByProductAmount()
        {
            Logger.LogEvent("Enter into GetSortingCampaignsByProductAmount function");

            List<TBSortingCampaigns> sortingCampaigns = null;

            object listSortingCampaigns;

            try
            {
                listSortingCampaigns = SqlQuery.RunCommand(insert, AddSortingCampaigns, SetValues, null, null, null, null);
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

                    Logger.LogEvent("End GetSortingCampaignsByProductAmount function, return campaign list");

                    return sortingCampaigns;
                }
            }

            Logger.LogEvent("End GetSortingCampaignsByProductAmount function, return null");

            return sortingCampaigns;
        }
    }
}
