using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
   
        public DateTime Date { get { return DateTime.Now; } set { } }

        public bool Active { get { return true; } set {  } }
        public string User_Id { get; set; }
        public double MoneyDonations { get { return 0; } set { } }


    }
}

