using ProLobbyCompanyProject.Data.Sql.Shippers;
using ProLobbyCompanyProject.Model.Shippers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites
{
    public class Shippers
    {
        public Shippers() { }

        public string PostProduct (MAbuyProduct productData)
        {
            if (productData == null) return null;
            DSShippersBuy dSShippersBuy = new DSShippersBuy();
            return dSShippersBuy.PostDonatedProduct(productData);
        }
    }
}
