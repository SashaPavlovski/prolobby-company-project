using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.Campaigns
{
    public class CGetDataById: BaseCommands,ICommand
    {
        public CGetDataById(Logger logger) : base(logger) { }

        /// <summary>
        /// Get campaigns by organization id 
        /// </summary>
        /// <param name="argv">organization id</param>
        /// <returns>The campaigns of a particular organization if they exist</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is string)
                {
                    string userId = (string)item;

                    List<TBCampaigns> organizationCampaignsList = MainManager.INSTANCE.NonProfitOrganizations.GetByIdCampaigns(userId);

                    string responseCampaignsByIdList = System.Text.Json.JsonSerializer.Serialize(organizationCampaignsList);

                    base.Logger.LogEvent("The operation of receiving the campaigns of a certain organization, if they exist was successfully performed");

                    return responseCampaignsByIdList;
                }
            }
            base.Logger.LogError("\nReceiving the campaigns of a certain organization failed, no id received\n");

            return null;
        }
        public void Init() { }
    }
}
