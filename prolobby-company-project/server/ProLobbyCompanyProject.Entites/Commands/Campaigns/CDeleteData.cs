using System;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.Campaigns
{
    public class CDeleteData: BaseCommands,ICommand
    {
        public CDeleteData(Logger logger) : base(logger) { }

        /// <summary>
        /// Deleting a campaign using an ID
        /// </summary>
        /// <param name="argv"> The id of the campaign. </param>
        /// <returns> Was the operation successful. </returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is string)
                {
                    string userId = (string)item;
                    
                    if (!(userId == null))
                    {
                        MainManager.INSTANCE.NonProfitOrganizations.RemoveCampaignData(userId);

                        base.Logger.LogEvent("The operation was successful in CDeleteData, the campaign has been deleted or has become inactive.");

                        return "The operation was successful";
                    }
                }
            }

            base.Logger.LogError("\nThe operation failed in CDeleteData, ID not received\n");

            return "The operation failed";
        }
        public void Init() { }
    }
}
