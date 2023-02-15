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
    public static class DonatedProducts
    {
        [FunctionName("DonatedProducts")]
        public static async Task<IActionResult> DonatedProductsRunner(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "delete", "post", "put", Route ="DonatedProducts/{action}/{userId?}")] HttpRequest req, string action, string userId,
            ILogger log)
        {
            MainManager.INSTANCE.Logger.LogEvent("\n\nStarting DonatedProducts function:");

            try
            {
                TBDonatedProducts User = null;

                string KeyCommand = $"DonatedProducts/{action}";

                if (req.ContentLength != null)
                {
                    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                    User = System.Text.Json.JsonSerializer.Deserialize<TBDonatedProducts>(requestBody);
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
