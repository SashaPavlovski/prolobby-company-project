//using System;
//using System.IO;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Azure.WebJobs;
//using Microsoft.Azure.WebJobs.Extensions.Http;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging;
//using ProLobbyCompanyProject.Entites;
//using ProLobbyCompanyProject.Model;
//using System.Collections.Generic;

//namespace ProLobbyCompanyProject.MicroServices.User_permissions
//{
//    public static class BusinessCompany
//    {
//        [FunctionName("BusinessCompany")]
//        public static async Task<IActionResult> BusinessCompanyRunner(
//            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "delete", "post", "put", Route = "BusinessCompanyRepresentative/{action}/{userId?}")] HttpRequest req, string action, string userId,
//            ILogger log)
//        {
//            switch (action)
//            {
//                //Checks if the user exists
//                case "userData":

//                    List<TBBusinessCompanyRepresentative> ListBusinessCompany = MainManager.INSTANCE.CheckingBusinessCompanyRepresentative(userId);
//                    string responseMessageLB = System.Text.Json.JsonSerializer.Serialize(ListBusinessCompany);
//                    Console.WriteLine(responseMessageLB);
//                    return new OkObjectResult(responseMessageLB);

//                //Enters new data 
//                case "addData":

//                    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
//                    TBBusinessCompanyRepresentative userCompany = System.Text.Json.JsonSerializer.Deserialize<TBBusinessCompanyRepresentative>(requestBody);
//                    if (userCompany.Url != null && userCompany.Email != null && userCompany.CompanyName != null && userCompany.RepresentativeFirstName != null && userCompany.RepresentativeLastName != null && userCompany.User_Id != null && userCompany.Phone_number != null)
//                    {
//                        MainManager.INSTANCE.PostNonProfitCompanyData(userCompany);
//                        return new OkObjectResult("The operation was successful");
//                    }
//                    return new OkObjectResult("The operation failed");

//                //Updates the user's data
//                case "updateData":

//                    string requestCompanyBody = await new StreamReader(req.Body).ReadToEndAsync();
//                    TBBusinessCompanyRepresentative UserCompanyData = System.Text.Json.JsonSerializer.Deserialize<TBBusinessCompanyRepresentative>(requestCompanyBody);
//                    if (UserCompanyData.BusinessCompany_Id != 0 && UserCompanyData.RepresentativeFirstName != null && UserCompanyData.RepresentativeLastName != null && UserCompanyData.CompanyName != null && UserCompanyData.Phone_number != null && UserCompanyData.Email != null)
//                    {
//                        MainManager.INSTANCE.UpdateBusinessCompanyData(UserCompanyData);
//                        return new OkObjectResult("The operation was successful");
//                    }
//                    return new OkObjectResult("The operation failed");

//            }
//            return null;
//        }
//    }
//}
