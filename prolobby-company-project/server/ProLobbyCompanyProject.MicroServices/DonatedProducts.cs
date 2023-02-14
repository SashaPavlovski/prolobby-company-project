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
using ProLobbyCompanyProject.Model;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;

namespace ProLobbyCompanyProject.MicroServices
{
    public static class DonatedProducts
    {
        [FunctionName("DonatedProducts")]
        public static async Task<IActionResult> DonatedProductsRunner(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "delete", "post", "put", Route ="DonatedProducts/{action}/{userId?}")] HttpRequest req, string action, string userId,
            ILogger log)
        {
            switch (action)
            {

                //Receiving the products of a certain campaign according to ID
                case "getData":

                    List<TBDonatedProducts> ListDonatedProducts = MainManager.INSTANCE.BusinessCompanyRepresentatives.GetCampaignProducts(userId);
                    string responseMessageNP = System.Text.Json.JsonSerializer.Serialize(ListDonatedProducts);
                    Console.WriteLine(responseMessageNP);
                    return new OkObjectResult(responseMessageNP);


                //Adding a new product
                case "addData":

                    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                    TBDonatedProducts donatedProduct = System.Text.Json.JsonSerializer.Deserialize<TBDonatedProducts>(requestBody);
                    if (donatedProduct.Product_Name != null)
                    {
                        MainManager.INSTANCE.BusinessCompanyRepresentatives.PostProduct(donatedProduct);
                        return new OkObjectResult("The operation was successful");
                    }
                    return new OkObjectResult("The operation failed");

            }
            return new OkObjectResult("");
        }
    }
}
