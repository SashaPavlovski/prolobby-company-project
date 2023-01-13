////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Campaigns.cs
//
// summary:	Implements the campaigns class
////////////////////////////////////////////////////////////////////////////////////////////////////

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

namespace ProLobbyCompanyProject.Entites
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A campaigns. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class Campaigns
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Campaigns() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets campaign name. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="Campaign"> The campaign. </param>
        ///
        /// <returns>   The campaign name. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the campaigns. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <returns>   The campaigns. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<TBCampaigns> GetCampaigns()
        {
            DSCampaignsGet dSCampaignsGet = new DSCampaignsGet();
            List<TBCampaigns> CampaignsList = dSCampaignsGet.GetCampaignList();
            return CampaignsList;


        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets about campaign. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="campaignId">   Identifier for the campaign. </param>
        ///
        /// <returns>   The about campaign. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MAboutCampaign GetAboutCampaign(string campaignId)
        {
            DSCampaignsGet dSCampaignsGet = new DSCampaignsGet();
            return dSCampaignsGet.GetDataAboutCampaign(campaignId);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes the campaign data described by campaignId. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="campaignId">   Identifier for the campaign. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void RemoveCampaignData(string campaignId)
        {
            DSCampaignsDelete dSCampaignsDelete = new DSCampaignsDelete();
            dSCampaignsDelete.DeleteDataCampaign(campaignId);
        }


    }

}
