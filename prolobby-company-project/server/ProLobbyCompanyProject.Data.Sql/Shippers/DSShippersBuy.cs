using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model.Shippers;
using System;
using System.Data.SqlClient;
using Utilities.Logger;

// file:Shippers\DSShippersBuy.css
// summary:	Implements the ds shippers buy class

namespace ProLobbyCompanyProject.Data.Sql.Shippers
{
    /// <summary> shippers buy. </summary>
    public class DSShippersBuy: BaseDataSql
    {
        SqlQueryPost sqlQueryPost;
        public DSShippersBuy(Logger Logger) : base(Logger)
        {
            sqlQueryPost = new SqlQueryPost();
        }

        /// <summary>   Buy product. </summary>
        /// <param name="newData">  Information describing the new. </param>
        /// <param name="command">  The command. </param>
        /// <returns>   A answer string. </returns>

        public string BuyProduct(object newData, SqlCommand command)
        {
            Logger.LogEvent("Enter into BuyProduct function");

            string answer = null;

            if (newData!= null && newData is MAbuyProduct)
            {
                Logger.LogEvent("Entering the data of the activist who wants to buy a donated product");

                try
                {
                    MAbuyProduct buyProduct = (MAbuyProduct)newData;

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@SocialActivists_Id", buyProduct.SocialActivists_Id);
                    command.Parameters.AddWithValue("@DonatedProducts_Id", buyProduct.DonatedProducts_Id);

                    Logger.LogEvent("Done successfully enter values");

                }
                catch (SqlException Ex)
                {
                    Logger.LogException(Ex.Message, Ex);

                    throw;
                }
                catch (Exception Ex)
                {
                    Logger.LogException(Ex.Message, Ex);

                    throw;
                }
            }
            using (SqlDataReader reader = command.ExecuteReader())
            {
                Logger.LogEvent("The operation to start receiving the data from the sql was successful");

                if (reader.HasRows)
                {
                    try
                    {
                        if (reader.Read())
                        {
                            answer = reader["answer"].ToString();

                            Logger.LogEvent("Get answer successfully");
                        }



                    }
                    catch (SqlException Ex)
                    {
                        Logger.LogException(Ex.Message, Ex);

                        throw;
                    }
                    catch (Exception Ex)
                    {
                        Logger.LogException(Ex.Message, Ex);

                        throw;
                    }
                }
            }

            Logger.LogEvent("End BuyProduct function, return answer");

            return answer;
        }

        /// <summary>
        /// name of procedure is BuyProduct.
        /// </summary>
        string insertBuy = "BuyProduct";


        /// <summary>   Buy a donated product. </summary>
        /// <param name="productData">  Information describing the product. </param>
        public string ActivistBuyProduct(MAbuyProduct productData)
        {
            Logger.LogEvent("\n\nEnter into ActivistBuyProduct function");

            Logger.LogEvent("Buy product if the operator has enough money and returns an answer accordingly");

            if (productData == null)
            {
                Logger.LogError("No data entered for the MAbuyProduct class get null into class");

                return null;
            }

            try
            {
                return sqlQueryPost.RunAddData(insertBuy, BuyProduct, productData);
            }
            catch (Exception Ex)
            {
                Logger.LogException(Ex.Message, Ex);

                throw;
            }
        }
    }
}
