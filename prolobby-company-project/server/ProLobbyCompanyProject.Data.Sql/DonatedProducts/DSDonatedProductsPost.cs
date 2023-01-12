using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.DonatedProducts
{
    public class DSDonatedProductsPost
    {
        public DSDonatedProductsPost() { }

        public void AddUserData(object newProduct, System.Data.SqlClient.SqlCommand command)
        {
            if (newProduct is TBDonatedProducts)
            {
                TBDonatedProducts donatedProducts = (TBDonatedProducts)newProduct;

                command.Parameters.AddWithValue("@BusinessCompany_Id", donatedProducts.BusinessCompany_Id);
                command.Parameters.AddWithValue("@Campaigns_Id", donatedProducts.Campaigns_Id);
                command.Parameters.AddWithValue("@Product_Name", donatedProducts.Product_Name);
                command.Parameters.AddWithValue("@Price", donatedProducts.Price);
                command.Parameters.AddWithValue("@Status_Product", donatedProducts.Status_Product);
                command.Parameters.AddWithValue("@Active", donatedProducts.Active);
              
            }
            int rows = command.ExecuteNonQuery();
        }

        string insertNewProduct = "insert into [dbo].[TBDonatedProducts]\r\nvalues (@BusinessCompany_Id,@Campaigns_Id,@Product_Name,@Price,@Status_Product,@Active,null)";

        public void PostNewProduct(TBDonatedProducts donatedProduct)
        {
            SqlQueryPost sqlQuery = new SqlQueryPost();
            sqlQuery.RunAddUser(insertNewProduct, AddUserData, donatedProduct);
        }
    }
}
