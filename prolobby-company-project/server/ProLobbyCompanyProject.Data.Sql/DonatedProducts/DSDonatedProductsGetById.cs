using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.DonatedProducts
{
    public class DSDonatedProductsGetById
    {
        public DSDonatedProductsGetById() { }

        //Receiving item details
        //by the id of the social activist
        public object AddDonatedProductsByUserId(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            List<TBDonatedProducts> donatedProducts = new List<TBDonatedProducts>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    donatedProducts.Add(new TBDonatedProducts() { Product_Name = reader["Product_Name"].ToString(), Price = double.Parse(reader["Price"].ToString()),Active = bool.Parse(reader["Sent"].ToString()) });
                }
                return donatedProducts;
            }
            return null;
        }

        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            command.Parameters.AddWithValue($"@{key}", int.Parse(value));
        }


        string insertProductById = "if  exists (select * from [dbo].[TBShippers] where [SocialActivists_Id] = @SocialActivists_Id )\r\nbegin\r\n     select TB1.Product_Name,TB1.Price,TB2.Sent\r\n     from [dbo].[TBDonatedProducts] TB1 inner join [dbo].[TBShippers] TB2\r\n     on TB1.DonatedProducts_Id =  TB2.DonatedProducts_Id\r\n\t where TB2.SocialActivists_Id = @SocialActivists_Id\r\nend  ";

        //Moves the products using a list
        public List<TBDonatedProducts> GetProductsByUserId(string userId)
        {
            if (userId == null) return null;
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBDonatedProducts> DonatedProductsList = null;


            object listProducts = sqlQuery1.RunCommand(insertProductById, AddDonatedProductsByUserId, SetValues, "SocialActivists_Id", userId, null, null);

            if (listProducts is List<TBDonatedProducts>)
            {
                DonatedProductsList = (List<TBDonatedProducts>)listProducts;
            }
            return DonatedProductsList;
        }
    }
}
