
using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Data.Sql.Campaigns;
using ProLobbyCompanyProject.Data.Sql.DonatedProducts;
using ProLobbyCompanyProject.Data.Sql.MoneyTracking;
using ProLobbyCompanyProject.Model;
using ProLobbyCompanyProject.Model.Campaigns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// file:	Campaigns.cs
// summary:	Implements the campaigns class

namespace ProLobbyCompanyProject.Entites
{
    public class Campaigns
    {

        public Campaigns() { }


        /// <summary>   Gets campaign name and Check if it exists. </summary>
        /// <returns>   The answer if it exists. </returns>

        public string GetCampaignName(TBCampaigns Campaign)
        {
            DSCampaignsGet dSCampaignsGet = new DSCampaignsGet();
            DSCampaignsPost dSCampaignsPost = new DSCampaignsPost();
            List<TBCampaigns> CampaignsList = dSCampaignsGet.GetCampaignRow(Campaign);


            if (CampaignsList == null)
            {
                int? answer = dSCampaignsPost.PostCampaignRow(Campaign);
                if (answer != null && answer == -1) return "Exists";
                else if (answer != null && answer == 1) return "Not exists";
            }
            else if (CampaignsList != null) return "Exists";

            return null;

        }

        /// <summary>   Gets the campaigns. </summary>
        /// <returns>   The campaigns. </returns>
        public List<TBCampaigns> GetCampaigns()
        {
            DSCampaignsGet dSCampaignsGet = new DSCampaignsGet();
            List<TBCampaigns> CampaignsList = dSCampaignsGet.GetCampaignList();
            return CampaignsList;

        }

        /// <summary>   Gets about campaign. </summary>
        /// <param name="campaignId">   Identifier for the campaign. </param>
        /// <returns>   The about campaign. </returns>
        public MAboutCampaign GetAboutCampaign(string campaignId)
        {
            DSCampaignsGet dSCampaignsGet = new DSCampaignsGet();
            return dSCampaignsGet.GetDataAboutCampaign(campaignId);
        }

        /// <summary>   Removes the campaign data described by campaignId. </summary>
        /// <param name="campaignId">   Identifier for the campaign. </param>
        public void RemoveCampaignData(string campaignId)
        {
            DSCampaignsDelete dSCampaignsDelete = new DSCampaignsDelete();
            dSCampaignsDelete.DeleteDataCampaign(campaignId);
        }

        //Acceptance of the campaigns by id
        public List<TBCampaigns> GetByIdCampaigns(string organizationId)
        {
            DSCampaignsByIdGet dSCampaignsByIdGet = new DSCampaignsByIdGet();
            List<TBCampaigns> CampaignsList = dSCampaignsByIdGet.GetCampaignsById(organizationId);
            return CampaignsList;
        }
    }

}
