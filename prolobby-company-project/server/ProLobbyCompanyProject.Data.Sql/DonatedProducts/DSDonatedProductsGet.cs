////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DonatedProducts\DSDonatedProductsGet.cs
//
// summary:	Implements the ds donated products get class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.DonatedProducts
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The ds donated products get. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DSDonatedProductsGet
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DSDonatedProductsGet() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a donated products. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="reader">   The reader. </param>
        /// <param name="command">  The command. </param>
        /// <param name="UserId">   Identifier for the user. </param>
        ///
        /// <returns>   An object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public object AddDonatedProducts(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            List<TBDonatedProducts> donatedProducts = new List<TBDonatedProducts>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    donatedProducts.Add(new TBDonatedProducts() { DonatedProducts_Id = int.Parse(reader["DonatedProducts_Id"].ToString()), Product_Name = reader["Product_Name"].ToString(), Price = double.Parse(reader["Price"].ToString()) });
                }
                return donatedProducts;
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets the values. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="command">  The command. </param>
        /// <param name="key">      The key. </param>
        /// <param name="value">    The value. </param>
        /// <param name="key2">     The second key. </param>
        /// <param name="value2">   The second value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            command.Parameters.AddWithValue($"@{key}", value);
        }

        /// <summary>   The insert donated products. </summary>
        string insertDonatedProducts = "if  exists (select * from [dbo].[TBDonatedProducts] where [Active] =1 and [Campaigns_Id] = @Campaigns_Id)\r\nbegin\r\n       select [Product_Name],[Price],[DonatedProducts_Id]\r\n\t   from [dbo].[TBDonatedProducts]\r\n\t   where [Active] = 1 and [Campaigns_Id] = @Campaigns_Id\r\nend";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets products campaign. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="campaignId">   Identifier for the campaign. </param>
        ///
        /// <returns>   The products campaign. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<TBDonatedProducts> GetProductsCampaign(string campaignId)
        {
            if (campaignId == null) return null;
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBDonatedProducts> DonatedProductsList = null;


            object listProducts = sqlQuery1.RunCommand(insertDonatedProducts, AddDonatedProducts, SetValues, "Campaigns_Id", campaignId, null, null);

            if (listProducts is List<TBDonatedProducts>)
            {
                DonatedProductsList = (List<TBDonatedProducts>)listProducts;
            }
            return DonatedProductsList;
        }
    }
}
