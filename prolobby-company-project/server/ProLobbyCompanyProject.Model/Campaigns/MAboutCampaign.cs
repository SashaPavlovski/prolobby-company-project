using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Model.Campaigns
{
    public class MAboutCampaign
    {
        public MAboutCampaign() { }
        public string NonProfitOrganizationName { get; set; }
        public string NonProfitOrganizationDecreption { get; set; }

        public string Url { get; set; }

        public int Campaigns_Id { get; set; }

        public string Campaigns_Name { get; set; }

        public string Hashtag { get; set; }

        public string CampaignsDescreption { get; set; }


    }
}
