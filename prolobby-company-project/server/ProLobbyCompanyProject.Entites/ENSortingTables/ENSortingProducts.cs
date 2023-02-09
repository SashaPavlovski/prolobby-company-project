using ProLobbyCompanyProject.Data.Sql.BusinessCompanyRepresentatives;
using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Data.Sql.SortingTables.SortingProducts;
using ProLobbyCompanyProject.Model.SortingTables.SortingProducts;
using System.Collections.Generic;
using Utilities.Logger;
using ProLobbyCompanyProject.Data.Sql.Shippers;
using ProLobbyCompanyProject.Data.Sql.DonatedProducts;

namespace ProLobbyCompanyProject.Entites
{
    public partial class BusinessCompanyRepresentatives: BaseEntity
    {
        DSSortingProductsDefault dSSortingProductsDefault;

        public BusinessCompanyRepresentatives(Logger logger) : base(logger)
        {
            Logger.LogEvent("Enter into BusinessCompanyRepresentatives constructor and initialize classes");

            dSSortingProductsDefault = new DSSortingProductsDefault(base.Logger);
            dSUserData = new DSBusinessCompanyRepresentativesGet(base.Logger);
            usersComments = new DSBusinessCompanyRepresentativesPost(base.Logger);
            usersNewData = new DSBusinessCompanyRepresentativesUpdate(base.Logger);
            dSShippersBuy = new DSShippersBuy(base.Logger);
            dSShippersDonated = new DSShippersDonated(base.Logger);
            dsShippersDeliveryListGet = new DSShippersDeliveryListGet(base.Logger);
            dsShippersDeliveryProductSet = new DSShippersDeliveryProductSet(base.Logger);
            dSDonatedProductsGet = new DSDonatedProductsGet(base.Logger);
            newProduct = new DSDonatedProductsPost(base.Logger);
            dSDonatedProductsGetById = new DSDonatedProductsGetById(base.Logger);

            Logger.LogEvent("End initialize classes in BusinessCompanyRepresentatives constructor");

        }
        public List<TBSortingProducts> GetSortingProducts(string CaseOf)
        {
            Logger.LogEvent("Enter into GetSortingProducts function");

            Logger.LogEvent("Sorting the report table of the donated products");

            if (CaseOf == "1") return dSSortingProductsDefault.GetByDate();

            else if (CaseOf == "2") return dSSortingProductsDefault.GetByStatus();

            else if (CaseOf == "3") return dSSortingProductsDefault.GetByPrice();

            else if (CaseOf == "4") return dSSortingProductsDefault.GetByCampaignsName();

            else return null;
        }
    }
}
