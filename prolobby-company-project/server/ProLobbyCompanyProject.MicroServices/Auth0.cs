using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using ProLobbyCompanyProject.Entites;
using ProLobbyCompanyProject.Model;
using System.Collections.Generic;
using ProLobbyCompanyProject.Dal;
using System.Text.Json;
using System.Reflection.Metadata;
using System.Net;
using ProLobbyCompanyProject.Model.Campaigns;
using ProLobbyCompanyProject.Model.MoneyTracking;
using ProLobbyCompanyProject.Model.Shippers;
using ProLobbyCompanyProject.Model.Twitter;
using static System.Net.WebRequestMethods;
using Tweetinvi;
using ProLobbyCompanyProject.Model.SortingTables.SortingCampaigns;
using ProLobbyCompanyProject.Model.SortingTables.SortingPosts;
using ProLobbyCompanyProject.Model.SortingTables.SortingProducts;
using ProLobbyCompanyProject.Model.SortingTables.SortingUsers;
using ProLobbyCompanyProject.Model.Keys;

namespace ProLobbyCompanyProject.MicroServices
{
    public static class Auth0
    {
        [FunctionName("ProLobbyCompany")]
        public static async Task<IActionResult> ProLobbyCompanyRunner(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "delete", "post","put", Route = "{content}/{action}/{userId?}")] HttpRequest req, string content, string action, string userId,
            ILogger log)
        {
            Keys keys= new Keys();
            switch (content)
            {
                //Checking whether there is permission enter with auth0
                //If yes returns data on user
                case "roles":
                    var urlGetRoles = $"https://dev-mluuahxjbvf524ap.us.auth0.com/api/v2/users/{userId}/roles";
                    var client = new RestClient(urlGetRoles);
                    var request = new RestRequest("", Method.Get);
                    request.AddHeader("authorization", $"Bearer {keys.BearerTokenAuth0}");

                    var response = client.Execute(request);
                    if (response.IsSuccessful)
                    {
                        var json = JArray.Parse(response.Content);
                        return new OkObjectResult(json);
                    }
                    else return new NotFoundResult();

                //User login with enter details
                case "BusinessCompanyRepresentative":
                    switch (action)
                    {
                        //Checks if the user exists
                        case "userData":

                            List<TBBusinessCompanyRepresentative> ListBusinessCompany = MainManager.INSTANCE.CheckingBusinessCompanyRepresentative(userId);
                            string responseMessageLB = System.Text.Json.JsonSerializer.Serialize(ListBusinessCompany);
                            Console.WriteLine(responseMessageLB);
                            return new OkObjectResult(responseMessageLB);

                        //Enters new data 
                        case "addData":

                            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                            TBBusinessCompanyRepresentative userCompany = System.Text.Json.JsonSerializer.Deserialize<TBBusinessCompanyRepresentative>(requestBody);
                            if (userCompany.Url != null && userCompany.Email != null && userCompany.CompanyName != null && userCompany.RepresentativeFirstName != null && userCompany.RepresentativeLastName != null && userCompany.User_Id != null && userCompany.Phone_number != null)
                            {
                                MainManager.INSTANCE.PostNonProfitCompanyData(userCompany);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");

                        //Updates the user's data
                        case "updateData":

                            string requestCompanyBody = await new StreamReader(req.Body).ReadToEndAsync();
                            TBBusinessCompanyRepresentative UserCompanyData = System.Text.Json.JsonSerializer.Deserialize<TBBusinessCompanyRepresentative>(requestCompanyBody);
                            if (UserCompanyData.BusinessCompany_Id != 0 && UserCompanyData.RepresentativeFirstName != null && UserCompanyData.RepresentativeLastName != null && UserCompanyData.CompanyName != null && UserCompanyData.Phone_number != null && UserCompanyData.Email != null)
                            {
                                MainManager.INSTANCE.UpdateBusinessCompanyData(UserCompanyData);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");

                    }
                    break;


                //User login with enter details
                case "ProLobbyOwner":
                    switch (action)
                    {
                        //Checks if the user exists
                        case "userData":
                            List<TBProLobbyOwner> ListProLobbyOwner = MainManager.INSTANCE.CheckingTBProLobbyOwner(userId);
                            string responseMessagePO = System.Text.Json.JsonSerializer.Serialize(ListProLobbyOwner);
                            Console.WriteLine(responseMessagePO);
                            return new OkObjectResult(responseMessagePO);

                        //Enters new data
                        case "addData":

                            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                            TBProLobbyOwner userOwner = System.Text.Json.JsonSerializer.Deserialize<TBProLobbyOwner>(requestBody);
                            if (userOwner.FirstName != null && userOwner.LastName != null && userOwner.Email != null && userOwner.Phone_number != null && userOwner.User_Id != null)
                            {
                                MainManager.INSTANCE.PostProLobbyOwnerData(userOwner);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");


                        //Updates the user's data
                        case "updateData":

                            string requestOwnerBody = await new StreamReader(req.Body).ReadToEndAsync();
                            TBProLobbyOwner UserOwnerData = System.Text.Json.JsonSerializer.Deserialize<TBProLobbyOwner>(requestOwnerBody);
                            if (UserOwnerData.ProLobbyOwner_Id != 0 && UserOwnerData.FirstName != null && UserOwnerData.LastName != null && UserOwnerData.Email != null && UserOwnerData.Phone_number != null)
                            {
                                MainManager.INSTANCE.UpdateProLobbyOwnerData(UserOwnerData);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");
                    }
                    break;

                //User login with enter details
                case "NonProfitOrganization":
                    switch (action)
                    {
                        //Checks if the user exists
                        case "userData":
                            List<TBNonProfitOrganization> ListNonProfitOrganization = MainManager.INSTANCE.CheckingTBNonProfitOrganization(userId);
                            string responseMessageNP = System.Text.Json.JsonSerializer.Serialize(ListNonProfitOrganization);
                            Console.WriteLine(responseMessageNP);
                            return new OkObjectResult(responseMessageNP);

                        //Enters new data
                        case "addData":

                            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                            TBNonProfitOrganization userOrganization = System.Text.Json.JsonSerializer.Deserialize<TBNonProfitOrganization>(requestBody);
                            if (userOrganization.Url != null && userOrganization.decreption != null && userOrganization.NonProfitOrganizationName != null && userOrganization.RepresentativeFirstName != null && userOrganization.RepresentativeLastName != null && userOrganization.User_Id != null)
                            {
                                MainManager.INSTANCE.PostNonProfitOrganizationData(userOrganization);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");



                        //Updates the user's data
                        case "updateData":

                            string requestOrganizationBody = await new StreamReader(req.Body).ReadToEndAsync();
                            TBNonProfitOrganization UserOrganizationData = System.Text.Json.JsonSerializer.Deserialize<TBNonProfitOrganization>(requestOrganizationBody);
                            if (UserOrganizationData.NonProfitOrganization_Id != 0 && UserOrganizationData.NonProfitOrganizationName != null && UserOrganizationData.RepresentativeLastName != null && UserOrganizationData.Email != null && UserOrganizationData.Phone_number != null && UserOrganizationData.RepresentativeFirstName != null && UserOrganizationData.decreption != null && UserOrganizationData.Url != null)
                            {
                                MainManager.INSTANCE.UpdateOrganizationData(UserOrganizationData);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");


                    }
                    break;

                //User login with enter details
                case "SocialActivists":
                    switch (action)
                    {
                        //Checks if the user exists
                        case "userData":
                            List<TBSocialActivists> ListSocialActivists = MainManager.INSTANCE.CheckingTBSocialActivists(userId);
                            string responseMessageSA = System.Text.Json.JsonSerializer.Serialize(ListSocialActivists);
                            Console.WriteLine(responseMessageSA);
                            return new OkObjectResult(responseMessageSA);

                        //Enters new data
                        case "addData":

                            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                            TBSocialActivists userActivists = System.Text.Json.JsonSerializer.Deserialize<TBSocialActivists>(requestBody);
                            if (userActivists.FirstName != null && userActivists.LastName != null && userActivists.Email != null && userActivists.Phone_number != null && userActivists.User_Id != null && userActivists.Address != null && userActivists.Twitter_user != null)
                            {
                                MainManager.INSTANCE.PostSocialActivistsData(userActivists);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");

                        //Updates the user's data
                        case "updateData":

                            string requestActivistsBody = await new StreamReader(req.Body).ReadToEndAsync();
                            TBSocialActivists UserActivistsData = System.Text.Json.JsonSerializer.Deserialize<TBSocialActivists>(requestActivistsBody);
                            if (UserActivistsData.SocialActivists_Id != 0 && UserActivistsData.FirstName != null && UserActivistsData.LastName != null && UserActivistsData.Email != null && UserActivistsData.Phone_number != null && UserActivistsData.Address != null && UserActivistsData.Twitter_user != null)
                            {
                                MainManager.INSTANCE.UpdateSocialActivistsData(UserActivistsData);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");
                    }
                    break;


                case "Campaigns":
                    switch (action)
                    {
                        // get all campaigns
                        case "getData":

                            List<TBCampaigns> campaignList = MainManager.INSTANCE.GetTBCampaigns();
                            string responseCampaignList = System.Text.Json.JsonSerializer.Serialize(campaignList);
                            return new OkObjectResult(responseCampaignList);


                        // get campaigns by organization id 
                        case "getDataById":

                            List<TBCampaigns> organizationCampaignsList = MainManager.INSTANCE.GetCampaignsOrganizationById(userId);
                            string responseCampaignsByIdList = System.Text.Json.JsonSerializer.Serialize(organizationCampaignsList);
                            return new OkObjectResult(responseCampaignsByIdList);

                        //Create a new campaign
                        //Checking if there is a name or a hashtag 
                        //Like the put in
                        case "addData":
                            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                            TBCampaigns userActivists = System.Text.Json.JsonSerializer.Deserialize<TBCampaigns>(requestBody);
                            if (userActivists.User_Id != null && userActivists.Campaigns_Name != null)
                            {

                                string CampaignName = MainManager.INSTANCE.CheckingTBCampaignsName(userActivists);
                                if (CampaignName != null)
                                {
                                    if (CampaignName.Contains("Exists")) return new OkObjectResult(CampaignName);
                                    else if (CampaignName.Contains("Not exists")) return new OkObjectResult(CampaignName);
                                }
                                else
                                {
                                    Console.WriteLine(CampaignName);
                                    return new OkObjectResult("The operation failed");
                                }
                            }
                            break;

                           //get a campaign with campaign ID 
                        case "getOneData":
                            MAboutCampaign ListAboutCampaign = MainManager.INSTANCE.GetMAboutCampaign(userId);
                            string responseMessageSA = System.Text.Json.JsonSerializer.Serialize(ListAboutCampaign);
                            Console.WriteLine(responseMessageSA);
                            return new OkObjectResult(responseMessageSA);

                        //Deleting a campaign using an ID
                        case "deleteData":

                            if (!(userId == null))
                            {
                                MainManager.INSTANCE.RemoveCampaign(userId);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");

                    }
                    break;

                    
                case "DonatedProducts":

                    switch (action)
                    {

                        //Receiving the products of a certain campaign according to ID
                        case "getData":

                            List<TBDonatedProducts> ListDonatedProducts = MainManager.INSTANCE.GetDonatedProducts(userId);
                            string responseMessageNP = System.Text.Json.JsonSerializer.Serialize(ListDonatedProducts);
                            Console.WriteLine(responseMessageNP);
                            return new OkObjectResult(responseMessageNP);


                        //Adding a new product
                        case "addData":

                            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                            TBDonatedProducts donatedProduct = System.Text.Json.JsonSerializer.Deserialize<TBDonatedProducts>(requestBody);
                            if (donatedProduct.Product_Name != null)
                            {
                                MainManager.INSTANCE.PostDonatedProduct(donatedProduct);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");

                    }
                    break;


                case "MoneyTracking":

                    switch (action)
                    {
                        //joining the campaign
                        //Adding the data into the table of the Money tracking
                        case "addTrack":

                            string requestBodyTrack = await new StreamReader(req.Body).ReadToEndAsync();
                            TBMoneyTracking moneyTracking = System.Text.Json.JsonSerializer.Deserialize<TBMoneyTracking>(requestBodyTrack);

                            if (moneyTracking != null)
                            {
                                MainManager.INSTANCE.PostMoneyTracking(moneyTracking);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");


                        //Receiving details from a money tracking table with social activist ID
                        case "getDataMoney":

                            List<MAMoneyTracking> ListMoneyTracking = MainManager.INSTANCE.GetMoneyTracking(userId);
                            string responseMessageList = System.Text.Json.JsonSerializer.Serialize(ListMoneyTracking);
                            Console.WriteLine(responseMessageList);
                            return new OkObjectResult(responseMessageList);

                    }
                    break;


                case "Shippers":

                    switch (action)
                    {
                        //Buying a product
                        //by getting an ID
                        //Checking whether it is possible to buy
                        //returns an answer accordingly
                        //If it can be bought, post about it on Twitter
                        case "buyProduct":

                            string requestBodyProductData = await new StreamReader(req.Body).ReadToEndAsync();
                            MAbuyProduct buyProduct = System.Text.Json.JsonSerializer.Deserialize<MAbuyProduct>(requestBodyProductData);

                            if (buyProduct != null)
                            {
                                string answer = MainManager.INSTANCE.BuyProduct(buyProduct);
                                if (answer == null) return new OkObjectResult("The operation failed");
                                if (answer.Contains("Succeeded"))
                                {
                                    var userClient = new TwitterClient(keys.ApiKey, keys.ApiKeySecret, keys.AccessToken, keys.AccessTokenSecret);
                                    await userClient.Users.GetAuthenticatedUserAsync();
                                    await userClient.Tweets.PublishTweetAsync($"A product number {buyProduct.DonatedProducts_Id} has been purchased on the website");
                                    return new OkObjectResult("The operation was carried out successfully, the package passes through the delivery person");
                                }
                                else if (answer.Contains("you do not have enough money")) return new OkObjectResult("We're sorry you don't have enough money for the product");
                                else if (answer.Contains("You are not following the campaign")) return new OkObjectResult("We are sorry, to buy the product you must join the campaign");
                                return new OkObjectResult("failedNotFollowing");
                            }
                            return new OkObjectResult("The operation failed");



                        //Receiving all the products of one social activist
                        //With receiving the activist id
                        case "getProductById":

                            List<TBDonatedProducts> ListDonatedProducts = MainManager.INSTANCE.GetUserProductsByUserId(userId);
                            string responseMessageNP = System.Text.Json.JsonSerializer.Serialize(ListDonatedProducts);
                            Console.WriteLine(responseMessageNP);
                            return new OkObjectResult(responseMessageNP);



                        //donation a product
                        //by getting an product ID
                        //Checking whether it is possible to donation
                        //returns an answer accordingly
                        case "donationProduct":

                            string requestBodyProductDataDonated = await new StreamReader(req.Body).ReadToEndAsync();
                            MAbuyProduct donationProduct = System.Text.Json.JsonSerializer.Deserialize<MAbuyProduct>(requestBodyProductDataDonated);

                            if (donationProduct != null)
                            {
                                string answer = MainManager.INSTANCE.DonationProduct(donationProduct);

                                if (answer.Contains("Succeeded")) return new OkObjectResult("The operation was carried out successfully,Thanks for the donation");
                                else if (answer.Contains("you do not have enough money")) return new OkObjectResult("We're sorry you don't have enough money for the product");
                                else if (answer.Contains("You are not following the campaign")) return new OkObjectResult("We are sorry, to donate a product you must join the campaign");

                                return new OkObjectResult("failedNotFollowing");
                            }
                            return new OkObjectResult("The operation failed");


                        //Receiving shipment tracking
                        case "getDeliveryList":

                            List<MADeliveryProductList> deliveryProductList = MainManager.INSTANCE.GetDeliveryDataProductList();
                            string responseMessageDL = System.Text.Json.JsonSerializer.Serialize(deliveryProductList);
                            Console.WriteLine(responseMessageDL);
                            return new OkObjectResult(responseMessageDL);


                        //With money tracking id 
                        //Sending the product
                        case "sendProduct":

                            MainManager.INSTANCE.SetDeliveryProduct(userId);
                            return new OkObjectResult("Succeeded");
                    }
                    break;


                case "Twitter":

                    switch (action)
                    {
                        //Taking all the users who are in financial monitoring
                        //Connecting to Twitter and checking all the tweets that were there during the previous day
                        //Check on each user how many times he posted and what
                        //Enter the amount of tweets of that campaign into the funds tracking
                        //Checking whether such a scan has already been done on the same day
                        //User input of tweet tracking table
                        case "getTweet":
                            bool answer = MainManager.INSTANCE.CheckingIfExistPosts();
                            if (answer)
                            {
                                List<MATwitter> userData = MainManager.INSTANCE.GetTwitterUserData();
                                if (userData == null) return new OkObjectResult("failedNotFollowing");
                                DateTime Yesterday = DateTime.Today.AddDays(-1);
                                DateTime currentDate = DateTime.Today;
                                string YesterdayDay = Yesterday.ToString("yyyy-MM-dd");
                                string currentDay = currentDate.ToString("yyyy-MM-dd");
                                string start_time = YesterdayDay + "T00:00:50Z";
                                string end_time = currentDay + "T00:00:00Z";

                                foreach (MATwitter user in userData)
                                {
                                    string url = $"https://api.twitter.com/2/tweets/search/recent?start_time={start_time}&end_time={end_time}&query=from:{user.Twitter_user}";
                                    var clientTwitter = new RestClient(url);
                                    var requestTwitter = new RestRequest("", Method.Get);
                                    requestTwitter.AddHeader("authorization", $"Bearer {keys.BearerToken}");
                                    var responseTwitter = clientTwitter.Execute(requestTwitter);
                                    if (responseTwitter.IsSuccessful)
                                    {
                                        JObject json = JObject.Parse(responseTwitter.Content);
                                        int tweetCount = 0;
                                        int resultCount = (int)json["meta"]["result_count"];
                                        if (resultCount != 0)
                                        {
                                            foreach (var tweet in json["data"])
                                            {
                                                if (tweet["text"].ToString().Contains(user.Hashtag))
                                                {
                                                    tweetCount++;
                                                }
                                            }
                                            Console.WriteLine(tweetCount);
                                            if (tweetCount != 0)
                                            {
                                                MainManager.INSTANCE.UpdateNewUserMoneyTracking(user, tweetCount);
                                            }
                                        }
                                    }
                                }
                            }

                            return new OkObjectResult("failedNotFollowing");

                    }
                    break;


                case "Reports":

                    //Receiving an option number
                    //Receiving a sorted class according to the option
                    switch (action)
                    {
                        case "byCampaign":
                            List<TBSortingCampaigns> ListSortingCampaigns = MainManager.INSTANCE.GetReportsCampaigns(userId);
                            string responseCampaignsList = System.Text.Json.JsonSerializer.Serialize(ListSortingCampaigns);
                            Console.WriteLine(responseCampaignsList);
                            return new OkObjectResult(responseCampaignsList);
                        

                        case "byPosts":
                            List<TBSortingPosts> ListSortingPosts = MainManager.INSTANCE.GetReportsPosts(userId);
                            string responsePostsList = System.Text.Json.JsonSerializer.Serialize(ListSortingPosts);
                            Console.WriteLine(responsePostsList);
                            return new OkObjectResult(responsePostsList);
                           

                        case "byProducts":
                            List<TBSortingProducts> ListSortingProducts = MainManager.INSTANCE.GetReportsProducts(userId);
                            string responseProductsList = System.Text.Json.JsonSerializer.Serialize(ListSortingProducts);
                            Console.WriteLine(responseProductsList);
                            return new OkObjectResult(responseProductsList);


                        case "byUsers":
                            List<TBSortingUsers> ListSortingUsers = MainManager.INSTANCE.GetReportsUsers(userId);
                            string responseUsersList = System.Text.Json.JsonSerializer.Serialize(ListSortingUsers);
                            Console.WriteLine(responseUsersList);
                            return new OkObjectResult(responseUsersList);

                    }
                    break;
            }
            return null;
        }
    }
}
