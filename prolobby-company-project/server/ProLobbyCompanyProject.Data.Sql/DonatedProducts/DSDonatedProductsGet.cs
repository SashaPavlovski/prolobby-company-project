using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.DonatedProducts
{
    public class DSDonatedProductsGet
    {
        public DSDonatedProductsGet() { }
        public object AddDonatedProducts(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            List<TBDonatedProducts> donatedProducts = new List<TBDonatedProducts>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    donatedProducts.Add(new TBDonatedProducts() {DonatedProducts_Id  = int.Parse(reader["DonatedProducts_Id"].ToString()),Product_Name = reader["Product_Name"].ToString() , Price = double.Parse(reader["Price"].ToString()) });
                }
                return donatedProducts;
            }
            return null;
        }

        string insertDonatedProducts = "if  exists (select * from [dbo].[TBDonatedProducts] where [Active] =1 and [Campaigns_Id] = @Campaigns_Id)\r\nbegin\r\n       select [Product_Name],[Price],[DonatedProducts_Id]\r\n\t   from [dbo].[TBDonatedProducts]\r\n\t   where [Active] = 1 and [Campaigns_Id] = @Campaigns_Id\r\nend";

        public List<TBDonatedProducts> GetProductsCampaign(string campaignId)
        {
            if (campaignId == null) return null;
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBDonatedProducts> DonatedProductsList = null;


            object listProducts = sqlQuery1.RunCommand(insertDonatedProducts, AddDonatedProducts, "Campaigns_Id", campaignId, null, null);

            if (listProducts is List<TBDonatedProducts>)
            {
                DonatedProductsList = (List<TBDonatedProducts>)listProducts;
            }
            return DonatedProductsList;
        }
    }
}
