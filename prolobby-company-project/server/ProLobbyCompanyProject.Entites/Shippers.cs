////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Shippers.cs
//
// summary:	Implements the shippers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Data.Sql.MoneyTracking;
using ProLobbyCompanyProject.Data.Sql.Shippers;
using ProLobbyCompanyProject.Data.Sql.Twitter;
using ProLobbyCompanyProject.Model.MoneyTracking;
using ProLobbyCompanyProject.Model.Shippers;
using ProLobbyCompanyProject.Model.Twitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A shippers. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class Shippers
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Shippers() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts a product. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="productData">  Information describing the product. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string PostProduct(MAbuyProduct productData)
        {
            if (productData == null) return null;
            DSShippersBuy dSShippersBuy = new DSShippersBuy();
            return dSShippersBuy.PostProduct(productData);
        }

        public string PostDonationProduct(MAbuyProduct productData)
        {
            if (productData == null) return null;
            DSShippersDonated dSShippersDonated = new DSShippersDonated();
            return dSShippersDonated.PostDonatedProduct(productData);
        }

        public List<MADeliveryProductList> GetDeliveryList()
        {
            DSShippersDeliveryListGet dsShippersDeliveryListGet = new DSShippersDeliveryListGet();
            return dsShippersDeliveryListGet.GetDeliveryListProduct();
        }

        public void SetProductDelivery(string idUser)
        {
            DSShippersDeliveryProductSet dsShippersDeliveryProductSet = new DSShippersDeliveryProductSet();
            dsShippersDeliveryProductSet.SendingDeliveryProduct(idUser);
        }
    }
}
