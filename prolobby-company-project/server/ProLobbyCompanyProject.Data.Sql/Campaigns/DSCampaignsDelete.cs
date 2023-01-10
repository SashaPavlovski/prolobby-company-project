using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.Campaigns
{
    public class DSCampaignsDelete
    {
        public DSCampaignsDelete() { }

        public void DeleteProduct(System.Data.SqlClient.SqlCommand command, string Id)
        {
            
                if (command == null && (Id == null)) return;
                command.Parameters.AddWithValue($"@Campaigns_Id", int.Parse(Id));
                int rows = command.ExecuteNonQuery();
        }





        string insertDelete = "if exists (select  Campaigns_Id from [dbo].[TBCampaigns] where Campaigns_Id = @Campaigns_Id )\r\nbegin\r\n     if not exists (select  Campaigns_Id from [dbo].[TBDonatedProducts] where Campaigns_Id = @Campaigns_Id  )\r\n\t        begin\r\n            delete from  [dbo].[TBCampaigns] where Campaigns_Id = @Campaigns_Id\r\n            end\r\n\t else\r\n\t       \tbegin\r\n\t\t\t     if exists (select  Campaigns_Id from [dbo].[TBDonatedProducts] where Campaigns_Id = @Campaigns_Id and Active = 0  )\r\n                      begin\r\n\t\t\t\t\t  update [dbo].[TBCampaigns] set [Active] = 0 \r\n                      where Campaigns_Id = @Campaigns_Id \r\n\t\t       \t      end\r\n\t\t\t     if exists (select  Campaigns_Id from [dbo].[TBDonatedProducts] where Campaigns_Id = @Campaigns_Id and Active = 1  )\r\n\t\t\t          begin\r\n\t\t\t          update [dbo].[TBCampaigns] set [Active] = 0\r\n                      where Campaigns_Id = @Campaigns_Id \r\n\t\t\t\t\t  update [dbo].[TBDonatedProducts] set [Active] = 0,[Status_Product] = 4\r\n                      where Campaigns_Id = @Campaigns_Id \r\n\t\t\t          end\r\n             end\r\nend";
        public void DeleteDataCampaign(string campaignId)
        {
            SqlQueryDelete sqlQueryDelete = new SqlQueryDelete();
            sqlQueryDelete.RunData(insertDelete, campaignId ,DeleteProduct);
        }


    }
}
