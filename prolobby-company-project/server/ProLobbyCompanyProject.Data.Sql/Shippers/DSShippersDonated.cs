using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model.Shippers;
using System.Data.SqlClient;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql.Shippers
{
    public class DSShippersDonated: BaseDataSql
    {
        SqlQueryPost sqlQueryPost;
        public DSShippersDonated(Logger Logger) : base(Logger)
        {
            sqlQueryPost = new SqlQueryPost();
        }

        /// <summary>
        /// Product donation social activist.
        /// </summary>
        /// <param name="newData"> Id of the social activist and the product. </param>
        /// <param name="command"></param>
        /// <returns> answer as to whether the action was carried out or not and why. </returns>s
        public string DonatedProduct(object newData,SqlCommand command)
        {
            Logger.LogEvent("Enter into DonatedProduct function");

            string answer = null;

            if (newData!= null && newData is MAbuyProduct)
            {
                try
                {
                    Logger.LogEvent("Entering the operator's data into the query");

                    MAbuyProduct buyProduct = (MAbuyProduct)newData;

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@SocialActivists_Id", buyProduct.SocialActivists_Id);
                    command.Parameters.AddWithValue("@DonatedProducts_Id", buyProduct.DonatedProducts_Id);

                    Logger.LogEvent("Data of social activist entered successfully");

                }
                catch (SqlException Ex) { Logger.LogException(Ex.Message, Ex); throw; }
                catch (System.Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }

            }
            using (SqlDataReader reader = command.ExecuteReader())
            {
                Logger.LogEvent("starting of operation test");

                if (reader.HasRows)
                {
                    try
                    {
                        if (reader.Read())
                        {
                            answer = reader["answer"].ToString();

                            Logger.LogEvent("End DonatedProduct function, return answer");
                        }
                    }
                    catch (SqlException Ex) { Logger.LogException(Ex.Message, Ex); throw; }
                    catch (System.Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }                    
                }
            }

            Logger.LogEvent("End DonatedProduct function, return null");

            return answer;
        }

        /// <summary>
        /// insertBuyforDonation is sql procedure name.
        /// </summary>
        string insertBuyforDonation = "DonatedProductBySocialActivist";



        /// <summary>
        /// Donating a product by a social activist and returning an answer accordingly.
        /// </summary>
        /// <param name="productData"> Data on the social activist who donates a product. </param>
        /// <returns>
        /// Returns an answer as to whether the action has been done.
        /// Or he does not have enough money.
        /// Or is not following the campaign.
        /// </returns>
        public string PostDonatedProduct(MAbuyProduct productData)
        {
            Logger.LogEvent("\n\nEnter into PostDonatedProduct function");

            if (productData == null)
            {
                Logger.LogError("The received MAbuyProduct class is not valid in PostDonatedProduct function");

                return null;
            }
            try
            {
                return sqlQueryPost.RunAddData(insertBuyforDonation, DonatedProduct, productData);
            }
            catch (System.Exception Ex)
            {
                Logger.LogException(Ex.Message, Ex);

                throw;
            }
        }
    }
}
