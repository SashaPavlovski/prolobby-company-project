using ProLobbyCompanyProject.Data.Sql.SortingTables.SortingCampaigns;
using ProLobbyCompanyProject.Data.Sql.SortingTables.SortingProducts;
using ProLobbyCompanyProject.Model.SortingTables.SortingCampaigns;
using ProLobbyCompanyProject.Model.SortingTables.SortingProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites.ENSortingTables
{
    public class ENSortingProducts
    {
        public ENSortingProducts() { dSSortingProductsDefault = new DSSortingProductsDefault(); }
        DSSortingProductsDefault dSSortingProductsDefault;
        public List<TBSortingProducts> GetSortingProducts(string CaseOf)
        {
            if (CaseOf == "1") return dSSortingProductsDefault.GetByDate();

            else if (CaseOf == "2") return dSSortingProductsDefault.GetByStatus();

            else if (CaseOf == "3") return dSSortingProductsDefault.GetByPrice();

            else if (CaseOf == "4") return dSSortingProductsDefault.GetByProducts();

            else return null;
        }
    }
}
