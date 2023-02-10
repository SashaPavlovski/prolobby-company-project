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

                    command.Parameters.AddWithValue("@SocialActivists_Id", buyProduct.SocialActivists_Id);
                    command.Parameters.AddWithValue("@DonatedProducts_Id", buyProduct.DonatedProducts_Id);

                    Logger.LogEvent("Data entered successfully");

                }
                catch (SqlException EX)
                {

                    throw;
                }
                catch (System.Exception EX)
                {

                    throw;
                }

            }
            using (SqlDataReader reader = command.ExecuteReader())
            {
                Logger.LogEvent("Enter into DonatedProduct function");

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
                    catch (SqlException EX)
                    {

                        throw;
                    }
                    catch (System.Exception EX)
                    {

                        throw;
                    }                    
                }
            }

            Logger.LogEvent("End DonatedProduct function, return null");

            return answer;
        }

        /// <summary>
        /// insertBuyforDonation is sql procedure name.
        /// </summary>
        string insertBuyforDonation = "DonatedProductBySocialActivist";

       //string insertBuyforDonation = "declare @Campaigns_Id int,@MoneyTracking_Id int,@productPrice int,@Accumulated_money float,@BusinessCompany_Id int,@answer nvarchar(max)\r\n,@count int = 0\r\nif  exists (select * from [dbo].[TBMoneyTrackings] where [SocialActivists_Id] = @SocialActivists_Id and [Active] = 1 )\r\n    begin\r\n    SET @Campaigns_Id = (select [Campaigns_Id] from [dbo].[TBDonatedProducts] where [DonatedProducts_Id] = @DonatedProducts_Id)\r\n    if  exists (select * from [dbo].[TBMoneyTrackings] where [SocialActivists_Id] = @SocialActivists_Id \r\n\tand [Active] = 1 and [Campaigns_Id] = @Campaigns_Id)\r\n\t    begin\r\n\t\tSET @MoneyTracking_Id = (select [MoneyTracking_Id] from [dbo].[TBMoneyTrackings] where [SocialActivists_Id] = @SocialActivists_Id \r\n\t    and [Active] = 1 and [Campaigns_Id] = @Campaigns_Id )\r\n        SET @productPrice = (select [Price] from [dbo].[TBDonatedProducts] where [DonatedProducts_Id] = @DonatedProducts_Id )\r\n\t\tif  exists (select * from [dbo].[TBMoneyTrackings] where [MoneyTracking_Id] = @MoneyTracking_Id and [Accumulated_money]> @productPrice)\r\n\t\t     begin\r\n             if not exists (select * from  [dbo].[TBShippers] where [SocialActivists_Id] = @SocialActivists_Id and [DonatedProducts_Id] = @DonatedProducts_Id\r\n\t\t\t and @count = 1)\r\n\t\t\t       begin\r\n                   SET @Accumulated_money = (select [Accumulated_money] - @productPrice from [dbo].[TBMoneyTrackings] where [MoneyTracking_Id] = @MoneyTracking_Id )\r\n\t\t\t       update [dbo].[TBMoneyTrackings] set [Accumulated_money] = @Accumulated_money\r\n                   where [MoneyTracking_Id] = @MoneyTracking_Id\r\n\t\t\t       update [dbo].[TBCampaigns] set [MoneyDonations] =[MoneyDonations] +  @productPrice\r\n                   where [Campaigns_Id] = @Campaigns_Id\r\n\t\t\t       SET @answer = 'Succeeded'\r\n\t\t\t       select @answer as 'answer'\r\n\t\t\t\t   SET @count = 1\r\n\t\t          end\r\n\t\t     end\r\n\t    else\r\n\t\t     begin\r\n\t\t\t SET @answer = 'you do not have enough money'\r\n\t\t\t select @answer as 'answer'\r\n\t\t\t end\r\n\r\n        end\r\n   else \r\n        begin\r\n\t    SET @answer = 'You are not following the campaign'\r\n\t    select @answer as 'answer'\r\n\t    end\r\nend\r\nelse\r\nbegin\r\nSET @answer = 'You are not following the campaign'\r\nselect @answer as 'answer'\r\nend\r\n";


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
            Logger.LogEvent("Enter into PostDonatedProduct function");

            if (productData == null)
            {
                Logger.LogError("The received MAbuyProduct class is not valid in PostDonatedProduct function");

                return null;
            }
            try
            {
                return sqlQueryPost.RunAddData(insertBuyforDonation, DonatedProduct, productData);
            }
            catch (System.Exception EX)
            {

                throw;
            }
        }
    }
}
