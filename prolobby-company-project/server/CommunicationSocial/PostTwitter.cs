using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Model.Shippers;
using ProLobbyCompanyProject.Model.Tables;
using System;
using System.Net;
using Tweetinvi;
using Utilities.Logger;

namespace CommunicationSocial
{
    public class PostTwitter: BaseCommunicationSocial
    {
        public PostTwitter(Logger logger) : base(logger) { }

        /// <summary>
        /// After buying a product post an ad on the owner's Twitter.
        /// </summary>
        /// <param name="buyProduct">Product information</param>
        public async void PostTweets(MAbuyProduct buyProduct)
        {
            base.Logger.LogEvent("\n\nEnser into PostTweets");

            try
            {
                if (Keys!= null)
                {
                    var userClient = new TwitterClient(base.Keys.ApiKey, base.Keys.ApiKeySecret, base.Keys.AccessToken, base.Keys.AccessTokenSecret);

                    await userClient.Users.GetAuthenticatedUserAsync();

                    await userClient.Tweets.PublishTweetAsync($"A product number {buyProduct.DonatedProducts_Id} has been purchased on the website");

                    base.Logger.LogEvent("The operation of posting the tweet was dane successfully in PostTweets");
                }

            }
            catch (WebException Ex)
            {
                base.Logger.LogException(Ex.Message, Ex);
                throw;
            }
            catch (Exception Ex)
            {
                base.Logger.LogException(Ex.Message, Ex);
                throw;
            }
        }
    }
}
