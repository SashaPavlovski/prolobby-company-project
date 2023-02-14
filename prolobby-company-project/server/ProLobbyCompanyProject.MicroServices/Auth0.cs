using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;
using ProLobbyCompanyProject.Model.Keys;

namespace ProLobbyCompanyProject.MicroServices
{
    public static class Auth0
    {
        [FunctionName("ProLobbyCompany")]
        public static async Task<IActionResult> ProLobbyCompanyRunner(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "delete", "post", "put", Route = "roles/{action}/{userId?}")] HttpRequest req, string action, string userId,
            ILogger log)
        {

                //Checking whether there is permission enter with auth0
                //If yes returns data on user

                    var urlGetRoles = $"https://dev-mluuahxjbvf524ap.us.auth0.com/api/v2/users/{userId}/roles";
                    var client = new RestClient(urlGetRoles);
                    var request = new RestRequest("", Method.Get);
                    request.AddHeader("authorization", $"Bearer {Keys.BearerTokenAuth0}");

                    var response = client.Execute(request);
                    if (response.IsSuccessful)
                    {
                        var json = JArray.Parse(response.Content);
                        return new OkObjectResult(json);
                    }
                    else return new NotFoundResult();
        }
    }
}