using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model.SortingTables.SortingPosts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql.SortingTables.SortingPosts
{
    public class DSSortingPostsDefault: BaseDataSql
    {

        SqlQuery SqlQuery;

        public DSSortingPostsDefault(Logger Logger) : base(Logger)
        {
            SqlQuery = new SqlQuery();
        }


        /// <summary>
        /// Sorting posts by date and tweets.
        /// </summary>
        /// <param name="reader"> Get the data from the sql. </param>
        /// <param name="command"> SQL connection. </param>
        /// <param name="campaignName"></param>
        /// <returns> List of reports sorting posts. </returns>
        public object AddSortingPosts(SqlDataReader reader, SqlCommand command, string campaignName)
        {
            Logger.LogEvent("Enter into AddSortingPosts function");

            List<TBSortingPosts> sortingPosts = new List<TBSortingPosts>();

            sortingPosts.Clear();

            if (reader.HasRows)
            {
                try
                {
                    while (reader.Read())
                    {
                        sortingPosts.Add(new TBSortingPosts
                        {
                            Campaigns_Name = reader["Campaigns_Name"].ToString(),
                            Twitter_user = reader["Twitter_user"].ToString(),
                            Date = DateTime.Parse(reader["Date"].ToString()),
                            Amount_publications = int.Parse(reader["Amount_publications"].ToString()),
                            NonProfitOrganizationName = reader["NonProfitOrganizationName"].ToString(),
                            Active = reader["Active"].ToString()
                        });
                    }

                    Logger.LogEvent("End AddSortingPosts function, return list posts");

                    return sortingPosts;

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

            Logger.LogEvent("End AddSortingPosts function, return null");

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
                insert = $"select CONVERT(NVARCHAR(10), TB1.[Date],3) AS [Date],TB1.Amount_publications,\r\ncase when TB1.Active = 0 then 'inactive'\r\nelse 'active'end as 'Active',\r\nTB2.Twitter_user,\r\nTB3.Campaigns_Name,TB4.NonProfitOrganizationName\r\nfrom [dbo].[TBPostsTrackings] TB1 inner join [dbo].[TBSocialActivists] TB2\r\non  TB1.SocialActivists_Id = TB2.SocialActivists_Id inner join [dbo].[TBCampaigns] TB3\r\non  TB1.Campaigns_Id = TB3.Campaigns_Id inner join [dbo].[TBNonProfitOrganizations] TB4\r\non  TB3.NonProfitOrganization_Id = TB4.NonProfitOrganization_Id ORDER BY {value}";

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
        /// <returns> List of reports sorting posts. </returns>
        public List<TBSortingPosts> GetSortingPostsDefault(string insert)
        {
            Logger.LogEvent("Enter into GetSortingPostsDefault function");

            List<TBSortingPosts> sortingPosts = null;

            object listSortingPosts;

            try
            {
                listSortingPosts = SqlQuery.RunCommand(insert, AddSortingPosts, SetValues, null, null, null, null);
            }
            catch (Exception EX)
            {

                throw;
            }

            if (listSortingPosts != null)
            {

                if (listSortingPosts is List<TBSortingPosts>)
                {
                    sortingPosts = (List<TBSortingPosts>)listSortingPosts;

                    Logger.LogEvent("End GetSortingPostsDefault function, return list sorting posts");

                    return sortingPosts;

                }
            }

            Logger.LogEvent("End GetSortingPostsDefault function, return null");

            return sortingPosts;
        }


        /// <summary>
        /// Get list of reports by sorting date.
        /// </summary>
        /// <returns> List of reports sorting posts by date. </returns>
        public List<TBSortingPosts> GetByDate()
        {
            Logger.LogEvent("Enter into GetByDate function");

            return GetSortingPostsDefault(EnteringValueToInsert("TB1.[Date]"));
        }

        /// <summary>
        /// Get list of reports by sorting tweets.
        /// </summary>
        /// <returns> List of reports sorting posts by tweets. </returns>
        public List<TBSortingPosts> GetByTweets()
        {
            Logger.LogEvent("Enter into GetByTweets function");

            return GetSortingPostsDefault(EnteringValueToInsert("TB1.Amount_publications desc"));
        }
    }
}
