using ProLobbyCompanyProject.Data.Sql.DonatedProducts;
using ProLobbyCompanyProject.Model;
using System.Collections.Generic;

// file:	DonatedProducts.cs
// summary:	Implements the donated products class

namespace ProLobbyCompanyProject.Entites
{
    public partial class BusinessCompanyRepresentatives: BaseEntity
    {

        /// <summary>   Gets campaign products. </summary>
        /// <param name="campaignId">   Identifier for the campaign. </param>
        /// <returns>   The campaign products. </returns>

        DSDonatedProductsGet dSDonatedProductsGet;
        DSDonatedProductsPost newProduct;
        DSDonatedProductsGetById dSDonatedProductsGetById;

        public List<TBDonatedProducts> GetCampaignProducts(string campaignId)
        {
            Logger.LogEvent("Enter into GetCampaignProducts function");

            if (campaignId == null)
            {
                return null;
            }

            List<TBDonatedProducts> GetProducts = dSDonatedProductsGet.GetProductsCampaign(campaignId);

            Logger.LogEvent("End GetCampaignProducts function");

            return GetProducts;
        }
        

        /// <summary>   Posts a product. </summary>
        /// <param name="donatedProduct">   The donated product. </param>

        public void PostProduct(TBDonatedProducts donatedProduct)
        {
            Logger.LogEvent("Enter into PostProduct function");

            newProduct.PostNewProduct(donatedProduct);

            Logger.LogEvent("End PostProduct function");

        }

        //Receiving all products of a user
        public List<TBDonatedProducts> GetByUserIdProducts(string userId)
        {
            Logger.LogEvent("Enter into GetByUserIdProducts function");

            List<TBDonatedProducts> DonatedProduct = dSDonatedProductsGetById.GetProductsByUserId(userId);

            Logger.LogEvent("End GetByUserIdProducts function");

            return DonatedProduct;
        }
    }
}
