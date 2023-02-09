using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql.PostsTracking
{
    public class DSPostsTrackingPost: BaseDataSql
    {
        //money update after Twitter scan
        public DSPostsTrackingPost(Logger Logger) : base(Logger) { }

        public void PostTracking(object newData, System.Data.SqlClient.SqlCommand command)
        {
            // Get a list of newData
            if (newData != null)
            {
                List<TBPostsTracking> TweetsList = null;

                if (newData is List<TBPostsTracking>)
                {
                    TweetsList = (List<TBPostsTracking>)newData;
                }


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
                try
                {
                    if (TweetsList.Count > 0 && TweetsList != null)
                    {
                        foreach (TBPostsTracking item in TweetsList)
                        {
                            dataTable.Rows.Add(item.MoneyTracking_Id, item.Campaigns_Id, item.SocialActivists_Id, item.Date, 1, item.Tweets_Message, item.Retweets_Count, item.Tweets_Message_Id);
                        }

                        // Execute the stored procedure and pass the DataTable as a parameter
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TempTweetsTable", dataTable);
                        int val = command.ExecuteNonQuery();
                    }
                }
                catch (Exception EX)
                {

                    throw;
                }
               
            }
        }

        string insertNoTweetsList = "AddFirstTweets";
        string insertExistTweetsList = "AddTweets";
        public void PostPostsTracking(List<TBPostsTracking> NoTweetsList,
        List<TBPostsTracking> ExistTweetsList)
        {
            try
            {
                SqlQueryPost sqlQuery = new SqlQueryPost();
                if (NoTweetsList.Count() > 0)
                {
                    sqlQuery.RunAddUser(insertNoTweetsList, PostTracking, NoTweetsList);
                }
                if (ExistTweetsList.Count() > 0)
                {
                    sqlQuery.RunAddUser(insertExistTweetsList, PostTracking, ExistTweetsList);
                }
            }
            catch (Exception EX)
            {
                throw;
            }
        }
    }
}
