using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ProLobbyCompanyProject.Entites;
using ProLobbyCompanyProject.Model;
using ProLobbyCompanyProject.Entites.Commands;

namespace ProLobbyCompanyProject.MicroServices
{
    public static class Campaigns
    {
        [FunctionName("Campaigns")]
        public static async Task<IActionResult> CampaignsRunner(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "delete", "post", "put", Route = "Campaigns/{action}/{userId?}")] HttpRequest req, string action, string userId,
            ILogger log)
        {
            MainManager.INSTANCE.Logger.LogEvent("\n\nStarting Campaigns function:");

            try
            {
                TBCampaigns User = null;

                string KeyCommand = $"Campaigns/{action}";

                if (req.ContentLength != null)
                {
                    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                    User = System.Text.Json.JsonSerializer.Deserialize<TBCampaigns>(requestBody);
                }

                ICommand Command = MainManager.INSTANCE.CommandsManager.CommandList[KeyCommand];

                object responseMessage = Command.Execute(userId, User);

                if (responseMessage != null && responseMessage is string)
                {
                    string ResponseMessage = (string)responseMessage;

                    return new OkObjectResult(ResponseMessage);
                }

                return new BadRequestObjectResult("The operation failed, please contact the site administrator");//400

            }
            catch (System.Exception Ex)
            {
                MainManager.INSTANCE.Logger.LogException(Ex.Message, Ex);
                return new BadRequestObjectResult("The operation failed, please contact the site administrator");//400
            }
        }
    }
}
