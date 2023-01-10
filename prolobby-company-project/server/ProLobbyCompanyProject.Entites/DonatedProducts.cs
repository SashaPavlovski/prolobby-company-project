using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Data.Sql.DonatedProducts;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites
{
    public class DonatedProducts
    {
        public DonatedProducts() { }
        public List<TBDonatedProducts> GetCampaignProducts(string campaignId)
        {
            if (campaignId == null) return null;
            DSDonatedProductsGet dSDonatedProductsGet = new DSDonatedProductsGet();
            return dSDonatedProductsGet.GetProductsCampaign(campaignId);
        }
    }
}
