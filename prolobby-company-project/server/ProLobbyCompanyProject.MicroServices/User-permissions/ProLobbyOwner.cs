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

namespace ProLobbyCompanyProject.MicroServices.User_permissions
{
    public static class ProLobbyOwner
    {
        [FunctionName("ProLobbyOwner")]
        public static async Task<IActionResult> ProLobbyOwnerRunner(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "delete", "post", "put", Route = "ProLobbyOwner/{action}/{userId?}")] HttpRequest req, string action, string userId,
            ILogger log)
        {

            //User login with enter details
            switch (action)
            {
                //Checks if the user exists
                case "userData":
                    List<TBProLobbyOwner> ListProLobbyOwner = MainManager.INSTANCE.ProLobbyOwner.CheckingIfExistUser(userId);
                    string responseMessagePO = System.Text.Json.JsonSerializer.Serialize(ListProLobbyOwner);
                    Console.WriteLine(responseMessagePO);
                    return new OkObjectResult(responseMessagePO);

                //Enters new data
                case "addData":

                    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                    TBProLobbyOwner userOwner = System.Text.Json.JsonSerializer.Deserialize<TBProLobbyOwner>(requestBody);
                    if (userOwner.FirstName != null && userOwner.LastName != null && userOwner.Email != null && userOwner.Phone_number != null && userOwner.User_Id != null)
                    {
                        MainManager.INSTANCE.ProLobbyOwner.PostUsersOwner(userOwner);
                        return new OkObjectResult("The operation was successful");
                    }
                    return new OkObjectResult("The operation failed");


                //Updates the user's data
                case "updateData":

                    string requestOwnerBody = await new StreamReader(req.Body).ReadToEndAsync();
                    TBProLobbyOwner UserOwnerData = System.Text.Json.JsonSerializer.Deserialize<TBProLobbyOwner>(requestOwnerBody);
                    if (UserOwnerData.ProLobbyOwner_Id != 0 && UserOwnerData.FirstName != null && UserOwnerData.LastName != null && UserOwnerData.Email != null && UserOwnerData.Phone_number != null)
                    {
                        MainManager.INSTANCE.ProLobbyOwner.UpdateUsersOwner(UserOwnerData);
                        return new OkObjectResult("The operation was successful");
                    }
                    return new OkObjectResult("The operation failed");
            }

            return new OkObjectResult("");
        }
    }
}
