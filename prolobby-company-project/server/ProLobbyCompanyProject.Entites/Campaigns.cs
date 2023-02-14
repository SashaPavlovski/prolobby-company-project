using ProLobbyCompanyProject.Data.Sql.Campaigns;
using ProLobbyCompanyProject.Model;
using ProLobbyCompanyProject.Model.Campaigns;
using System.Collections.Generic;

// file:	Campaigns.cs
// summary:	Implements the campaigns class

namespace ProLobbyCompanyProject.Entites
{
    public partial class NonProfitOrganizations: BaseEntity
    {
        DSCampaignsGet dSCampaignsGet;
        DSCampaignsPost dSCampaignsPost;
        DSCampaignsByIdGet dSCampaignsByIdGet;
        DSCampaignsDelete dSCampaignsDelete;


        /// <summary>   Gets campaign name and Check if it exists. </summary>
        /// <returns>   The answer if it exists. </returns>
        public string GetCampaignName(TBCampaigns Campaign)
        {
            Logger.LogEvent("\n\nEnter into GetCampaignName function");

            if (Campaign != null)
            {
                List<TBCampaigns> CampaignsList = dSCampaignsGet.GetCampaignRow(Campaign);

                if (CampaignsList == null)
                {
                    int? answer = dSCampaignsPost.PostCampaignRow(Campaign);
                    if (answer != null && answer == -1) return "Exists";
                    else if (answer != null && answer == 1) return "Not exists";
                }
                else if (CampaignsList != null) return "Exists";
            }

            Logger.LogError("End GetCampaignName function and TBCampaigns class is null");

            return null;
        }

        /// <summary>   Gets the campaigns. </summary>
        /// <returns>   The campaigns. </returns>
        public List<TBCampaigns> GetCampaigns()
        {
            Logger.LogEvent("\n\nEnter into GetCampaigns function");

            List<TBCampaigns> CampaignsList = dSCampaignsGet.GetCampaignList();

            Logger.LogEvent("End GetCampaigns function");

            return CampaignsList;
        }

        /// <summary>   Gets about campaign. </summary>
        /// <param name="campaignId">   Identifier for the campaign. </param>
        /// <returns>   The about campaign. </returns>
        public MAboutCampaign GetAboutCampaign(string campaignId)
        {
            if (campaignId != null)
            {
                Logger.LogEvent("\n\nEnter into GetAboutCampaign function");

                return dSCampaignsGet.GetDataAboutCampaign(campaignId);
            }

            Logger.LogError("End GetAboutCampaign function ang get null in campaignId");

            return null;
        }

        /// <summary>   Removes the campaign data described by campaignId. </summary>
        /// <param name="campaignId">   Identifier for the campaign. </param>
        public void RemoveCampaignData(string campaignId)
        {
            Logger.LogEvent("\n\nEnter into RemoveCampaignData function");

            if (campaignId != null)
            {
                dSCampaignsDelete.DeleteDataCampaign(campaignId);

                Logger.LogEvent("End RemoveCampaignData function");

                return;
            }

            Logger.LogError("End RemoveCampaignData function and campaignId is null");

        }

        //Acceptance of the campaigns by id
        public List<TBCampaigns> GetByIdCampaigns(string organizationId)
        {
            Logger.LogEvent("\n\nEnter into GetByIdCampaigns function");

            if (organizationId != null)
            {
                List<TBCampaigns> CampaignsList = dSCampaignsByIdGet.GetCampaignsById(organizationId);

                Logger.LogEvent("End GetByIdCampaigns function");

                return CampaignsList;
            }

            Logger.LogError("End GetByIdCampaigns function and organizationId is null");

            return null;

        }
    }

}
