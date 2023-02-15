using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.Campaigns
{
    public class CGetData : BaseCommands,ICommand
    {
        public CGetData(Logger logger) : base(logger) { }

        /// <summary>
        /// Get all campaigns.
        /// </summary>
        /// <param name="argv"></param>
        /// <returns>Returning the campaigns if they exist. </returns>
        public object Execute(params object[] argv)
        {
            List<TBCampaigns> campaignList = MainManager.INSTANCE.NonProfitOrganizations.GetCampaigns();

            string responseCampaignList = System.Text.Json.JsonSerializer.Serialize(campaignList);

            base.Logger.LogEvent("The operation of taking the campaigns was performed successfully");

            return responseCampaignList;
        }
       
        public void Init() { }
    }
}
