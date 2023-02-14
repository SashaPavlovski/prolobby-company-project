using ProLobbyCompanyProject.Data.Sql.SortingTables.SortingProducts;
using ProLobbyCompanyProject.Model.SortingTables.SortingProducts;
using System.Collections.Generic;

namespace ProLobbyCompanyProject.Entites
{
    public partial class BusinessCompanyRepresentatives: BaseEntity
    {
        DSSortingProductsDefault dSSortingProductsDefault;


        /// <summary>
        /// Get the reports by sorting.
        /// </summary>
        /// <param name="CaseOf"> Sort type from the client </param>
        /// <returns> list of reports by sorting. </returns>
        public List<TBSortingProducts> GetSortingProducts(string CaseOf)
        {
            Logger.LogEvent("\n\nEnter into GetSortingProducts function");

            Logger.LogEvent("Sorting the report table of the donated products");

            if (CaseOf == "1") return dSSortingProductsDefault.GetByDate();

            else if (CaseOf == "2") return dSSortingProductsDefault.GetByStatus();

            else if (CaseOf == "3") return dSSortingProductsDefault.GetByPrice();

            else if (CaseOf == "4") return dSSortingProductsDefault.GetByCampaignsName();

            else return null;
        }
    }
}
