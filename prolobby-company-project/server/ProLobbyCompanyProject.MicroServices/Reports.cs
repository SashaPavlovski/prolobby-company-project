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
using ProLobbyCompanyProject.Model.SortingTables.SortingCampaigns;
using ProLobbyCompanyProject.Model.SortingTables.SortingPosts;
using ProLobbyCompanyProject.Model.SortingTables.SortingProducts;
using ProLobbyCompanyProject.Model.SortingTables.SortingUsers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;

namespace ProLobbyCompanyProject.MicroServices
{
    public static class Reports
    {
        [FunctionName("Reports")]
        public static async Task<IActionResult> ReportsRunner(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "delete", "post", "put", Route= "Reports/{action}/{userId?}")] HttpRequest req, string action, string userId,
            ILogger log)
        {

            //Receiving an option number
            //Receiving a sorted class according to the option
            switch (action)
            {
                case "byCampaign":
                    List<TBSortingCampaigns> ListSortingCampaigns = MainManager.INSTANCE.NonProfitOrganizations.GetSortingCampaigns(userId);
                    string responseCampaignsList = System.Text.Json.JsonSerializer.Serialize(ListSortingCampaigns);
                    Console.WriteLine(responseCampaignsList);
                    return new OkObjectResult(responseCampaignsList);


                case "byPosts":
                    List<TBSortingPosts> ListSortingPosts = MainManager.INSTANCE.Twitter.GetSortingPosts(userId);
                    string responsePostsList = System.Text.Json.JsonSerializer.Serialize(ListSortingPosts);
                    Console.WriteLine(responsePostsList);
                    return new OkObjectResult(responsePostsList);


                case "byProducts":
                    List<TBSortingProducts> ListSortingProducts = MainManager.INSTANCE.BusinessCompanyRepresentatives.GetSortingProducts(userId);
                    string responseProductsList = System.Text.Json.JsonSerializer.Serialize(ListSortingProducts);
                    Console.WriteLine(responseProductsList);
                    return new OkObjectResult(responseProductsList);


                case "byUsers":
                    List<TBSortingUsers> ListSortingUsers = MainManager.INSTANCE.Twitter.GetSortingUsers(userId);
                    string responseUsersList = System.Text.Json.JsonSerializer.Serialize(ListSortingUsers);
                    Console.WriteLine(responseUsersList);
                    return new OkObjectResult(responseUsersList);

            }

            return new OkObjectResult("");
        }
    }
}
