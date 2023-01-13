using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model.Shippers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.Shippers
{
    public class DSShippersDonated
    {
        public DSShippersDonated() { }


        public string DonProduct(object newData, System.Data.SqlClient.SqlCommand command)
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
                    reader.Read();
                    answer = reader["anwer"].ToString();
                    
                }
            }
            return answer;
        }


        string insertBuyforDonation = "declare @Campaigns_Id int,@MoneyTracking_Id int,@productPrice int,@Accumulated_money float,@BusinessCompany_Id int,@anwer nvarchar(max)\r\n,@count int = 0\r\nif  exists (select * from [dbo].[TBMoneyTrackings] where [SocialActivists_Id] = @SocialActivists_Id and [Active] = 1 )\r\n    begin\r\n    SET @Campaigns_Id = (select [Campaigns_Id] from [dbo].[TBDonatedProducts] where [DonatedProducts_Id] = @DonatedProducts_Id)\r\n    if  exists (select * from [dbo].[TBMoneyTrackings] where [SocialActivists_Id] = @SocialActivists_Id \r\n\tand [Active] = 1 and [Campaigns_Id] = @Campaigns_Id)\r\n\t    begin\r\n\t\tSET @MoneyTracking_Id = (select [MoneyTracking_Id] from [dbo].[TBMoneyTrackings] where [SocialActivists_Id] = @SocialActivists_Id \r\n\t    and [Active] = 1 and [Campaigns_Id] = @Campaigns_Id )\r\n        SET @productPrice = (select [Price] from [dbo].[TBDonatedProducts] where [DonatedProducts_Id] = @DonatedProducts_Id )\r\n\t\tif  exists (select * from [dbo].[TBMoneyTrackings] where [MoneyTracking_Id] = @MoneyTracking_Id and [Accumulated_money]> @productPrice)\r\n\t\t     begin\r\n             if not exists (select * from  [dbo].[TBShippers] where [SocialActivists_Id] = @SocialActivists_Id and [DonatedProducts_Id] = @DonatedProducts_Id\r\n\t\t\t and @count = 1)\r\n\t\t\t       begin\r\n                   SET @Accumulated_money = (select [Accumulated_money] - @productPrice from [dbo].[TBMoneyTrackings] where [MoneyTracking_Id] = @MoneyTracking_Id )\r\n\t\t\t       update [dbo].[TBMoneyTrackings] set [Accumulated_money] = @Accumulated_money\r\n                   where [MoneyTracking_Id] = @MoneyTracking_Id\r\n\t\t\t       update [dbo].[TBCampaigns] set [MoneyDonations] =[MoneyDonations] +  @productPrice\r\n                   where [Campaigns_Id] = @Campaigns_Id\r\n\t\t\t       SET @anwer = 'Succeeded'\r\n\t\t\t       select @anwer as 'anwer'\r\n\t\t\t\t   SET @count = 1\r\n\t\t          end\r\n\t\t     end\r\n\t    else\r\n\t\t     begin\r\n\t\t\t SET @anwer = 'you do not have enough money'\r\n\t\t\t select @anwer as 'anwer'\r\n\t\t\t end\r\n\r\n        end\r\n   else \r\n        begin\r\n\t    SET @anwer = 'You are not following the campaign'\r\n\t    select @anwer as 'anwer'\r\n\t    end\r\nend\r\nelse\r\nbegin\r\nSET @anwer = 'You are not following the campaign'\r\nselect @anwer as 'anwer'\r\nend\r\n";

        public string PostDonatedProduct(MAbuyProduct productData)
        {
            if (productData == null) return null;
            SqlQueryPost sqlQueryPost = new SqlQueryPost();
            return sqlQueryPost.RunAddData(insertBuyforDonation, DonProduct, productData);
        }
    }
}
