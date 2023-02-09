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
using System.Threading;
using System.Threading.Tasks;
using Utilities.Logger;

namespace CommunicationSocial
{
    public class AddTwitter: BaseCommunicationSocial
    {
        DSTwitterGet dSTwitterGet;
        DSMoneyTrackingMoneyUpdate newData;
        DSPostsTrackingPost dSPostsTrackingPost;
        Task TwitterTask = null;
        bool StopLoop { get; set; } = false;

        public delegate string UrlQueryDelegate(object data);
        public delegate void AccessDataSqlDelegate(object date, object newDate);

        public AddTwitter(Logger logger) : base(logger) 
        {
            dSTwitterGet = new DSTwitterGet(base.Logger);
            newData = new DSMoneyTrackingMoneyUpdate(base.Logger);
            dSPostsTrackingPost = new DSPostsTrackingPost(base.Logger);
            PostPostsTracking();
        }

        string UrlQuery(object user)
        {
            MATwitter User = null;
            string url = null;
            try
            {
                if (user != null)
                {
                    if (user is MATwitter)
                    {
                        User = user as MATwitter;

                        if (User.Answer.Contains("No tweets"))
                        {
                            url = $"https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={User.Twitter_user}&count=800&trim_user=t";
                        }
                        else if (User.Answer.Contains("Exist tweets"))
                        {
                            url = $"https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={User.Twitter_user}&count=800&trim_user=t&since_id={User.Tweets_Message_Id}";
                        }
                    }
                }
            }
            catch (Exception EX)
            {

                throw;
            }
            return url;
        }

        void AccessDataSql(object user, object accumulatedMoney)
        {
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

        }



        public void PostPostsTracking()
        {
            TwitterTask = Task.Run(() =>
            {
                while (!StopLoop)
                {
                    try
                    {
                        List<MATwitter> userData = dSTwitterGet.GetTwitterUserRow();
                        List<TBPostsTracking> NoTweetsList = new List<TBPostsTracking>();
                        List<TBPostsTracking> ExistTweetsList = new List<TBPostsTracking>();
                        if (userData.Count > 0)
                        {
                            if (userData != null && userData.Count > 0)
                            {
                                PostTweets(userData, NoTweetsList, ExistTweetsList, Keys.BearerToken, UrlQuery, AccessDataSql);
                                //עידכון ציוצים
                                if (NoTweetsList.Count > 0 || ExistTweetsList.Count > 0)
                                {
                                    dSPostsTrackingPost.PostPostsTracking(NoTweetsList, ExistTweetsList);
                                    NoTweetsList.Clear();
                                    ExistTweetsList.Clear();
                                }
                            }
                            // Thread.Sleep(1000 * 60 *3);
                            Thread.Sleep(1000 * 60 * 60);
                        }
                    }
                    catch (Exception EX)
                    {

                        throw;
                    }
                }
            });
        }


        public void PostTweets(object userData, object noTweetsList, object existTweetsList,string BearerToken, UrlQueryDelegate UrlQuery, AccessDataSqlDelegate AccessDataSqlFunc)
        {

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
                        if (Url == null) return;

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
                                        if (!TweetsMessage.Contains("RT @")) //לעשות תנאי שבודק שלא מדובר בציוץ שמשהו שיתף
                                        {
                                            if (TweetsMessage.Contains(user.Hashtag))
                                            {
                                                tweetTime = tweet["created_at"].ToString();
                                                TweetsMessageId = tweet["id"].ToString();
                                                int retweet_count = int.Parse(tweet["retweet_count"].ToString());
                                                tweetCount++;
                                                AccumulatedMoney = AccumulatedMoney + retweet_count + 1;
                                                TBPostsTracking tBPostsTracking = new TBPostsTracking
                                                {
                                                    MoneyTracking_Id = user.MoneyTracking_Id,
                                                    Date = ChangeStringToDateTime(tweetTime),
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
                                            }
                                        }
                                    }
                                    Console.WriteLine(tweetCount);
                                    if (tweetCount != 0)
                                    {
                                        AccessDataSqlFunc(user, AccumulatedMoney);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception EX)
            {

                throw;
            }
        }


        public DateTime ChangeStringToDateTime(string dateInput)
        {
            DateTime TweetTime;
            try
            {
                string dateInputWithComma = dateInput.Replace(' ', ',');
                string[] DateArray = dateInputWithComma.Split(new string[] { "," }, StringSplitOptions.None);
                string DateTweet = $"{DateArray[1]} {DateArray[2]},{DateArray[5]}";
                string TimeTweet = $"{DateArray[3]}";

                var parsedDate = DateTime.Parse(DateTweet);
                var parsedTime = DateTime.Parse(TimeTweet).AddHours(+2);

                TweetTime = new DateTime(parsedDate.Year, parsedDate.Month, parsedDate.Day, parsedTime.Hour, parsedTime.Minute, 0);
            }
            catch (Exception EX)
            {

                throw;
            }
            return TweetTime;
        }
    }    
}
