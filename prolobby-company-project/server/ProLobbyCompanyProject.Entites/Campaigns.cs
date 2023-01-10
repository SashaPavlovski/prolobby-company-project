using ProLobbyCompanyProject.Data.Sql.Campaigns;
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
    public class Campaigns
    {
        public Campaigns() { }
        public string GetCampaignName(TBCampaigns Campaign)
        {
            DSCampaignsGet dSCampaignsGet = new DSCampaignsGet();
            DSCampaignsPost dSCampaignsPost = new DSCampaignsPost();
            List<TBCampaigns> CampaignsList = dSCampaignsGet.GetCampaignRow(Campaign);


            if (CampaignsList == null) {
                int? answer = dSCampaignsPost.PostCampaignRow(Campaign);
                if (answer != null && answer == -1) return "Exists";
                else if (answer != null && answer == 1) return "Not exists";
            }else if (CampaignsList != null) return "Exists";
 
            return null;

        }

        public List<TBCampaigns> GetCampaigns()
        {
            DSCampaignsGet dSCampaignsGet = new DSCampaignsGet();
            List<TBCampaigns> CampaignsList = dSCampaignsGet.GetCampaignList();
            return CampaignsList;


        }
        public MAboutCampaign GetAboutCampaign(string campaignId) {
            DSCampaignsGet dSCampaignsGet = new DSCampaignsGet();
            return dSCampaignsGet.GetDataAboutCampaign(campaignId);
        }

        public void RemoveCampaignData (string campaignId)
        {
            DSCampaignsDelete dSCampaignsDelete = new DSCampaignsDelete();
            dSCampaignsDelete.DeleteDataCampaign(campaignId);
        }
    }
    
}
