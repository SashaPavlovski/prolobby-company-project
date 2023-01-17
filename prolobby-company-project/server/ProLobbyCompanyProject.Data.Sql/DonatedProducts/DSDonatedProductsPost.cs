using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// file:	DonatedProducts\DSDonatedProductsPost.cs
// summary:	Implements the ds donated products post class

namespace ProLobbyCompanyProject.Data.Sql.DonatedProducts
{
    /// <summary>  post products . </summary>
    public class DSDonatedProductsPost
    {
        /// <summary>   Default constructor. </summary>

        public DSDonatedProductsPost() { }

        /// <summary>   Adds a user data to TBDonatedProducts. </summary>
        /// <param name="newProduct">   The new product. </param>
        /// <param name="command">      The command. </param>
        public void AddUserData(object newProduct, System.Data.SqlClient.SqlCommand command)
        {
            if (newProduct is TBDonatedProducts)
            {
                TBDonatedProducts donatedProducts = (TBDonatedProducts)newProduct;

                command.Parameters.AddWithValue("@BusinessCompany_Id", donatedProducts.BusinessCompany_Id);
                command.Parameters.AddWithValue("@Campaigns_Id", donatedProducts.Campaigns_Id);
                command.Parameters.AddWithValue("@Product_Name", donatedProducts.Product_Name);
                command.Parameters.AddWithValue("@Price", donatedProducts.Price);


            }
            int rows = command.ExecuteNonQuery();
        }

        /// <summary>   The insert new product. </summary>
        string insertNewProduct = "insert into [dbo].[TBDonatedProducts]\r\nvalues (@BusinessCompany_Id,@Campaigns_Id,@Product_Name,@Price,1,1,getdate())";

        /// <summary>   Posts a new product. </summary>
        /// <param name="donatedProduct">   The donated product. </param>
        public void PostNewProduct(TBDonatedProducts donatedProduct)
        {
            SqlQueryPost sqlQuery = new SqlQueryPost();
            sqlQuery.RunAddUser(insertNewProduct, AddUserData, donatedProduct);
        }
    }
}
