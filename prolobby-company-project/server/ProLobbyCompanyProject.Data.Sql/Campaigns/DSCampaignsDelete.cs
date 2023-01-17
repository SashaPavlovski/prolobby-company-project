
using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// file:	Campaigns\DSCampaignsDelete.cs
// summary:	Implements the ds campaigns delete class
namespace ProLobbyCompanyProject.Data.Sql.Campaigns
{
    /// <summary>   The ds campaigns delete. </summary>
    public class DSCampaignsDelete
    {
        /// <summary>   Default constructor. </summary>
        public DSCampaignsDelete() { }

        /// <summary>   Deletes the product. </summary>
        /// <param name="command">  The command. </param>
        /// <param name="Id">       The identifier. </param>

        public void DeleteProduct(System.Data.SqlClient.SqlCommand command, string Id)
        {

            if (command == null && (Id == null)) return;
            command.Parameters.AddWithValue($"@Campaigns_Id", int.Parse(Id));
            int rows = command.ExecuteNonQuery();
        }





        /// <summary>   The insert delete. </summary>
        string insertDelete = "if exists (select  Campaigns_Id from [dbo].[TBCampaigns] where Campaigns_Id = @Campaigns_Id )\r\nbegin\r\n     if not exists (select  Campaigns_Id from [dbo].[TBDonatedProducts] where Campaigns_Id = @Campaigns_Id )\r\n\t        begin\r\n\t\t\t if not exists (select  Campaigns_Id from [dbo].[TBMoneyTrackings] where Campaigns_Id = @Campaigns_Id  )\r\n\tbegin\r\ndelete from  [dbo].[TBCampaigns] where Campaigns_Id = @Campaigns_Id\r\n\t\t\t\t\t\tend\r\n\t\t\t\t else\r\n\t  \tbegin\t         \r\n\t\t\t            update [dbo].[TBCampaigns] set [Active] = 0\r\n      where Campaigns_Id = @Campaigns_Id \r\n\t\t\t\t\t    update [dbo].[TBDonatedProducts] set [Active] = 0,[Status_Product] = 4\r\nwhere Campaigns_Id = @Campaigns_Id \r\n\t\t\t\t\t    update [dbo].[TBMoneyTrackings] set [Active] = 0\r\nwhere Campaigns_Id = @Campaigns_Id \r\n\t\t\t\t\t\tif exists (select  Campaigns_Id from [dbo].[TBPostsTrackings] where Campaigns_Id = @Campaigns_Id  )\r\n  begin\r\n\t\t\t\t\t\t\t   update [dbo].[TBPostsTrackings] set [Active] = 0\r\n   where Campaigns_Id = @Campaigns_Id \r\n\t\t\t\t\t\t       end\r\n\t\t\t\t\t\tend\r\n  end\r\n\t else\r\n\t       \tbegin\r\n\t\t\t         \r\n\t\t\t          update [dbo].[TBCampaigns] set [Active] = 0\r\n   where Campaigns_Id = @Campaigns_Id \r\n\t\t\t\t\t  update [dbo].[TBDonatedProducts] set [Active] = 0,[Status_Product] = 4\r\n   where Campaigns_Id = @Campaigns_Id \r\n\t\t\t\t\t  if exists (select  Campaigns_Id from [dbo].[TBMoneyTrackings] where Campaigns_Id = @Campaigns_Id and [Active] = 1 )\r\n   begin\r\n\t\t\t\t\t           update [dbo].[TBMoneyTrackings] set [Active] = 0\r\n  where Campaigns_Id = @Campaigns_Id and [Active] = 1\r\n\t\t\t\t\t\t       end\r\n\r\n\t\t\t\t\t  if exists (select  Campaigns_Id from [dbo].[TBPostsTrackings] where Campaigns_Id = @Campaigns_Id and [Active] = 1 )\r\n     begin\r\n\t\t\t\t\t\t\t   update [dbo].[TBPostsTrackings] set [Active] = 0\r\n    where Campaigns_Id = @Campaigns_Id and [Active] = 1\r\n\t\t\t\t\t\t       end\r\n\t\t\t        \r\n     end\r\nend";


        /// <summary>   Deletes the data campaign described by campaignId. </summary>
        /// <param name="campaignId">   Identifier for the campaign. </param>
        public void DeleteDataCampaign(string campaignId)
        {
            SqlQueryDelete sqlQueryDelete = new SqlQueryDelete();
            sqlQueryDelete.RunData(insertDelete, campaignId, DeleteProduct);
        }


    }
}
