////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DonatedProducts.cs
//
// summary:	Implements the donated products class
////////////////////////////////////////////////////////////////////////////////////////////////////


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
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A donated products. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DonatedProducts
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DonatedProducts() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets campaign products. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="campaignId">   Identifier for the campaign. </param>
        ///
        /// <returns>   The campaign products. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<TBDonatedProducts> GetCampaignProducts(string campaignId)
        {
            if (campaignId == null) return null;
            DSDonatedProductsGet dSDonatedProductsGet = new DSDonatedProductsGet();
            return dSDonatedProductsGet.GetProductsCampaign(campaignId);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts a product. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="donatedProduct">   The donated product. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PostProduct(TBDonatedProducts donatedProduct)
        {
            DSDonatedProductsPost newProduct = new DSDonatedProductsPost();
            newProduct.PostNewProduct(donatedProduct);
        }

        public List<TBDonatedProducts>  GetByUserIdProducts (string userId)
        {
            DSDonatedProductsGetById dSDonatedProductsGetById = new DSDonatedProductsGetById();
            return dSDonatedProductsGetById.GetProductsByUserId(userId);

            
        }
    }
}
