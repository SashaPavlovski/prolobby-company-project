using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Data.SqlClient;
using Utilities.Logger;


// file:	DonatedProducts\DSDonatedProductsPost.cs
// summary:	Implements the ds donated products post class

namespace ProLobbyCompanyProject.Data.Sql.DonatedProducts
{
    /// <summary>  post products . </summary>
    public class DSDonatedProductsPost: BaseDataSql
    {
        SqlQueryPost sqlQuery;

        /// <summary>   Default constructor. </summary>
        public DSDonatedProductsPost(Logger Logger) : base(Logger) 
        {
            sqlQuery = new SqlQueryPost();
        }

        /// <summary>   Adds a user data to TBDonatedProducts. </summary>
        /// <param name="newProduct">   The new product. </param>
        /// <param name="command">      The command. </param>
        public void AddNewProduct(object newProduct, SqlCommand command)
        {
            Logger.LogEvent("Enter into AddNewProduct function");

            Logger.LogEvent("Entering new product");

            if (newProduct is TBDonatedProducts)
            {
                try
                {
                    TBDonatedProducts donatedProducts = (TBDonatedProducts)newProduct;

                    command.Parameters.AddWithValue("@BusinessCompany_Id", donatedProducts.BusinessCompany_Id);
                    command.Parameters.AddWithValue("@Campaigns_Id", donatedProducts.Campaigns_Id);
                    command.Parameters.AddWithValue("@Product_Name", donatedProducts.Product_Name);
                    command.Parameters.AddWithValue("@Price", donatedProducts.Price);
                    int rows = command.ExecuteNonQuery();

                    Logger.LogEvent("The operation was performed successfully");

                }
                catch (SqlException Ex) { Logger.LogException(Ex.Message, Ex); throw; }
                catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }
            }
            Logger.LogEvent("End AddNewProduct function");
        }

        /// <summary>   The insert new product. </summary>
        string insertNewProduct = "insert into [dbo].[TBDonatedProducts]\r\nvalues (@BusinessCompany_Id,@Campaigns_Id,@Product_Name,@Price,1,1,getdate())";

        /// <summary>   Posts a new product. </summary>
        /// <param name="donatedProduct">   The donated product. </param>
        public void PostNewProduct(TBDonatedProducts donatedProduct)
        {
            Logger.LogEvent("\n\nEnter into PostNewProduct function");

            if (donatedProduct != null)
            {
                try
                {
                    sqlQuery.RunAddUser(insertNewProduct, AddNewProduct, donatedProduct);
                }
                catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }

                Logger.LogEvent("End PostNewProduct function and the operation was performed successfully");

                return;
            }

            Logger.LogEvent("End PostNewProduct function and get null in donatedProduct value");
        }
    }
}
