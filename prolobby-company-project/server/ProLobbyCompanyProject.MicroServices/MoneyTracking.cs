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
using ProLobbyCompanyProject.Model.MoneyTracking;
using ProLobbyCompanyProject.Model;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;

namespace ProLobbyCompanyProject.MicroServices
{
    public static class MoneyTracking
    {
        [FunctionName("MoneyTracking")]
        public static async Task<IActionResult> MoneyTrackingRunner(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "delete", "post", "put", Route= "MoneyTracking/{action}/{userId?}")] HttpRequest req, string action, string userId,
            ILogger log)
        {
            switch (action)
            {
                //joining the campaign
                //Adding the data into the table of the Money tracking
                case "addTrack":

                    string requestBodyTrack = await new StreamReader(req.Body).ReadToEndAsync();
                    TBMoneyTracking moneyTracking = System.Text.Json.JsonSerializer.Deserialize<TBMoneyTracking>(requestBodyTrack);

                    if (moneyTracking != null)
                    {
                        MainManager.INSTANCE.SocialActivists.PostDataTracking(moneyTracking);
                        return new OkObjectResult("The operation was successful");
                    }
                    return new OkObjectResult("The operation failed");


                //Receiving details from a money tracking table with social activist ID
                case "getDataMoney":

                    List<MAMoneyTracking> ListMoneyTracking = MainManager.INSTANCE.SocialActivists.GetMoneyData(userId);
                    string responseMessageList = System.Text.Json.JsonSerializer.Serialize(ListMoneyTracking);
                    Console.WriteLine(responseMessageList);
                    return new OkObjectResult(responseMessageList);

            }
            return new OkObjectResult("");
        }
    }
}
