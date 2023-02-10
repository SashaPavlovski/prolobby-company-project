using ProLobbyCompanyProject.Data.Sql.Shippers;
using ProLobbyCompanyProject.Model.Shippers;
using System.Collections.Generic;

namespace ProLobbyCompanyProject.Entites
{
    public partial class BusinessCompanyRepresentatives: BaseEntity
    {
        DSShippersBuy dSShippersBuy;
        DSShippersDonated dSShippersDonated;
        DSShippersDeliveryListGet dsShippersDeliveryListGet;
        DSShippersDeliveryProductSet dsShippersDeliveryProductSet;

        /// <summary>
        /// Buying a product by a social activist.
        /// </summary>
        /// <param name="productData"> Data on the operator. </param>
        /// <returns> 
        /// Operation done successfully,
        /// Not Enough Money,
        /// Did not join the campaign.
        /// </returns>
        public string BuyProduct(MAbuyProduct productData)
        {
            Logger.LogEvent("Enter into buyProduct function");

            if (productData == null)
            {
                Logger.LogError("The received MAbuyProduct class is not valid in BuyProduct function");

                return null;
            } 

            return dSShippersBuy.ActivistBuyProduct(productData);
        }

        /// <summary>
        /// Donation a product by a social activist.
        /// </summary>
        /// <param name="productData"> Data on the operator. </param>
        /// <returns> 
        /// Operation done successfully,
        /// Not Enough Money,
        /// Did not join the campaign.
        /// </returns>
        public string PostDonationProduct(MAbuyProduct productData)
        {
            Logger.LogEvent("Enter into PostDonationProduct function");

            if (productData == null)
            {
                Logger.LogError("The received MAbuyProduct class is not valid in PostDonationProduct function");

                return null;
            }

            return dSShippersDonated.PostDonatedProduct(productData);
        }

        /// <summary>
        /// Get delivery list
        /// </summary>
        /// <returns> List of Delivery data. </returns>
        public List<MADeliveryProductList> GetDeliveryList()
        {
            Logger.LogEvent("Enter into GetDeliveryList function");

            return dsShippersDeliveryListGet.GetDeliveryListProduct();
        }

        /// <summary>
        /// Updating the database on sending the product by the representative of a business company.
        /// </summary>
        /// <param name="idUser"> Shipper id - Data about the donated product and who bought it. </param>
        public void SetProductDelivery(string idUser)
        {
            Logger.LogEvent("Enter into SetProductDelivery function");

            if (idUser == null)
            {
                Logger.LogError("The received idUser is not valid in SetProductDelivery function");
            }

            dsShippersDeliveryProductSet.SendingDeliveryProduct(idUser);
        }
    }
}
