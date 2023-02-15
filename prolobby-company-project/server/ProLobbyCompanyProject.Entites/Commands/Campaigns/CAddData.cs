using ProLobbyCompanyProject.Model;
using System;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.Campaigns
{
    public class CAddData: BaseCommands,ICommand
    {
        public CAddData (Logger logger): base(logger) { }

        /// <summary>
        /// Create a new campaign
        /// Checking if there is a name or a hashtag 
        /// If not save it
        /// </summary>
        /// <param name="argv"> Getting all the details of the campaign. </param>
        /// <returns> Whether it exists or not. </returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is TBCampaigns)
                {
                    TBCampaigns userActivists = (TBCampaigns)item;

                    if (userActivists.User_Id != null && userActivists.Campaigns_Name != null)
                    {
                        string CampaignName = MainManager.INSTANCE.NonProfitOrganizations.GetCampaignName(userActivists);

                        if (CampaignName != null)
                        {
                            base.Logger.LogError("The operation of checking and saving if it does not exist was performed successfully in CAddData.");
                            if (CampaignName.Contains("Exists")) return CampaignName;
                            else if (CampaignName.Contains("Not exists")) return CampaignName;
                        }
                        else
                        {
                            base.Logger.LogError("\nNo details were received for the campaign, the operation failed in CAddData\n");

                            Console.WriteLine(CampaignName);
                            return "The operation failed";
                        }
                    }

                }
            }
            base.Logger.LogError("\nNo details were received for the campaign, the operation failed in CAddData\n");

            return "The operation failed";
        }
        public void Init() { }
    }
}
