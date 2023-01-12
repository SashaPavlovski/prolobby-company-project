using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Model.MoneyTracking
{
    public class MAMoneyTracking
    {
        public MAMoneyTracking() { }
        public string NonProfitOrganizationName { get; set; }
        public string Campaigns_Name { get; set; }
        public string Hashtag { get; set; }
        public double Accumulated_money { get; set; }
        public bool Active { get; set; }
    }
}
