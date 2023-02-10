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

                    command.Parameters.AddWithValue("@SocialActivists_Id", buyProduct.SocialActivists_Id);
                    command.Parameters.AddWithValue("@DonatedProducts_Id", buyProduct.DonatedProducts_Id);

                    Logger.LogEvent("Done successfully enter valuקs");

                }
                catch (SqlException EX)
                {

                    throw;
                }
                catch (Exception EX)
                {

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
                    catch (SqlException EX)
                    {

                        throw;
                    }
                    catch (Exception EX)
                    {

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

        //string insertBuy = "declare @Campaigns_Id int,@MoneyTracking_Id int,@productPrice int,@Accumulated_money float,@BusinessCompany_Id int,@answer nvarchar(max)\r\nif  exists (select * from [dbo].[TBMoneyTrackings] where [SocialActivists_Id] = @SocialActivists_Id and [Active] = 1 )\r\n    begin\r\n    SET @Campaigns_Id = (select [Campaigns_Id] from [dbo].[TBDonatedProducts] where [DonatedProducts_Id] = @DonatedProducts_Id)\r\n    if  exists (select * from [dbo].[TBMoneyTrackings] where [SocialActivists_Id] = @SocialActivists_Id \r\n\tand [Active] = 1 and [Campaigns_Id] = @Campaigns_Id)\r\n\t    begin\r\n\t\tSET @MoneyTracking_Id = (select [MoneyTracking_Id] from [dbo].[TBMoneyTrackings] where [SocialActivists_Id] = @SocialActivists_Id \r\n\t    and [Active] = 1 and [Campaigns_Id] = @Campaigns_Id )\r\n        SET @productPrice = (select [Price] from [dbo].[TBDonatedProducts] where [DonatedProducts_Id] = @DonatedProducts_Id )\r\n\t\tif  exists (select * from [dbo].[TBMoneyTrackings] where [MoneyTracking_Id] = @MoneyTracking_Id and [Accumulated_money]> @productPrice )\r\n\t\t     begin\r\n\t\t\t if not exists (select * from  [dbo].[TBShippers] where [SocialActivists_Id] = @SocialActivists_Id and [DonatedProducts_Id] = @DonatedProducts_Id)\r\n\t\t\t          begin\r\n\t\t\t\t      SET @Accumulated_money = (select [Accumulated_money] - @productPrice from [dbo].[TBMoneyTrackings] where [MoneyTracking_Id] = @MoneyTracking_Id )\r\n\t\t\t          update [dbo].[TBMoneyTrackings] set [Accumulated_money] = @Accumulated_money\r\n                      where [MoneyTracking_Id] = @MoneyTracking_Id\r\n\t\t              SET @BusinessCompany_Id = (select [BusinessCompany_Id] from [dbo].[TBDonatedProducts] where [DonatedProducts_Id] = @DonatedProducts_Id )\r\n\t\t\t          insert into [dbo].[TBShippers]\r\n                      values (@DonatedProducts_Id,@SocialActivists_Id,@BusinessCompany_Id,getdate(),1)\r\n\t\t\t          update [dbo].[TBDonatedProducts] set  [Status_Product] = 2,[Active] = 0\r\n                      where [DonatedProducts_Id] = @DonatedProducts_Id\r\n\t\t\t          SET @answer = 'Succeeded' \r\n\t\t\t          select @answer as 'answer'\r\n\t\t\t          end\r\n\t\t     end\r\n\t    else\r\n\t\t     begin\r\n\t\t\t SET @answer = 'you do not have enough money'\r\n\t\t\t select @answer as 'answer'\r\n\t\t\t end\r\n\r\n        end\r\n   else \r\n        begin\r\n\t    SET @answer = 'You are not following the campaign'\r\n\t    select @answer as 'answer'\r\n\t    end\r\nend\r\nelse\r\nbegin\r\nSET @answer = 'You are not following the campaign'\r\nselect @answer as 'answer'\r\nend\r\n";


        /// <summary>   Buy a donated product. </summary>
        /// <param name="productData">  Information describing the product. </param>
        public string ActivistBuyProduct(MAbuyProduct productData)
        {
            Logger.LogEvent("Enter into ActivistBuyProduct function");

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
            catch (Exception EX)
            {

                throw;
            }
        }
    }
}
