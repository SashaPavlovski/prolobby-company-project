using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using ProLobbyCompanyProject.Entites;
using ProLobbyCompanyProject.Model;
using System.Collections.Generic;
using ProLobbyCompanyProject.Dal;
using System.Text.Json;
using System.Reflection.Metadata;
using System.Net;
using ProLobbyCompanyProject.Model.Campaigns;
using ProLobbyCompanyProject.Model.MoneyTracking;
using ProLobbyCompanyProject.Model.Shippers;
using ProLobbyCompanyProject.Model.Twitter;
using static System.Net.WebRequestMethods;
using Tweetinvi;

namespace ProLobbyCompanyProject.MicroServices
{
    public static class Auth0
    {
     // [System.Web.Mvc.HttpPost, ValidateAntiForgeryToken]
        [FunctionName("ProLobbyCompany")]
        public static async Task<IActionResult> ProLobbyCompanyRunner(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "delete", "post","put", Route = "{content}/{action}/{userId?}")] HttpRequest req, string content, string action, string userId,
            ILogger log)
        {

            switch (content)
            {
                case "roles":
                    var urlGetRoles = $"https://dev-mluuahxjbvf524ap.us.auth0.com/api/v2/users/{userId}/roles";
                    var client = new RestClient(urlGetRoles);
                    var request = new RestRequest("", Method.Get);
                    request.AddHeader("authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6Im5GWHNNbEloR2JBUUkyZDRmY2tpciJ9.eyJpc3MiOiJodHRwczovL2Rldi1tbHV1YWh4amJ2ZjUyNGFwLnVzLmF1dGgwLmNvbS8iLCJzdWIiOiJIcUFwSkJNTGdoTGhoTlk3SWFHbVhBZkNRWlI2UmMxc0BjbGllbnRzIiwiYXVkIjoiaHR0cHM6Ly9kZXYtbWx1dWFoeGpidmY1MjRhcC51cy5hdXRoMC5jb20vYXBpL3YyLyIsImlhdCI6MTY3MzAxMDI3MCwiZXhwIjoxNjc0MDEwMjcwLCJhenAiOiJIcUFwSkJNTGdoTGhoTlk3SWFHbVhBZkNRWlI2UmMxcyIsInNjb3BlIjoicmVhZDpjbGllbnRfZ3JhbnRzIGNyZWF0ZTpjbGllbnRfZ3JhbnRzIGRlbGV0ZTpjbGllbnRfZ3JhbnRzIHVwZGF0ZTpjbGllbnRfZ3JhbnRzIHJlYWQ6dXNlcnMgdXBkYXRlOnVzZXJzIGRlbGV0ZTp1c2VycyBjcmVhdGU6dXNlcnMgcmVhZDp1c2Vyc19hcHBfbWV0YWRhdGEgdXBkYXRlOnVzZXJzX2FwcF9tZXRhZGF0YSBkZWxldGU6dXNlcnNfYXBwX21ldGFkYXRhIGNyZWF0ZTp1c2Vyc19hcHBfbWV0YWRhdGEgcmVhZDp1c2VyX2N1c3RvbV9ibG9ja3MgY3JlYXRlOnVzZXJfY3VzdG9tX2Jsb2NrcyBkZWxldGU6dXNlcl9jdXN0b21fYmxvY2tzIGNyZWF0ZTp1c2VyX3RpY2tldHMgcmVhZDpjbGllbnRzIHVwZGF0ZTpjbGllbnRzIGRlbGV0ZTpjbGllbnRzIGNyZWF0ZTpjbGllbnRzIHJlYWQ6Y2xpZW50X2tleXMgdXBkYXRlOmNsaWVudF9rZXlzIGRlbGV0ZTpjbGllbnRfa2V5cyBjcmVhdGU6Y2xpZW50X2tleXMgcmVhZDpjb25uZWN0aW9ucyB1cGRhdGU6Y29ubmVjdGlvbnMgZGVsZXRlOmNvbm5lY3Rpb25zIGNyZWF0ZTpjb25uZWN0aW9ucyByZWFkOnJlc291cmNlX3NlcnZlcnMgdXBkYXRlOnJlc291cmNlX3NlcnZlcnMgZGVsZXRlOnJlc291cmNlX3NlcnZlcnMgY3JlYXRlOnJlc291cmNlX3NlcnZlcnMgcmVhZDpkZXZpY2VfY3JlZGVudGlhbHMgdXBkYXRlOmRldmljZV9jcmVkZW50aWFscyBkZWxldGU6ZGV2aWNlX2NyZWRlbnRpYWxzIGNyZWF0ZTpkZXZpY2VfY3JlZGVudGlhbHMgcmVhZDpydWxlcyB1cGRhdGU6cnVsZXMgZGVsZXRlOnJ1bGVzIGNyZWF0ZTpydWxlcyByZWFkOnJ1bGVzX2NvbmZpZ3MgdXBkYXRlOnJ1bGVzX2NvbmZpZ3MgZGVsZXRlOnJ1bGVzX2NvbmZpZ3MgcmVhZDpob29rcyB1cGRhdGU6aG9va3MgZGVsZXRlOmhvb2tzIGNyZWF0ZTpob29rcyByZWFkOmFjdGlvbnMgdXBkYXRlOmFjdGlvbnMgZGVsZXRlOmFjdGlvbnMgY3JlYXRlOmFjdGlvbnMgcmVhZDplbWFpbF9wcm92aWRlciB1cGRhdGU6ZW1haWxfcHJvdmlkZXIgZGVsZXRlOmVtYWlsX3Byb3ZpZGVyIGNyZWF0ZTplbWFpbF9wcm92aWRlciBibGFja2xpc3Q6dG9rZW5zIHJlYWQ6c3RhdHMgcmVhZDppbnNpZ2h0cyByZWFkOnRlbmFudF9zZXR0aW5ncyB1cGRhdGU6dGVuYW50X3NldHRpbmdzIHJlYWQ6bG9ncyByZWFkOmxvZ3NfdXNlcnMgcmVhZDpzaGllbGRzIGNyZWF0ZTpzaGllbGRzIHVwZGF0ZTpzaGllbGRzIGRlbGV0ZTpzaGllbGRzIHJlYWQ6YW5vbWFseV9ibG9ja3MgZGVsZXRlOmFub21hbHlfYmxvY2tzIHVwZGF0ZTp0cmlnZ2VycyByZWFkOnRyaWdnZXJzIHJlYWQ6Z3JhbnRzIGRlbGV0ZTpncmFudHMgcmVhZDpndWFyZGlhbl9mYWN0b3JzIHVwZGF0ZTpndWFyZGlhbl9mYWN0b3JzIHJlYWQ6Z3VhcmRpYW5fZW5yb2xsbWVudHMgZGVsZXRlOmd1YXJkaWFuX2Vucm9sbG1lbnRzIGNyZWF0ZTpndWFyZGlhbl9lbnJvbGxtZW50X3RpY2tldHMgcmVhZDp1c2VyX2lkcF90b2tlbnMgY3JlYXRlOnBhc3N3b3Jkc19jaGVja2luZ19qb2IgZGVsZXRlOnBhc3N3b3Jkc19jaGVja2luZ19qb2IgcmVhZDpjdXN0b21fZG9tYWlucyBkZWxldGU6Y3VzdG9tX2RvbWFpbnMgY3JlYXRlOmN1c3RvbV9kb21haW5zIHVwZGF0ZTpjdXN0b21fZG9tYWlucyByZWFkOmVtYWlsX3RlbXBsYXRlcyBjcmVhdGU6ZW1haWxfdGVtcGxhdGVzIHVwZGF0ZTplbWFpbF90ZW1wbGF0ZXMgcmVhZDptZmFfcG9saWNpZXMgdXBkYXRlOm1mYV9wb2xpY2llcyByZWFkOnJvbGVzIGNyZWF0ZTpyb2xlcyBkZWxldGU6cm9sZXMgdXBkYXRlOnJvbGVzIHJlYWQ6cHJvbXB0cyB1cGRhdGU6cHJvbXB0cyByZWFkOmJyYW5kaW5nIHVwZGF0ZTpicmFuZGluZyBkZWxldGU6YnJhbmRpbmcgcmVhZDpsb2dfc3RyZWFtcyBjcmVhdGU6bG9nX3N0cmVhbXMgZGVsZXRlOmxvZ19zdHJlYW1zIHVwZGF0ZTpsb2dfc3RyZWFtcyBjcmVhdGU6c2lnbmluZ19rZXlzIHJlYWQ6c2lnbmluZ19rZXlzIHVwZGF0ZTpzaWduaW5nX2tleXMgcmVhZDpsaW1pdHMgdXBkYXRlOmxpbWl0cyBjcmVhdGU6cm9sZV9tZW1iZXJzIHJlYWQ6cm9sZV9tZW1iZXJzIGRlbGV0ZTpyb2xlX21lbWJlcnMgcmVhZDplbnRpdGxlbWVudHMgcmVhZDphdHRhY2tfcHJvdGVjdGlvbiB1cGRhdGU6YXR0YWNrX3Byb3RlY3Rpb24gcmVhZDpvcmdhbml6YXRpb25zIHVwZGF0ZTpvcmdhbml6YXRpb25zIGNyZWF0ZTpvcmdhbml6YXRpb25zIGRlbGV0ZTpvcmdhbml6YXRpb25zIGNyZWF0ZTpvcmdhbml6YXRpb25fbWVtYmVycyByZWFkOm9yZ2FuaXphdGlvbl9tZW1iZXJzIGRlbGV0ZTpvcmdhbml6YXRpb25fbWVtYmVycyBjcmVhdGU6b3JnYW5pemF0aW9uX2Nvbm5lY3Rpb25zIHJlYWQ6b3JnYW5pemF0aW9uX2Nvbm5lY3Rpb25zIHVwZGF0ZTpvcmdhbml6YXRpb25fY29ubmVjdGlvbnMgZGVsZXRlOm9yZ2FuaXphdGlvbl9jb25uZWN0aW9ucyBjcmVhdGU6b3JnYW5pemF0aW9uX21lbWJlcl9yb2xlcyByZWFkOm9yZ2FuaXphdGlvbl9tZW1iZXJfcm9sZXMgZGVsZXRlOm9yZ2FuaXphdGlvbl9tZW1iZXJfcm9sZXMgY3JlYXRlOm9yZ2FuaXphdGlvbl9pbnZpdGF0aW9ucyByZWFkOm9yZ2FuaXphdGlvbl9pbnZpdGF0aW9ucyBkZWxldGU6b3JnYW5pemF0aW9uX2ludml0YXRpb25zIHJlYWQ6b3JnYW5pemF0aW9uc19zdW1tYXJ5IGNyZWF0ZTphY3Rpb25zX2xvZ19zZXNzaW9ucyBjcmVhdGU6YXV0aGVudGljYXRpb25fbWV0aG9kcyByZWFkOmF1dGhlbnRpY2F0aW9uX21ldGhvZHMgdXBkYXRlOmF1dGhlbnRpY2F0aW9uX21ldGhvZHMgZGVsZXRlOmF1dGhlbnRpY2F0aW9uX21ldGhvZHMiLCJndHkiOiJjbGllbnQtY3JlZGVudGlhbHMifQ.J9WoU0HLQLhT0d7l51VcJdj9eSaYf06aGKyXu9IJdOWCd38axv8er6EeHU5iV1jdzEU4NCmwYYkENaC7AsPZME2RJtqkky8LOpLS3dkUtQ-SSFcVAhFktI__Gl2OU-OEolKb0Gxyy0Gq-Gmn8YaoCQg1GtXkDcbzD3UtzAx2L1LaS2zWgVOQH67OO4JT8UYbFgY2xuWjDTRQA3GC48SzIrnpQf9sn04r8baYKLA0QTw57fOGNUF-gs3rO36hyKyyn1DXY9JB35QYqkuUGhw8o2D17ws60D7U6MdqovNqupH_6utXDwjGCnG9b_gw-d-HGp2U-K34sqro_3-N1UkZpQ");

                    var response = client.Execute(request);
                    if (response.IsSuccessful)
                    {
                        var json = JArray.Parse(response.Content);
                        return new OkObjectResult(json);
                    }
                    else return new NotFoundResult();


                case "BusinessCompanyRepresentative":
                    switch (action)
                    {
                        case "userData":

                            List<TBBusinessCompanyRepresentative> ListBusinessCompany = MainManager.INSTANCE.CheckingBusinessCompanyRepresentative(userId);
                            string responseMessageLB = System.Text.Json.JsonSerializer.Serialize(ListBusinessCompany);
                            Console.WriteLine(responseMessageLB);
                            return new OkObjectResult(responseMessageLB);

                        case "addData":

                            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                            TBBusinessCompanyRepresentative userCompany = System.Text.Json.JsonSerializer.Deserialize<TBBusinessCompanyRepresentative>(requestBody);
                            if (userCompany.Url != null && userCompany.Email != null && userCompany.CompanyName != null && userCompany.RepresentativeFirstName != null && userCompany.RepresentativeLastName != null && userCompany.User_Id != null && userCompany.Phone_number != null)
                            {
                                MainManager.INSTANCE.PostNonProfitCompanyData(userCompany);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");

                        case "updateData":

                            string requestCompanyBody = await new StreamReader(req.Body).ReadToEndAsync();
                            TBBusinessCompanyRepresentative UserCompanyData = System.Text.Json.JsonSerializer.Deserialize<TBBusinessCompanyRepresentative>(requestCompanyBody);
                            if (UserCompanyData.BusinessCompany_Id != 0 && UserCompanyData.RepresentativeFirstName != null && UserCompanyData.RepresentativeLastName != null && UserCompanyData.CompanyName != null && UserCompanyData.Phone_number != null && UserCompanyData.Email != null)
                            {
                                MainManager.INSTANCE.UpdateBusinessCompanyData(UserCompanyData);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");

                    }
                    break;



                case "ProLobbyOwner":
                    switch (action)
                    {
                        case "userData":
                            List<TBProLobbyOwner> ListProLobbyOwner = MainManager.INSTANCE.CheckingTBProLobbyOwner(userId);
                            string responseMessagePO = System.Text.Json.JsonSerializer.Serialize(ListProLobbyOwner);
                            Console.WriteLine(responseMessagePO);
                            return new OkObjectResult(responseMessagePO);
                            break;

                        case "addData":

                            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                            TBProLobbyOwner userOwner = System.Text.Json.JsonSerializer.Deserialize<TBProLobbyOwner>(requestBody);
                            if (userOwner.FirstName != null && userOwner.LastName != null && userOwner.Email != null && userOwner.Phone_number != null && userOwner.User_Id != null)
                            {
                                MainManager.INSTANCE.PostProLobbyOwnerData(userOwner);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");



                        case "updateData":

                            string requestOwnerBody = await new StreamReader(req.Body).ReadToEndAsync();
                            TBProLobbyOwner UserOwnerData = System.Text.Json.JsonSerializer.Deserialize<TBProLobbyOwner>(requestOwnerBody);
                            if (UserOwnerData.ProLobbyOwner_Id != 0 && UserOwnerData.FirstName != null && UserOwnerData.LastName != null && UserOwnerData.Email != null && UserOwnerData.Phone_number != null)
                            {
                                MainManager.INSTANCE.UpdateProLobbyOwnerData(UserOwnerData);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");
                    }
                    break;

                case "NonProfitOrganization":
                    switch (action)
                    {
                        case "userData":
                            List<TBNonProfitOrganization> ListNonProfitOrganization = MainManager.INSTANCE.CheckingTBNonProfitOrganization(userId);
                            string responseMessageNP = System.Text.Json.JsonSerializer.Serialize(ListNonProfitOrganization);
                            Console.WriteLine(responseMessageNP);
                            return new OkObjectResult(responseMessageNP);


                        case "addData":

                            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                            TBNonProfitOrganization userOrganization = System.Text.Json.JsonSerializer.Deserialize<TBNonProfitOrganization>(requestBody);
                            if (userOrganization.Url != null && userOrganization.decreption != null && userOrganization.NonProfitOrganizationName != null && userOrganization.RepresentativeFirstName != null && userOrganization.RepresentativeLastName != null && userOrganization.User_Id != null)
                            {
                                MainManager.INSTANCE.PostNonProfitOrganizationData(userOrganization);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");




                        case "updateData":

                            string requestOrganizationBody = await new StreamReader(req.Body).ReadToEndAsync();
                            TBNonProfitOrganization UserOrganizationData = System.Text.Json.JsonSerializer.Deserialize<TBNonProfitOrganization>(requestOrganizationBody);
                            if (UserOrganizationData.NonProfitOrganization_Id != 0 && UserOrganizationData.NonProfitOrganizationName != null && UserOrganizationData.RepresentativeLastName != null && UserOrganizationData.Email != null && UserOrganizationData.Phone_number != null && UserOrganizationData.RepresentativeFirstName != null && UserOrganizationData.decreption != null && UserOrganizationData.Url != null)
                            {
                                MainManager.INSTANCE.UpdateOrganizationData(UserOrganizationData);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");


                    }
                    break;

                case "SocialActivists":
                    switch (action)
                    {
                        case "userData":
                            List<TBSocialActivists> ListSocialActivists = MainManager.INSTANCE.CheckingTBSocialActivists(userId);
                            string responseMessageSA = System.Text.Json.JsonSerializer.Serialize(ListSocialActivists);
                            Console.WriteLine(responseMessageSA);
                            return new OkObjectResult(responseMessageSA);


                        case "addData":

                            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                            TBSocialActivists userActivists = System.Text.Json.JsonSerializer.Deserialize<TBSocialActivists>(requestBody);
                            if (userActivists.FirstName != null && userActivists.LastName != null && userActivists.Email != null && userActivists.Phone_number != null && userActivists.User_Id != null && userActivists.Address != null && userActivists.Twitter_user != null)
                            {
                                MainManager.INSTANCE.PostSocialActivistsData(userActivists);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");


                        case "updateData":

                            string requestActivistsBody = await new StreamReader(req.Body).ReadToEndAsync();
                            TBSocialActivists UserActivistsData = System.Text.Json.JsonSerializer.Deserialize<TBSocialActivists>(requestActivistsBody);
                            if (UserActivistsData.SocialActivists_Id != 0 && UserActivistsData.FirstName != null && UserActivistsData.LastName != null && UserActivistsData.Email != null && UserActivistsData.Phone_number != null && UserActivistsData.Address != null && UserActivistsData.Twitter_user != null)
                            {
                                MainManager.INSTANCE.UpdateSocialActivistsData(UserActivistsData);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");
                    }
                    break;

                case "Campaigns":
                    switch (action)
                    {
                        case "getData":

                            List<TBCampaigns> campaignList = MainManager.INSTANCE.GetTBCampaigns();
                            string responseCampaignList = System.Text.Json.JsonSerializer.Serialize(campaignList);
                            return new OkObjectResult(responseCampaignList);

                        case "getDataById":

                            List<TBCampaigns> organizationCampaignsList = MainManager.INSTANCE.GetCampaignsOrganizationById(userId);
                            string responseCampaignsByIdList = System.Text.Json.JsonSerializer.Serialize(organizationCampaignsList);
                            return new OkObjectResult(responseCampaignsByIdList);


                        case "addData":

                            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                            TBCampaigns userActivists = System.Text.Json.JsonSerializer.Deserialize<TBCampaigns>(requestBody);
                            if (userActivists.User_Id != null && userActivists.Campaigns_Name != null)
                            {

                                string CampaignName = MainManager.INSTANCE.CheckingTBCampaignsName(userActivists);
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


                        case "getOneData":
                            MAboutCampaign ListAboutCampaign = MainManager.INSTANCE.GetMAboutCampaign(userId);
                            string responseMessageSA = System.Text.Json.JsonSerializer.Serialize(ListAboutCampaign);
                            Console.WriteLine(responseMessageSA);
                            return new OkObjectResult(responseMessageSA);


                        case "deleteData":

                            if (!(userId == null))
                            {
                                MainManager.INSTANCE.RemoveCampaign(userId);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");

                    }
                    break;

                case "DonatedProducts":

                    switch (action)
                    {
                        case "getData":

                            List<TBDonatedProducts> ListDonatedProducts = MainManager.INSTANCE.GetDonatedProducts(userId);
                            string responseMessageNP = System.Text.Json.JsonSerializer.Serialize(ListDonatedProducts);
                            Console.WriteLine(responseMessageNP);
                            return new OkObjectResult(responseMessageNP);


                           
                        case "addData":

                            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                            TBDonatedProducts donatedProduct = System.Text.Json.JsonSerializer.Deserialize<TBDonatedProducts>(requestBody);
                            if (donatedProduct.Product_Name != null)
                            {
                                MainManager.INSTANCE.PostDonatedProduct(donatedProduct);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");

                    }
                    break;


                case "MoneyTracking":

                    switch (action)
                    {

                        case "addTrack":

                            string requestBodyTrack = await new StreamReader(req.Body).ReadToEndAsync();
                            TBMoneyTracking moneyTracking = System.Text.Json.JsonSerializer.Deserialize<TBMoneyTracking>(requestBodyTrack);

                            if (moneyTracking != null)
                            {
                                MainManager.INSTANCE.PostMoneyTracking(moneyTracking);
                                return new OkObjectResult("The operation was successful");
                            }
                            return new OkObjectResult("The operation failed");



                        case "getDataMoney":

                            List<MAMoneyTracking> ListMoneyTracking = MainManager.INSTANCE.GetMoneyTracking(userId);
                            string responseMessageList = System.Text.Json.JsonSerializer.Serialize(ListMoneyTracking);
                            Console.WriteLine(responseMessageList);
                            return new OkObjectResult(responseMessageList);

                    }
                    break;


                case "Shippers":

                    switch (action)
                    {

                        case "buyProduct":

                            string requestBodyProductData= await new StreamReader(req.Body).ReadToEndAsync();
                            MAbuyProduct buyProduct = System.Text.Json.JsonSerializer.Deserialize<MAbuyProduct>(requestBodyProductData);

                            if (buyProduct != null)
                            {
                                string anwer = MainManager.INSTANCE.BuyProduct(buyProduct);
                                if(anwer == null) return new OkObjectResult("The operation failed");
                                if (anwer.Contains("Succeeded")) {
                                    var userClient = new TwitterClient("36kPxWu2NiCOLPT0TIQWhSg6A", "ZBPV84cGVuTLKfOizWXqKxg5GkwYAz2yUmWaqzXKuQGz4UOIQc", "1613252594201247745-n1Vnhu76k9Qp9YsgoalMyppKnQx1NA", "955oQxhXL3HRHZxxfaxs5kXSEwJwipYUJSlErnZ8c0rVU");
                                    await userClient.Users.GetAuthenticatedUserAsync();
                                    await userClient.Tweets.PublishTweetAsync($"A product number {buyProduct.DonatedProducts_Id} has been purchased on the website");
                                    return new OkObjectResult("The operation was carried out successfully, the package passes through the delivery person"); 
                                }
                                else if (anwer.Contains("you do not have enough money")) return new OkObjectResult("We're sorry you don't have enough money for the product");
                                else if (anwer.Contains("You are not following the campaign")) return new OkObjectResult("We are sorry, to buy the product you must join the campaign");
                                return new OkObjectResult("failedNotFollowing");
                            }
                            return new OkObjectResult("The operation failed");


                        case "getProductById":

                            List<TBDonatedProducts> ListDonatedProducts = MainManager.INSTANCE.GetUserProductsByUserId(userId);
                            string responseMessageNP = System.Text.Json.JsonSerializer.Serialize(ListDonatedProducts);
                            Console.WriteLine(responseMessageNP);
                            return new OkObjectResult(responseMessageNP);

                        case "donationProduct":

                            string requestBodyProductDataDonated = await new StreamReader(req.Body).ReadToEndAsync();
                            MAbuyProduct donationProduct = System.Text.Json.JsonSerializer.Deserialize<MAbuyProduct>(requestBodyProductDataDonated);

                            if (donationProduct != null)
                            {
                                string anwer = MainManager.INSTANCE.DonationProduct(donationProduct);

                                if (anwer.Contains("Succeeded")) return new OkObjectResult("The operation was carried out successfully,Thanks for the donation");
                                else if (anwer.Contains("you do not have enough money")) return new OkObjectResult("We're sorry you don't have enough money for the product");
                                else if (anwer.Contains("You are not following the campaign")) return new OkObjectResult("We are sorry, to donate a product you must join the campaign");

                                return new OkObjectResult("failedNotFollowing");
                            }
                            return new OkObjectResult("The operation failed");
                           


                        case "getDeliveryList":

                            List<MADeliveryProductList> deliveryProductList = MainManager.INSTANCE.GetDeliveryDataProductList();
                            string responseMessageDL = System.Text.Json.JsonSerializer.Serialize(deliveryProductList);
                            Console.WriteLine(responseMessageDL);
                            return new OkObjectResult(responseMessageDL);
                       
                        case "sendProduct":

                            MainManager.INSTANCE.SetDeliveryProduct(userId);
                            return new OkObjectResult("Succeeded");
                    }
                    break;


                case "Twitter":

                    switch (action)
                    {
                        case "getTweet":

                            List<MATwitter> userData = MainManager.INSTANCE.GetTwitterUserData();
                            if(userData == null)  return new OkObjectResult("failedNotFollowing"); 
                            DateTime Yesterday = DateTime.Today.AddDays(-1);
                            DateTime currentDate = DateTime.Today;
                            string YesterdayDay = Yesterday.ToString("yyyy-MM-dd");
                            string currentDay = currentDate.ToString("yyyy-MM-dd");
                            string start_time = YesterdayDay + "T00:00:50Z";
                            string end_time = currentDay + "T00:00:00Z";
 
                            foreach (MATwitter user in userData)
                            {
                                string url = $"https://api.twitter.com/2/tweets/search/recent?start_time={start_time}&end_time={end_time}&query=from:{user.Twitter_user}";
                                var clientTwitter = new RestClient(url);
                                var requestTwitter = new RestRequest("", Method.Get);
                                requestTwitter.AddHeader("authorization", "Bearer AAAAAAAAAAAAAAAAAAAAAIKmlAEAAAAAi4dUwLeoayKuJvRAVvp99%2BNVzXQ%3DSoycLC7ReE1jcWXN4roMBNMjGVuko4HGREzxjtuX3X9kZwzylW");
                                var responseTwitter = clientTwitter.Execute(requestTwitter);
                                if (responseTwitter.IsSuccessful)
                                {
                                    JObject json = JObject.Parse(responseTwitter.Content);
                                    int tweetCount = 0;
                                    int resultCount = (int)json["meta"]["result_count"];
                                    if (resultCount != 0)
                                    {
                                        foreach (var tweet in json["data"])
                                        {
                                            if (tweet["text"].ToString().Contains(user.Hashtag))
                                            {
                                                tweetCount++;
                                            }
                                        }
                                        Console.WriteLine(tweetCount);
                                        MainManager.INSTANCE.UpdateNewUserMoneyTracking(user, tweetCount);
                                    }
                                }
                            }
                                return new OkObjectResult("failedNotFollowing");
                            
                    }
                    break;
            }

                    return null;
        }
    }
}
