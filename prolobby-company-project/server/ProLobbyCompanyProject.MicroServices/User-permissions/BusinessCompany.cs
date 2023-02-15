using System;
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

namespace ProLobbyCompanyProject.MicroServices.User_permissions
{
    public static class BusinessCompany
    {
        [FunctionName("BusinessCompany")]
        public static async Task<IActionResult> BusinessCompanyRunner(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "delete", "post", "put", Route = "BusinessCompanyRepresentative/{action}/{userId?}")] HttpRequest req, string action, string userId,
            ILogger log)
        {
            MainManager.INSTANCE.Logger.LogEvent("\n\nStarting BusinessCompany function:");

            try
            {
                TBBusinessCompanyRepresentative userCompany = null;

                string KeyCommand = $"BusinessCompanyRepresentative/{action}";

                if (req.ContentLength != null)
                {
                    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                    userCompany = System.Text.Json.JsonSerializer.Deserialize<TBBusinessCompanyRepresentative>(requestBody);
                }

                ICommand Command = MainManager.INSTANCE.CommandsManager.CommandList[KeyCommand];

                object responseMessage = Command.Execute(userId, userCompany);

                if (responseMessage != null && responseMessage is string)
                {
                    string ResponseMessage = (string)responseMessage;
                    return new OkObjectResult(ResponseMessage);
                }

                return new BadRequestObjectResult("The operation failed, please contact the site administrator");//400

            }
            catch (Exception Ex)
            {
                MainManager.INSTANCE.Logger.LogException(Ex.Message, Ex);
                return new BadRequestObjectResult("The operation failed, please contact the site administrator");//400
            }
        }
    }
}
