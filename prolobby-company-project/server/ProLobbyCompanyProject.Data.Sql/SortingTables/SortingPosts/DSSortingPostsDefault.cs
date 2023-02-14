using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model.SortingTables.SortingPosts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql.SortingTables.SortingPosts
{
    public class DSSortingPostsDefault : BaseDataSql
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
        /// <param name="selectBy"> Checking according to what sort. </param>
        /// <returns> List of reports sorting posts. </returns>
        public object AddSortingPosts(SqlDataReader reader, SqlCommand command, string selectBy)
        {
            Logger.LogEvent("Enter into AddSortingPosts function");

            List<TBSortingPosts> sortingPosts = new List<TBSortingPosts>();

            sortingPosts.Clear();


            if (selectBy != null && reader.HasRows)
            {
                try
                {
                    if (selectBy.Contains("Tweets_Message_Count"))
                    {
                        while (reader.Read())
                        {
                            sortingPosts.Add(new TBSortingPosts
                            {
                                Amount_publications = int.Parse(reader["Tweets_Message_Count"].ToString()),
                                Twitter_user = reader["Twitter_user"].ToString()
                            });
                        }
                    }
                    else if (selectBy.Contains("Retweets_Count") || selectBy.Contains("Date"))
                    {
                        while (reader.Read())
                        {
                            sortingPosts.Add(new TBSortingPosts
                            {
                                Campaigns_Name = reader["Campaigns_Name"].ToString(),
                                Twitter_user = reader["Twitter_user"].ToString(),
                                Date = DateTime.Parse(reader["Date"].ToString()),
                                NonProfitOrganizationName = reader["NonProfitOrganizationName"].ToString(),
                                Active = reader["Active"].ToString(),
                                Tweets_Message = reader["Tweets_Message"].ToString(),
                                Retweets_Count = int.Parse(reader["Retweets_Count"].ToString())
                            });
                        }
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            sortingPosts.Add(new TBSortingPosts
                            {
                                Campaigns_Name = reader["Campaigns_Name"].ToString(),
                                Twitter_user = reader["Twitter_user"].ToString(),
                                Date = DateTime.Parse(reader["Date"].ToString()),
                                NonProfitOrganizationName = reader["NonProfitOrganizationName"].ToString(),
                                Active = reader["Active"].ToString(),
                                Tweets_Message = reader["Tweets_Message"].ToString(),
                                Retweets_Count = int.Parse(reader["Retweets_Count"].ToString())
                            });
                        }
                    }

                    Logger.LogEvent("End AddSortingPosts function, return list posts");

                    return sortingPosts;

                }
                catch (SqlException Ex) { Logger.LogException(Ex.Message, Ex); throw; }
                catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }

            }

            Logger.LogEvent("End AddSortingPosts function, return null");

            return null;
        }


        /// <summary>
        /// Entering values ​​and starting a procedure.
        /// </summary>
        /// <param name="command"> sql connection. </param>
        /// <param name="key"> null </param>
        /// <param name="value"> select by value. </param>
        /// <param name="key2"> null </param>
        /// <param name="value2"> null </param>
        public void SetValues(SqlCommand command, string key, string value, string key2, string value2)
        {
            if (command != null && value != null)
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OrderByMsg", value);
            }

            return;
        }


        /// <summary>
        /// Get list of reports by sorting Date.
        /// </summary>
        /// <param name="sortBy"> sorting value. </param>
        /// <returns> List of reports sorting posts. </returns>
        public List<TBSortingPosts> GetSortingPostsDefault(string sortBy)
        {
            Logger.LogEvent("Enter into GetSortingPostsDefault function");

            List<TBSortingPosts> sortingPosts = null;

            object listSortingPosts;

            /// <summary> Sql procedure name - Sort by value. </summary>
            string insert = "TweetReportOrderBy";

            try
            {
                listSortingPosts = SqlQuery.RunCommand(insert, AddSortingPosts, SetValues, null, sortBy, null, null);
            }
            catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }

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
        /// Get list of reports.
        /// </summary>
        /// <returns> List of reports sorting posts. </returns>
        public List<TBSortingPosts> GetByAll()
        {
            Logger.LogEvent("\n\nEnter into GetByAll function");

            return GetSortingPostsDefault("GetByAll");
        }


        /// <summary>
        /// Get list of reports by sorting date.
        /// </summary>
        /// <returns> List of reports sorting posts by date. </returns>
        public List<TBSortingPosts> GetByDate()
        {
            Logger.LogEvent("\n\nEnter into GetByDate function");

            return GetSortingPostsDefault("Date");
        }

        /// <summary>
        /// Get list of reports by sorting retweets count.
        /// </summary>
        /// <returns> List of reports sorting posts by retweets count. </returns>
        public List<TBSortingPosts> GetByRetweetsCount()
        {
            Logger.LogEvent("\n\nEnter into GetByRetweetsCount function");

            return GetSortingPostsDefault("Retweets_Count");
        }


        /// <summary>
        /// Get list of reports by sorting tweets.
        /// </summary>
        /// <returns> List of reports sorting posts by tweets. </returns>
        public List<TBSortingPosts> GetByTweets()
        {
            Logger.LogEvent("\n\nEnter into GetByTweets function");

            return GetSortingPostsDefault("Tweets_Message_Count");
        }
    }
}
