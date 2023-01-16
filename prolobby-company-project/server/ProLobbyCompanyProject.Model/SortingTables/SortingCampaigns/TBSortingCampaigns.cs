using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Model.SortingTables.SortingCampaigns
{
    public class TBSortingCampaigns
    {
        public TBSortingCampaigns() { }
        public string Campaigns_Name { get; set; }
        public string NonProfitOrganizationName { get; set; }
        public double MoneyDonations { get; set; }
        public int ProductAmount { get; set; }
        public int ActivistAmount { get; set; }
        public DateTime Date { get; set; }
        public string Active { get; set; }
    }
}
