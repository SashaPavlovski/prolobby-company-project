using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Model
{
    public class TBCampaigns
    {
        [Key]
        public int Campaigns_Id { get; set; }
        public int NonProfitOrganization_Id { get; set; }
        public string Campaigns_Name { get; set; }
        public string Hashtag { get; set; }
        public string Descreption { get; set; }

    }
}
