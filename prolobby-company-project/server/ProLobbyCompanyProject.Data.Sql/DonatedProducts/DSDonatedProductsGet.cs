using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using Utilities.Logger;

// file:	DonatedProducts\DSDonatedProductsGet.cs
// summary:	Implements the ds donated products get class

namespace ProLobbyCompanyProject.Data.Sql.DonatedProducts
{
    /// <summary> get donated products . </summary>
    public class DSDonatedProductsGet: BaseDataSql
    {
        SqlQuery SqlQuery;
        /// <summary>   Default constructor. </summary>
        public DSDonatedProductsGet(Logger Logger) : base(Logger)
        {
            SqlQuery = new SqlQuery();
        }

        /// <summary>   Adds a donated products. </summary>
        /// <param name="reader">   The reader. </param>
        /// <param name="command">  The command. </param>
        /// <param name="UserId">   Identifier for the user. </param>
        /// <returns>   An object of TBDonatedProducts List. </returns>
        public object AddDonatedProducts(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            Logger.LogEvent("Enter into AddDonatedProducts function");

            Logger.LogEvent("Receiving products donated to a specific campaign by campaign id");

            List<TBDonatedProducts> donatedProducts = new List<TBDonatedProducts>();
            
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {                                                   
                        donatedProducts.Add(new TBDonatedProducts
                        {
                            DonatedProducts_Id = int.Parse(reader["DonatedProducts_Id"].ToString()),
                            Product_Name = reader["Product_Name"].ToString(),
                            Price = double.Parse(reader["Price"].ToString())
                        });
                    }

                    Logger.LogEvent("End AddDonatedProducts function and sending the list of donated products ");

                    return donatedProducts;
                }
            }
            catch (Exception)
            {

                throw;
            }

            Logger.LogEvent("End AddDonatedProducts function and sending null");

            return null;
        }

        /// <summary>   Sets the values. </summary>
        /// <param name="command">  The command. </param>
        /// <param name="key">      The key. </param>
        /// <param name="value">    The value. </param>
        /// <param name="key2">     The second key. </param>
        /// <param name="value2">   The second value. </param>
        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            Logger.LogEvent("Enter into SetValues function");

            Logger.LogEvent("Entering values");

            try
            {
                command.Parameters.AddWithValue($"@{key}", value);

                Logger.LogEvent("Done successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>   The insert donated products. </summary>
        string insertDonatedProducts = "if  exists (select * from [dbo].[TBDonatedProducts] where [Active] =1 and [Campaigns_Id] = @Campaigns_Id)\r\nbegin\r\n       select [Product_Name],[Price],[DonatedProducts_Id]\r\n\t   from [dbo].[TBDonatedProducts]\r\n\t   where [Active] = 1 and [Campaigns_Id] = @Campaigns_Id\r\nend";

        /// <summary>   Gets products campaign. </summary>
        /// <param name="campaignId">   Identifier for the campaign. </param>
        /// <returns>   The products campaign list. </returns>
        public List<TBDonatedProducts> GetProductsCampaign(string campaignId)
        {
            Logger.LogEvent("Enter into GetProductsCampaign function");

            if (campaignId == null)
            {
                Logger.LogError("campaignId is null in GetProductsCampaign function");

                return null;
            }

            List<TBDonatedProducts> DonatedProductsList = null;

            object listProducts;

            try
            {
                listProducts = SqlQuery.RunCommand(insertDonatedProducts, AddDonatedProducts, SetValues, "Campaigns_Id", campaignId, null, null);
            }
            catch (Exception)
            {

                throw;
            }

            if (listProducts is List<TBDonatedProducts>)
            {
                DonatedProductsList = (List<TBDonatedProducts>)listProducts;

                Logger.LogEvent("End GetProductsCampaign function and return donated products list");

            }

            Logger.LogEvent("End GetProductsCampaign function and return null");

            return DonatedProductsList;
        }
    }
}
