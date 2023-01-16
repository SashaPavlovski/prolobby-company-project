////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Shippers\DSShippersBuy.cs
//
// summary:	Implements the ds shippers buy class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using ProLobbyCompanyProject.Model.Shippers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.Shippers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The ds shippers buy. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DSShippersBuy
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DSShippersBuy() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Buy product. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="newData">  Information describing the new. </param>
        /// <param name="command">  The command. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string buyProduct(object newData, System.Data.SqlClient.SqlCommand command)
        {
            string answer = null;
            if (newData is MAbuyProduct)
            {
                MAbuyProduct buyProduct = (MAbuyProduct)newData;

                command.Parameters.AddWithValue("@SocialActivists_Id", buyProduct.SocialActivists_Id);
                command.Parameters.AddWithValue("@DonatedProducts_Id", buyProduct.DonatedProducts_Id);
               // int rows = command.ExecuteNonQuery();

            }
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        answer = reader["answer"].ToString();
                    }
                }
            }
            return answer;
        }

        /// <summary>   The insert buy. </summary>
        string insertBuy = "declare @Campaigns_Id int,@MoneyTracking_Id int,@productPrice int,@Accumulated_money float,@BusinessCompany_Id int,@answer nvarchar(max)\r\nif  exists (select * from [dbo].[TBMoneyTrackings] where [SocialActivists_Id] = @SocialActivists_Id and [Active] = 1 )\r\n    begin\r\n    SET @Campaigns_Id = (select [Campaigns_Id] from [dbo].[TBDonatedProducts] where [DonatedProducts_Id] = @DonatedProducts_Id)\r\n    if  exists (select * from [dbo].[TBMoneyTrackings] where [SocialActivists_Id] = @SocialActivists_Id \r\n\tand [Active] = 1 and [Campaigns_Id] = @Campaigns_Id)\r\n\t    begin\r\n\t\tSET @MoneyTracking_Id = (select [MoneyTracking_Id] from [dbo].[TBMoneyTrackings] where [SocialActivists_Id] = @SocialActivists_Id \r\n\t    and [Active] = 1 and [Campaigns_Id] = @Campaigns_Id )\r\n        SET @productPrice = (select [Price] from [dbo].[TBDonatedProducts] where [DonatedProducts_Id] = @DonatedProducts_Id )\r\n\t\tif  exists (select * from [dbo].[TBMoneyTrackings] where [MoneyTracking_Id] = @MoneyTracking_Id and [Accumulated_money]> @productPrice )\r\n\t\t     begin\r\n\t\t\t if not exists (select * from  [dbo].[TBShippers] where [SocialActivists_Id] = @SocialActivists_Id and [DonatedProducts_Id] = @DonatedProducts_Id)\r\n\t\t\t          begin\r\n\t\t\t\t      SET @Accumulated_money = (select [Accumulated_money] - @productPrice from [dbo].[TBMoneyTrackings] where [MoneyTracking_Id] = @MoneyTracking_Id )\r\n\t\t\t          update [dbo].[TBMoneyTrackings] set [Accumulated_money] = @Accumulated_money\r\n                      where [MoneyTracking_Id] = @MoneyTracking_Id\r\n\t\t              SET @BusinessCompany_Id = (select [BusinessCompany_Id] from [dbo].[TBDonatedProducts] where [DonatedProducts_Id] = @DonatedProducts_Id )\r\n\t\t\t          insert into [dbo].[TBShippers]\r\n                      values (@DonatedProducts_Id,@SocialActivists_Id,@BusinessCompany_Id,getdate(),1)\r\n\t\t\t          update [dbo].[TBDonatedProducts] set  [Status_Product] = 2,[Active] = 0\r\n                      where [DonatedProducts_Id] = @DonatedProducts_Id\r\n\t\t\t          SET @answer = 'Succeeded' \r\n\t\t\t          select @answer as 'answer'\r\n\t\t\t          end\r\n\t\t     end\r\n\t    else\r\n\t\t     begin\r\n\t\t\t SET @answer = 'you do not have enough money'\r\n\t\t\t select @answer as 'answer'\r\n\t\t\t end\r\n\r\n        end\r\n   else \r\n        begin\r\n\t    SET @answer = 'You are not following the campaign'\r\n\t    select @answer as 'answer'\r\n\t    end\r\nend\r\nelse\r\nbegin\r\nSET @answer = 'You are not following the campaign'\r\nselect @answer as 'answer'\r\nend\r\n";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts a donated product. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="productData">  Information describing the product. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string PostProduct(MAbuyProduct productData)
        {
            if (productData == null) return null;
            SqlQueryPost sqlQueryPost = new SqlQueryPost();
            return sqlQueryPost.RunAddData(insertBuy, buyProduct, productData);
        }
    }
}
