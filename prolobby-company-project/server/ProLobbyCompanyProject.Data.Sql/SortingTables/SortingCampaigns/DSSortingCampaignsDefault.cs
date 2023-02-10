using ProLobbyCompanyProject.Dal;
using System;
using System.Collections.Generic;
using ProLobbyCompanyProject.Model.SortingTables.SortingCampaigns;
using Utilities.Logger;
using System.Data.SqlClient;

namespace ProLobbyCompanyProject.Data.Sql.SortingTables.SortingCampaigns
{
    public class DSSortingCampaignsDefault: BaseDataSql
    {
        SqlQuery SqlQuery;

        public DSSortingCampaignsDefault(Logger Logger) : base(Logger) 
        {
            SqlQuery = new SqlQuery();
        }

        /// <summary>
        /// Sorting campaigns by date, organization and activity
        /// </summary>
        /// <param name="reader"> Get the data from the sql. </param>
        /// <param name="command"> SQL connection. </param>
        /// <param name="campaignName"></param>
        /// <returns> List of reports sorting campaigns. </returns>
        public object AddSortingCampaigns(SqlDataReader reader,SqlCommand command, string campaignName)
        {
            Logger.LogEvent("Enter into AddSortingCampaigns function");

            List<TBSortingCampaigns> sortingCampaigns = new List<TBSortingCampaigns>();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        sortingCampaigns.Add(new TBSortingCampaigns
                        {
                            Campaigns_Name = reader["Campaigns_Name"].ToString(),
                            NonProfitOrganizationName = reader["NonProfitOrganizationName"].ToString(),
                            MoneyDonations = double.Parse(reader["MoneyDonations"].ToString()),
                            Active = reader["Active"].ToString(),
                            Date = DateTime.Parse(reader["Date"].ToString())
                        });
                    }

                    Logger.LogEvent("End AddSortingCampaigns function, return list campaigns");

                    return sortingCampaigns;
                }
            }
            catch (SqlException EX)
            {

                throw;
            }
            catch (Exception EX)
            {

                throw;
            }

            Logger.LogEvent("End AddSortingCampaigns function, return null");

            return null;
        }



        public void SetValues(SqlCommand command, string key, string value, string key2, string value2)
        {
            return;
        }

        /// <summary>
        /// Creating a Sql query
        /// </summary>
        /// <param name="value"> Order by value </param>
        /// <returns> Sql query with order by value  </returns>
        public string EnteringValueToInsert(string value)
        {
            Logger.LogEvent("Enter into EnteringValueToInsert function");

            string insert = null;

            if (value != null)
            {
                insert = $"select TB1.Campaigns_Name,CONVERT(NVARCHAR(10), TB1.[Date],3) AS [Date],\r\ncase when TB1.Active = 0 then 'inactive'\r\nelse 'active'end as 'Active',TB1.MoneyDonations,\r\nTB2.NonProfitOrganizationName from [dbo].[TBCampaigns] TB1 inner join [dbo].[TBNonProfitOrganizations] TB2\r\non  TB1.NonProfitOrganization_Id = TB2.NonProfitOrganization_Id ORDER BY {value}";

                Logger.LogEvent("End EnteringValueToInsert function, return sql query");

                return insert;
            }

            Logger.LogError("End EnteringValueToInsert function,get in value null.");

            return insert;
        }

        /// <summary>
        /// Get list of reports by sorting Date.
        /// </summary>
        /// <param name="insert"> sql query with sorting value. </param>
        /// <returns> List of reports sorting campaigns. </returns>
        public List<TBSortingCampaigns> GetSortingCampaignsDefault(string insert)
        {
            Logger.LogEvent("Enter into GetSortingCampaignsDefault function");

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

                    Logger.LogEvent("End GetSortingCampaignsDefault function, return list sorting campaigns");

                    return sortingCampaigns;
                }
            }

            Logger.LogEvent("End GetSortingCampaignsDefault function, return null");

            return sortingCampaigns;
        }

        /// <summary>
        /// Get list of reports by sorting Date.
        /// </summary>
        /// <returns> List of reports sorting campaigns by date. </returns>
        public List<TBSortingCampaigns> GetByDate()
        {
            Logger.LogEvent("Enter into GetByDate function");

            return GetSortingCampaignsDefault(EnteringValueToInsert("TB1.[Date]"));
        }


        /// <summary>
        /// Get list of reports by sorting Organization.
        /// </summary>
        /// <returns> List of reports sorting campaigns by Organization. </returns>
        public List<TBSortingCampaigns> GetByOrganization()
        {
            Logger.LogEvent("Enter into GetByOrganization function");

            return GetSortingCampaignsDefault(EnteringValueToInsert("TB2.NonProfitOrganizationName"));
        }


        /// <summary>
        /// Get list of reports by sorting activity.
        /// </summary>
        /// <returns> List of reports sorting campaigns by activity. </returns>
        public List<TBSortingCampaigns> GetByActivity()
        {
            Logger.LogEvent("Enter into GetByActivity function");

            return GetSortingCampaignsDefault(EnteringValueToInsert("TB1.Active"));
        }
    }
}
