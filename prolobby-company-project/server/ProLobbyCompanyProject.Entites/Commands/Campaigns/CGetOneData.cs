using ProLobbyCompanyProject.Model.Campaigns;
using System;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.Campaigns
{
    public class CGetOneData: BaseCommands,ICommand
    {
        public CGetOneData(Logger logger) : base(logger) { }

        /// <summary>
        /// Get a campaign with campaign ID. 
        /// </summary>
        /// <param name="argv">campaign ID</param>
        /// <returns>Details about a specific campaign.</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is string)
                {
                    string userId = (string)item;

                    MAboutCampaign ListAboutCampaign = MainManager.INSTANCE.NonProfitOrganizations.GetAboutCampaign(userId);

                    string responseMessageSA = System.Text.Json.JsonSerializer.Serialize(ListAboutCampaign);

                    Console.WriteLine(responseMessageSA);

                    base.Logger.LogEvent("The operation of receiving the details of the campaign, if it exists, was carried out successfully in CGetOneData.");

                    return responseMessageSA;
                }
            }

            base.Logger.LogError("\nThe operation to get the details of the campaign if it exists, failed, no id was received in CGetOneData.\n");

            return null;
        }
        public void Init() { }
    }
}
