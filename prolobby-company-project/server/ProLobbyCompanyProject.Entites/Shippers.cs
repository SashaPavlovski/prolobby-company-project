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

        public string PostProduct(MAbuyProduct productData)
        {
            Logger.LogEvent("Enter into PostProduct function");

            if (productData == null)
            {
                Logger.LogError("The received MAbuyProduct class is not valid in PostProduct function");

                return null;
            } 

            return dSShippersBuy.PostProduct(productData);
        }

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

        public List<MADeliveryProductList> GetDeliveryList()
        {
            Logger.LogEvent("Enter into GetDeliveryList function");

            return dsShippersDeliveryListGet.GetDeliveryListProduct();
        }

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
