using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model.SortingTables.SortingCampaigns;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql.SortingTables.SortingCampaigns
{
    public class DSSortingCampaignsByAmountUsers : BaseDataSql
    {
        SqlQuery SqlQuery;

        public DSSortingCampaignsByAmountUsers(Logger Logger) : base(Logger)
        {
            SqlQuery = new SqlQuery();
        }

        /// <summary>
        /// Sorting campaigns according to the number of users who follow the campaign
        /// </summary>
        /// <param name="reader"> Get data from sql. </param>
        /// <param name="command"> SQL connection. </param>
        /// <param name="campaignName"></param>
        /// <returns> List of reports sorting campaigns by activists. </returns>
        public object AddSortingCampaigns(SqlDataReader reader, SqlCommand command, string campaignName)
        {
            Logger.LogEvent("Enter into AddSortingCampaigns function");

            List<TBSortingCampaigns> sortingCampaigns = new List<TBSortingCampaigns>();

            if (reader.HasRows)
            {
                try
                {
                    Logger.LogEvent("Starting sorting campaigns according to the number of users who follow the campaign");

                    while (reader.Read())
                    {
                        sortingCampaigns.Add(new TBSortingCampaigns
                        {
                            Campaigns_Name = reader["Campaigns_Name"].ToString(),
                            ActivistAmount = int.Parse(reader["ActivistAmount"].ToString())
                        });
                    }

                    Logger.LogEvent("End AddSortingCampaigns function, return campaign list");

                    return sortingCampaigns;
                }
                catch (SqlException EX)
                {

                    throw;
                }
                catch (Exception EX)
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
        /// sql query ngroup by activists.
        /// </summary>
        string insert = "select COUNT([SocialActivists_Id]) as ActivistAmount,\r\n[dbo].[TBCampaigns].Campaigns_Name\r\nfrom [dbo].[TBMoneyTrackings] inner join [dbo].[TBCampaigns]\r\non [dbo].[TBMoneyTrackings].Campaigns_Id = [dbo].[TBCampaigns].Campaigns_Id\r\ngroup by [dbo].[TBCampaigns].Campaigns_Name \r\nORDER BY COUNT([SocialActivists_Id]) desc";

        /// <summary>
        /// Sorting the reports of the campaigns by activists.
        /// </summary>
        /// <returns> List of reports sorting campaigns by activists. </returns>
        public List<TBSortingCampaigns> GetSortingCampaignsByAmountUsers()
        {
            Logger.LogEvent("Enter into GetSortingCampaignsByAmountUsers function");

            List<TBSortingCampaigns> sortingCampaigns = null;

            object listSortingCampaigns;

            try
            {
                listSortingCampaigns = SqlQuery.RunCommand(insert, AddSortingCampaigns, SetValues, null, null, null, null);
            }
            catch (Exception EX)
            {

                throw;
            }

            if (listSortingCampaigns != null)
            {

                if (listSortingCampaigns is List<TBSortingCampaigns>)
                {
                    sortingCampaigns = (List<TBSortingCampaigns>)listSortingCampaigns;
                }

                Logger.LogEvent("End GetSortingCampaignsByAmountUsers function, return campaign list");

                return sortingCampaigns;
            }

            Logger.LogEvent("End GetSortingCampaignsByAmountUsers function, return null");

            return sortingCampaigns;
        }
    }
}
