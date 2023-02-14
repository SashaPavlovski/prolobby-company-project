using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ProLobbyCompanyProject.Entites;
using ProLobbyCompanyProject.Model.Campaigns;
using ProLobbyCompanyProject.Model;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;

namespace ProLobbyCompanyProject.MicroServices
{
    public static class Campaigns
    {
        [FunctionName("Campaigns")]
        public static async Task<IActionResult> CampaignsRunner(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "delete", "post", "put", Route = "Campaigns/{action}/{userId?}")] HttpRequest req, string action, string userId,
            ILogger log)
        {
            switch (action)
            {
                // get all campaigns
                case "getData":

                    List<TBCampaigns> campaignList = MainManager.INSTANCE.NonProfitOrganizations.GetCampaigns();
                    string responseCampaignList = System.Text.Json.JsonSerializer.Serialize(campaignList);
                    return new OkObjectResult(responseCampaignList);


                // get campaigns by organization id 
                case "getDataById":

                    List<TBCampaigns> organizationCampaignsList = MainManager.INSTANCE.NonProfitOrganizations.GetByIdCampaigns(userId);
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

                        string CampaignName = MainManager.INSTANCE.NonProfitOrganizations.GetCampaignName(userActivists);
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
                    MAboutCampaign ListAboutCampaign = MainManager.INSTANCE.NonProfitOrganizations.GetAboutCampaign(userId);
                    string responseMessageSA = System.Text.Json.JsonSerializer.Serialize(ListAboutCampaign);
                    Console.WriteLine(responseMessageSA);
                    return new OkObjectResult(responseMessageSA);

                //Deleting a campaign using an ID
                case "deleteData":

                    if (!(userId == null))
                    {
                        MainManager.INSTANCE.NonProfitOrganizations.RemoveCampaignData(userId);
                        return new OkObjectResult("The operation was successful");
                    }
                    return new OkObjectResult("The operation failed");

            }
            return new OkObjectResult("");
        }
    }
}
