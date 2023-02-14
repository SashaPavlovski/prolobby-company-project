using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProLobbyCompanyProject.Entites;
using ProLobbyCompanyProject.Model.Keys;
using ProLobbyCompanyProject.Model.Shippers;
using ProLobbyCompanyProject.Model;
using System.Collections.Generic;
using Tweetinvi;
using Microsoft.AspNetCore.Routing;

namespace ProLobbyCompanyProject.MicroServices
{
    public static class Shippers
    {
        [FunctionName("Shippers")]
        public static async Task<IActionResult> ShippersRunner(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "delete", "post", "put", Route= "Shippers/{action}/{userId?}")] HttpRequest req, string action, string userId,
            ILogger log)
        {
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
                        string answer = MainManager.INSTANCE.BusinessCompanyRepresentatives.BuyProduct(buyProduct);

                        if (answer == null) return new OkObjectResult("The operation failed");

                        if (answer.Contains("Succeeded"))
                        {
                            var userClient = new TwitterClient(Keys.ApiKey, Keys.ApiKeySecret, Keys.AccessToken, Keys.AccessTokenSecret);

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

                    List<TBDonatedProducts> ListDonatedProducts = MainManager.INSTANCE.BusinessCompanyRepresentatives.GetByUserIdProducts(userId);
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
                        string answer = MainManager.INSTANCE.BusinessCompanyRepresentatives.PostDonationProduct(donationProduct);

                        if (answer.Contains("Succeeded")) return new OkObjectResult("The operation was carried out successfully,Thanks for the donation");

                        else if (answer.Contains("you do not have enough money")) return new OkObjectResult("We're sorry you don't have enough money for the product");

                        else if (answer.Contains("You are not following the campaign")) return new OkObjectResult("We are sorry, to donate a product you must join the campaign");

                        return new OkObjectResult("failedNotFollowing");
                    }

                    return new OkObjectResult("The operation failed");


                //Receiving shipment tracking
                case "getDeliveryList":

                    List<MADeliveryProductList> deliveryProductList = MainManager.INSTANCE.BusinessCompanyRepresentatives.GetDeliveryList();
                    string responseMessageDL = System.Text.Json.JsonSerializer.Serialize(deliveryProductList);
                    Console.WriteLine(responseMessageDL);
                    return new OkObjectResult(responseMessageDL);


                //With money tracking id 
                //Sending the product
                case "sendProduct":

                    MainManager.INSTANCE.BusinessCompanyRepresentatives.SetProductDelivery(userId);
                    return new OkObjectResult("Succeeded");
            }

            return new OkObjectResult("");
        }
    }
}
