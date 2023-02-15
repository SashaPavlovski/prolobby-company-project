using ProLobbyCompanyProject.Model.SortingTables.SortingCampaigns;
using System;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.Reports
{
    public class RByCampaign: BaseCommands,ICommand
    {
        public RByCampaign(Logger logger) : base(logger) { }

        /// <summary>
        /// The campaign reports filtering by Id option.
        /// </summary>
        /// <param name="argv">Id option</param>
        /// <returns>Filtering campaign report.</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is string)
                {

                    string userId = (string)item;

                    List<TBSortingCampaigns> ListSortingCampaigns = MainManager.INSTANCE.NonProfitOrganizations.GetSortingCampaigns(userId);

                    string responseCampaignsList = System.Text.Json.JsonSerializer.Serialize(ListSortingCampaigns);

                    Console.WriteLine(responseCampaignsList);

                    base.Logger.LogEvent("The operation of sorting the campaign reports was carried out successfully in RByCampaign");

                    return responseCampaignsList;
                }
            }

            base.Logger.LogError("\nThe campaign report sorting operation failed, no sorting option was received in RByCampaign.\n");

            return null;
        }
        public void Init() { }
    }
}
