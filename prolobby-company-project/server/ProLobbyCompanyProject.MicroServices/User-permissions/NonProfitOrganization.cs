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
    public static class NonProfitOrganization
    {
        [FunctionName("NonProfitOrganization")]
        public static async Task<IActionResult> NonProfitOrganizationRunner(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "delete", "post", "put", Route = "NonProfitOrganization/{action}/{userId?}")] HttpRequest req, string action, string userId,
            ILogger log)
        {

            //User login with enter details
            switch (action)
            {
                //Checks if the user exists
                case "userData":
                    List<TBNonProfitOrganization> ListNonProfitOrganization = MainManager.INSTANCE.NonProfitOrganizations.CheckingIfExistUser(userId);
                    string responseMessageNP = System.Text.Json.JsonSerializer.Serialize(ListNonProfitOrganization);
                    Console.WriteLine(responseMessageNP);
                    return new OkObjectResult(responseMessageNP);

                //Enters new data
                case "addData":

                    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                    TBNonProfitOrganization userOrganization = System.Text.Json.JsonSerializer.Deserialize<TBNonProfitOrganization>(requestBody);
                    if (userOrganization.Url != null && userOrganization.decreption != null && userOrganization.NonProfitOrganizationName != null && userOrganization.RepresentativeFirstName != null && userOrganization.RepresentativeLastName != null && userOrganization.User_Id != null)
                    {
                        MainManager.INSTANCE.NonProfitOrganizations.PostUsersOrganization(userOrganization);
                        return new OkObjectResult("The operation was successful");
                    }
                    return new OkObjectResult("The operation failed");



                //Updates the user's data
                case "updateData":

                    string requestOrganizationBody = await new StreamReader(req.Body).ReadToEndAsync();
                    TBNonProfitOrganization UserOrganizationData = System.Text.Json.JsonSerializer.Deserialize<TBNonProfitOrganization>(requestOrganizationBody);
                    if (UserOrganizationData.NonProfitOrganization_Id != 0 && UserOrganizationData.NonProfitOrganizationName != null && UserOrganizationData.RepresentativeLastName != null && UserOrganizationData.Email != null && UserOrganizationData.Phone_number != null && UserOrganizationData.RepresentativeFirstName != null && UserOrganizationData.decreption != null && UserOrganizationData.Url != null)
                    {
                        MainManager.INSTANCE.NonProfitOrganizations.UpdateActivist(UserOrganizationData);
                        return new OkObjectResult("The operation was successful");
                    }
                    return new OkObjectResult("The operation failed");


            }

            return new OkObjectResult("");
        }
    }
}
