using Newtonsoft.Json.Linq;
using ProLobbyCompanyProject.Data.Sql.MoneyTracking;
using ProLobbyCompanyProject.Data.Sql.PostsTracking;
using ProLobbyCompanyProject.Data.Sql.Twitter;
using ProLobbyCompanyProject.Model.Keys;
using ProLobbyCompanyProject.Model.Tables;
using ProLobbyCompanyProject.Model.Twitter;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Utilities.Logger;

namespace CommunicationSocial
{
    public class AddTwitter: BaseCommunicationSocial
    {

        /// <summary> Defining classes </summary>
        DSTwitterGet dSTwitterGet;

        DSMoneyTrackingMoneyUpdate newData;

        DSPostsTrackingPost dSPostsTrackingPost;
        /// <summary> Defining classes </summary>



        /// <summary> Delegate </summary>
        public delegate string UrlQueryDelegate(object data);

        public delegate void AccessDataSqlDelegate(object date, object newDate);
        /// <summary> Delegate </summary>



        /// <summary> Defining Task </summary>
        Task TwitterTask = null;
        /// <summary> Defining Task </summary>



        /// <summary> Defining Properties </summary>
        bool StopLoop { get; set; } = false;
        /// <summary> Defining Properties </summary>


        public AddTwitter(Logger logger) : base(logger) 
        {
            dSTwitterGet = new DSTwitterGet(base.Logger);
            newData = new DSMoneyTrackingMoneyUpdate(base.Logger);
            dSPostsTrackingPost = new DSPostsTrackingPost(base.Logger);
            PostPostsTracking();
        }

        string UrlQuery(object user)
        {
            Logger.LogEvent("Enter into UrlQuery function");

            MATwitter User = null;
            string url = null;

            try
            {
                if (user != null && user is MATwitter)
                {
                    User = user as MATwitter;

                    if (User.Answer.Contains("No tweets"))
                    {
                        return url = $"https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={User.Twitter_user}&count=800&trim_user=t";
                    }
                    else if (User.Answer.Contains("Exist tweets"))
                    {
                        return url = $"https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={User.Twitter_user}&count=800&trim_user=t&since_id={User.Tweets_Message_Id}";
                    }
                    else
                    {
                        Logger.LogError("In UrlQuery function user answer is invalid");

                        return url;
                    }
                }
                else
                {
                    Logger.LogError("In UrlQuery function user data is invalid");

                    return url;
                }
            }
            catch (Exception EX)
            {

                throw;
            }
        }

        void AccessDataSql(object user, object accumulatedMoney)
        {
            Logger.LogEvent("Enter into AccessDataSql function");

            MATwitter User = null;

            double? AccumulatedMoney = null;

            if (user != null && user is MATwitter)
            {
                User = (MATwitter)user;
            }
            if (accumulatedMoney != null && accumulatedMoney is double)
            {
                AccumulatedMoney = (double)accumulatedMoney;
            }
            if (User != null && AccumulatedMoney != null)
            {
                newData.UpdateMoneyTracking(User, AccumulatedMoney.Value);
            }
            else
            {
                Logger.LogError("In AccessDataSql function, one or both variables are incorrect");
            }
        }


        /// <summary>
        /// Uploading new tweets.
        /// </summary>
        public void PostPostsTracking()
        {
            Logger.LogEvent("Enter into PostPostsTracking function");

            TwitterTask = Task.Run(() =>
            {
                Logger.LogEvent("The task started running");

                while (!StopLoop)
                {
                    Logger.LogEvent("Started checking Twitter");

                    List<MATwitter> userData;

                    try
                    {
                        try
                        {
                             userData = dSTwitterGet.GetTwitterUserRow();
                        }
                        catch (Exception EX)
                        {

                            throw;
                        }

                        List<TBPostsTracking> NoTweetsList = new List<TBPostsTracking>();
                        List<TBPostsTracking> ExistTweetsList = new List<TBPostsTracking>();

                        if (userData.Count > 0)
                        {
                            if (userData != null && userData.Count > 0)
                            {
                                PostTweets(userData, NoTweetsList, ExistTweetsList, Keys.BearerToken, UrlQuery, AccessDataSql);


                                //Update tweets
                                if (NoTweetsList.Count > 0 || ExistTweetsList.Count > 0)
                                {
                                    dSPostsTrackingPost.PostPostsTracking(NoTweetsList, ExistTweetsList);
                                    NoTweetsList.Clear();
                                    ExistTweetsList.Clear();
                                }
                            }

                            //Activated every hour

                            Logger.LogEvent("End checking Twitter");

                            Thread.Sleep(1000 * 60 * 60);
                        }
                    }
                    catch (Exception EX)
                    {

                        throw;
                    }
                }
            });

            Logger.LogEvent("End PostPostsTracking function and Twitter task");
        }


        /// <summary>
        /// Uploading new tweets.
        /// </summary>
        /// <param name="userData"> Data about the user. </param>
        /// <param name="noTweetsList"> An empty list for users who are not yet tweeting. </param>
        /// <param name="existTweetsList"> An empty list for users who have uploaded at least one tweet. </param>
        /// <param name="BearerToken"> Connecting to Twitter.  </param>
        /// <param name="UrlQuery"> Delegate get Url twitter query. </param>
        /// <param name="AccessDataSqlFunc"> Delegate Sending the tweets to update money.  </param>
        public void PostTweets(object userData, object noTweetsList, object existTweetsList,string BearerToken, UrlQueryDelegate UrlQuery, AccessDataSqlDelegate AccessDataSqlFunc)
        {
            Logger.LogEvent("Enter into PostTweets function");

            try
            {
                List<MATwitter> UserData = null;
                List<TBPostsTracking> NoTweetsList = null;
                List<TBPostsTracking> ExistTweetsList = null;

                if (userData is List<MATwitter>)
                {
                    UserData = (List<MATwitter>)userData;
                }
                if (noTweetsList is List<TBPostsTracking>)
                {
                    NoTweetsList = (List<TBPostsTracking>)noTweetsList;
                }
                if (existTweetsList is List<TBPostsTracking>)
                {
                    ExistTweetsList = (List<TBPostsTracking>)existTweetsList;
                }

                if (UserData != null && UserData.Count > 0)
                {
                    foreach (MATwitter user in UserData)
                    {
                        string Url = UrlQuery(user);

                        if (Url != null) { 

                        var clientTwitter = new RestClient(Url);

                        var requestTwitter = new RestRequest("", Method.Get);

                        requestTwitter.AddHeader("authorization", $"Bearer {BearerToken}");

                        var responseTwitter = clientTwitter.Execute(requestTwitter);

                        if (responseTwitter.IsSuccessful)
                        {
                            JArray json = JArray.Parse(responseTwitter.Content);

                            int tweetCount = 0;
                            int AccumulatedMoney = 0;

                            string tweetTime;
                            string TweetsMessage;
                            string TweetsMessageId;

                            if (json.Count > 0)
                            {
                                    foreach (var tweet in json)
                                    {
                                        if (tweet != null)
                                        {
                                            TweetsMessage = tweet["text"].ToString();

                                            //Checking if this is someone's tweet
                                            if (!TweetsMessage.Contains("RT @"))
                                            {
                                                //Checking whether the hashtag is present in the tweet
                                                if (TweetsMessage.Contains(user.Hashtag))
                                                {
                                                    tweetTime = tweet["created_at"].ToString();

                                                    TweetsMessageId = tweet["id"].ToString();

                                                    int retweet_count = int.Parse(tweet["retweet_count"].ToString());

                                                    DateTime TimeUserTweet = ChangeStringToDateTime(tweetTime);
                                                    List<MATwitter> AllUserRows = UserData.FindAll(u => u.Twitter_user == user.Twitter_user);

                                                    if (AllUserRows != null)
                                                    {
                                                        DateTime? LastTimeUser = AllUserRows.Max(u => u.Date).Value;
                                                        if (LastTimeUser < TimeUserTweet || user.Date == null)
                                                        {
                                                            tweetCount++;
                                                            AccumulatedMoney = AccumulatedMoney + retweet_count + 1;
                                                        }
                                                    }



                                                    TBPostsTracking tBPostsTracking = new TBPostsTracking
                                                    {
                                                        MoneyTracking_Id = user.MoneyTracking_Id,
                                                        Date = TimeUserTweet,
                                                        Retweets_Count = retweet_count,
                                                        Tweets_Message = TweetsMessage,
                                                        Tweets_Message_Id = TweetsMessageId,
                                                        SocialActivists_Id = user.SocialActivists_Id
                                                    };

                                                    if (user.Answer.Contains("No tweets"))
                                                    {
                                                        NoTweetsList.Add(tBPostsTracking);
                                                    }
                                                    else if (user.Answer.Contains("Exist tweets"))
                                                    {
                                                        ExistTweetsList.Add(tBPostsTracking);
                                                    }
                                                    else
                                                    {
                                                        //The database will not return a valid answer

                                                    }
                                                }
                                            }
                                        }

                                        Logger.LogEvent($"Tweet count of {user.Twitter_user} is {tweetCount}");

                                        if (tweetCount != 0)
                                        {
                                            //Sending the tweets to update money
                                            AccessDataSqlFunc(user, AccumulatedMoney);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Logger.LogEvent("End PostTweets function successfully");
            }
            catch (Exception EX)
            {

                throw;
            }
        }


        /// <summary>
        /// Converting a date string to a date type variable.
        /// </summary>
        /// <param name="dateInput"> date string from sql. </param>
        /// <returns> date type variable. </returns>
        public DateTime ChangeStringToDateTime(string dateInput)
        {
            Logger.LogEvent("Enter into ChangeStringToDateTime function");

            DateTime TweetTime = DateTime.MinValue;

            try
            {
                if (dateInput != null)
                {
                    string dateInputWithComma = dateInput.Replace(' ', ',');

                    string[] DateArray = dateInputWithComma.Split(new string[] { "," }, StringSplitOptions.None);

                    string DateTweet = $"{DateArray[1]} {DateArray[2]},{DateArray[5]}";
                    string TimeTweet = $"{DateArray[3]}";

                    var parsedDate = DateTime.Parse(DateTweet);
                    var parsedTime = DateTime.Parse(TimeTweet).AddHours(+2);

                    TweetTime = new DateTime(parsedDate.Year, parsedDate.Month, parsedDate.Day, parsedTime.Hour, parsedTime.Minute, 0);
                }
            }
            catch (Exception EX)
            {

                throw;
            }

            Logger.LogEvent("End ChangeStringToDateTime function");

            return TweetTime;
        }
    }    
}
