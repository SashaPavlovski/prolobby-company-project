using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using System;
using ProLobbyCompanyProject.Entites;

namespace ProLobbyCompanyProject.MicroServices
{
    public static class Auth0
    {
        [FunctionName("ProLobbyCompany")]
        public static async Task<IActionResult> ProLobbyCompanyRunner(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "delete", "post", "put", Route = "roles/{action}/{userId?}")] HttpRequest req, string action, string userId,
            ILogger log)
        {
            MainManager.INSTANCE.Logger.LogEvent("Starting auth0 Checking");

            //Checking whether there is permission enter with auth0
            //If yes returns data on user
            try
            {
                string BearerTokenAuth0 = MainManager.INSTANCE.ProLobbyOwner.TBKeys.BearerTokenAuth0;

                if (BearerTokenAuth0 != null)
                {
                    var urlGetRoles = $"https://dev-mluuahxjbvf524ap.us.auth0.com/api/v2/users/{userId}/roles";
                    var client = new RestClient(urlGetRoles);
                    var request = new RestRequest("", Method.Get);
                    request.AddHeader("authorization", $"Bearer {BearerTokenAuth0}");

                    var response = client.Execute(request);
                    if (response.IsSuccessful)
                    {
                        var json = JArray.Parse(response.Content);

                        MainManager.INSTANCE.Logger.LogEvent("The connection operation was successful to auth0");

                        return new OkObjectResult(json);
                    }
                    else
                    {
                        MainManager.INSTANCE.Logger.LogError("\nThe connection operation failed in auth0.\n");
                        return new BadRequestResult();//400
                    }
                }

                MainManager.INSTANCE.Logger.LogError("\nThe connection operation failed in auth0.\n");
                return new BadRequestResult();//400

            }
            catch (WebException Ex)
            {
                MainManager.INSTANCE.Logger.LogException(Ex.Message, Ex);
                return new BadRequestResult();//400
            }
            catch (Exception Ex)
            {
                MainManager.INSTANCE.Logger.LogException(Ex.Message, Ex);
                return new BadRequestResult();//400
            }
        }
    }
}