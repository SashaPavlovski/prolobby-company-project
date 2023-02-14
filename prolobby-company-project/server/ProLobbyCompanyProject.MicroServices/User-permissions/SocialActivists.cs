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
using System.Collections.Generic;

namespace ProLobbyCompanyProject.MicroServices.User_permissions
{
    public static class SocialActivists
    {
        [FunctionName("SocialActivists")]
        public static async Task<IActionResult> SocialActivistsRunner(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "delete", "post", "put", Route = "SocialActivists/{action}/{userId?}")] HttpRequest req, string action, string userId,
            ILogger log)
        {

            //User login with enter details
            switch (action)
            {
                //Checks if the user exists
                case "userData":
                    List<TBSocialActivists> ListSocialActivists = MainManager.INSTANCE.SocialActivists.CheckingIfExistUser(userId);
                    string responseMessageSA = System.Text.Json.JsonSerializer.Serialize(ListSocialActivists);
                    Console.WriteLine(responseMessageSA);
                    return new OkObjectResult(responseMessageSA);

                //Enters new data
                case "addData":

                    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                    TBSocialActivists userActivists = System.Text.Json.JsonSerializer.Deserialize<TBSocialActivists>(requestBody);
                    if (userActivists.FirstName != null && userActivists.LastName != null && userActivists.Email != null && userActivists.Phone_number != null && userActivists.User_Id != null && userActivists.Address != null && userActivists.Twitter_user != null)
                    {
                        MainManager.INSTANCE.SocialActivists.PostUsersActivists(userActivists);
                        return new OkObjectResult("The operation was successful");
                    }
                    return new OkObjectResult("The operation failed");

                //Updates the user's data
                case "updateData":

                    string requestActivistsBody = await new StreamReader(req.Body).ReadToEndAsync();
                    TBSocialActivists UserActivistsData = System.Text.Json.JsonSerializer.Deserialize<TBSocialActivists>(requestActivistsBody);
                    if (UserActivistsData.SocialActivists_Id != 0 && UserActivistsData.FirstName != null && UserActivistsData.LastName != null && UserActivistsData.Email != null && UserActivistsData.Phone_number != null && UserActivistsData.Address != null && UserActivistsData.Twitter_user != null)
                    {
                        MainManager.INSTANCE.SocialActivists.UpdateActivist(UserActivistsData);
                        return new OkObjectResult("The operation was successful");
                    }
                    return new OkObjectResult("The operation failed");
            }

            return new OkObjectResult("");
        }
    }
}
