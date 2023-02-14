using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql.PostsTracking
{
    public class DSPostsTrackingPost: BaseDataSql
    {

        SqlQueryPost sqlQuery;

        //money update after Twitter scan
        public DSPostsTrackingPost(Logger Logger) : base(Logger)
        {
            sqlQuery = new SqlQueryPost();
        }

        /// <summary>
        /// Getting all tweets of all users,
        /// Updating the details in the database.
        /// </summary>
        /// <param name="newData"> Users information. </param>
        /// <param name="command"> sql connection. </param>
        public void PostTracking(object newData,SqlCommand command)
        {
            Logger.LogEvent("Enter into PostTracking function");

            // Get a list of newData
            if (newData != null)
            {
                List<TBPostsTracking> TweetsList = null;

                if (newData is List<TBPostsTracking>)
                {
                    TweetsList = (List<TBPostsTracking>)newData;

                    // Convert the list to a DataTable
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("MoneyTracking_Id", typeof(int));
                    dataTable.Columns.Add("Campaigns_Id", typeof(int));
                    dataTable.Columns.Add("SocialActivists_Id", typeof(int));
                    dataTable.Columns.Add("Date", typeof(DateTime));
                    dataTable.Columns.Add("Active", typeof(bool));
                    dataTable.Columns.Add("Tweets_Message", typeof(string));
                    dataTable.Columns.Add("Retweets_Count", typeof(int));
                    dataTable.Columns.Add("Tweets_Message_Id", typeof(string));

                    Logger.LogEvent("Creating a temporary table");


                    try
                    {
                        if (TweetsList.Count > 0 && TweetsList != null)
                        {
                            Logger.LogEvent("Inserting data into a temporary table");

                            foreach (TBPostsTracking item in TweetsList)
                            {
                                dataTable.Rows.Add(item.MoneyTracking_Id, item.Campaigns_Id, item.SocialActivists_Id, item.Date, 1, item.Tweets_Message, item.Retweets_Count, item.Tweets_Message_Id);
                            }

                            // Execute the stored procedure and pass the DataTable as a parameter
                            command.CommandType = CommandType.StoredProcedure;

                            Logger.LogEvent("Running the procedure that performs the test process, inserts the appropriate tweets");

                            command.Parameters.AddWithValue("@TempTweetsTable", dataTable);

                            int val = command.ExecuteNonQuery();

                            Logger.LogEvent($"End PostTracking function, The procedure returns: {val}");

                        }
                    }
                    catch (SqlException Ex)
                    {
                        Logger.LogException(Ex.Message, Ex);

                        throw;
                    }
                    catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }
                }
            }
        }

        /// <summary>
        /// sql procedure name - Taking actions on someone who has tweeted for the first time or hasn't tweeted at all.
        /// </summary>
        string insertNoTweetsList = "AddFirstTweets";

        /// <summary>
        /// sql procedure name - Performing actions on those who have tweeted more than once.
        /// </summary>
        string insertExistTweetsList = "AddTweets";


        /// <summary>
        /// Sorting and inserting the appropriate tweets that do not repeat themselves
        /// </summary>
        /// <param name="NoTweetsList"> The list of tweets whose tweeted for the first time or hasn't tweeted at all. </param>
        /// <param name="ExistTweetsList"> The list of tweets whose tweeted more than once. </param>
        public void PostPostsTracking(List<TBPostsTracking> NoTweetsList,
        List<TBPostsTracking> ExistTweetsList)
        {
            Logger.LogEvent("\n\nEnter into PostPostsTracking function");

            try
            {
                if (NoTweetsList.Count() > 0)
                {
                    sqlQuery.RunAddUser(insertNoTweetsList, PostTracking, NoTweetsList);
                }
                if (ExistTweetsList.Count() > 0)
                {
                    sqlQuery.RunAddUser(insertExistTweetsList, PostTracking, ExistTweetsList);
                }

                Logger.LogEvent("End PostPostsTracking function successfully");
            }
            catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }
        }
    }
}
