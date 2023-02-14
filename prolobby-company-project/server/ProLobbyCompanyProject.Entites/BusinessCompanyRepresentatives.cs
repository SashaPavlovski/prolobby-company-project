using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Data.Sql.BusinessCompanyRepresentatives;
using ProLobbyCompanyProject.Data.Sql.DonatedProducts;
using ProLobbyCompanyProject.Data.Sql.Shippers;
using ProLobbyCompanyProject.Data.Sql.SortingTables.SortingProducts;
using ProLobbyCompanyProject.Model;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites
{
    public partial class BusinessCompanyRepresentatives: BaseEntity
    {
        
        DSBusinessCompanyRepresentativesGet dSUserData;
        DSBusinessCompanyRepresentativesPost usersComments;
        DSBusinessCompanyRepresentativesUpdate usersNewData;

        public BusinessCompanyRepresentatives(Logger logger) : base(logger)
        {
            Logger.LogEvent("\n\nEnter into BusinessCompanyRepresentatives constructor and initialize classes");

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


        /// <summary> Checking if exist user. </summary>
        /// <param name="UI">   The user interface. </param>
        public List<TBBusinessCompanyRepresentative> CheckingIfExistUser(string UI)
        {
            Logger.LogEvent("\n\nEnter into CheckingIfExistUser function");

            return dSUserData.GetBusinessCompanyUserRow(UI);
        }


        /// <summary>   Posts the users companys. </summary>
        /// <param name="userCompanyData">  Information describing the user company. </param>
        public void PostUsersCompanys(TBBusinessCompanyRepresentative userCompanyData)
        {
            Logger.LogEvent("\n\nEnter into PostUsersCompanys function");

            usersComments.PostUsersData(userCompanyData);

            Logger.LogEvent("End PostUsersCompanys function");

        }


        /// <summary>   Updates the activist described by updateUserData. </summary>
        /// <param name="updateUserData">   Information describing the update user. </param>
        public void UpdateActivist(TBBusinessCompanyRepresentative updateUserData)
        {
            Logger.LogEvent("\n\nEnter into UpdateActivist function");

            usersNewData.UpdateUsersData(updateUserData);

            Logger.LogEvent("End UpdateActivist function");

        }
    }
}
