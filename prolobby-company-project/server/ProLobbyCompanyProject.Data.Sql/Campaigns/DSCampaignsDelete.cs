////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Campaigns\DSCampaignsDelete.cs
//
// summary:	Implements the ds campaigns delete class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.Campaigns
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The ds campaigns delete. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DSCampaignsDelete
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DSCampaignsDelete() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the product. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="command">  The command. </param>
        /// <param name="Id">       The identifier. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteProduct(System.Data.SqlClient.SqlCommand command, string Id)
        {

            if (command == null && (Id == null)) return;
            command.Parameters.AddWithValue($"@Campaigns_Id", int.Parse(Id));
            int rows = command.ExecuteNonQuery();
        }





        /// <summary>   The insert delete. </summary>
        string insertDelete = "if exists (select  Campaigns_Id from [dbo].[TBCampaigns] where Campaigns_Id = @Campaigns_Id )\r\nbegin\r\n     if not exists (select  Campaigns_Id from [dbo].[TBDonatedProducts] where Campaigns_Id = @Campaigns_Id  )\r\n\t        begin\r\n\t\t\t     if not exists (select  Campaigns_Id from [dbo].[TBMoneyTrackings] where Campaigns_Id = @Campaigns_Id  )\r\n\t                    begin\r\n                        delete from  [dbo].[TBCampaigns] where Campaigns_Id = @Campaigns_Id\r\n\t\t\t\t\t\tend\r\n\t\t\t\t else\r\n\t                \tbegin\t         \r\n\t\t\t            update [dbo].[TBCampaigns] set [Active] = 0\r\n                        where Campaigns_Id = @Campaigns_Id \r\n\t\t\t\t\t    update [dbo].[TBDonatedProducts] set [Active] = 0,[Status_Product] = 4\r\n                        where Campaigns_Id = @Campaigns_Id \r\n\t\t\t\t\t    update [dbo].[TBMoneyTrackings] set [Active] = 0\r\n                        where Campaigns_Id = @Campaigns_Id \r\n                        end\r\n            end\r\n\t else\r\n\t       \tbegin\r\n\t\t\t         \r\n\t\t\t          update [dbo].[TBCampaigns] set [Active] = 0\r\n                      where Campaigns_Id = @Campaigns_Id \r\n\t\t\t\t\t  update [dbo].[TBDonatedProducts] set [Active] = 0,[Status_Product] = 4\r\n                      where Campaigns_Id = @Campaigns_Id \r\n\t\t\t\t\t  update [dbo].[TBMoneyTrackings] set [Active] = 0\r\n                      where Campaigns_Id = @Campaigns_Id \r\n\t\t\t        \r\n             end\r\nend";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the data campaign described by campaignId. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="campaignId">   Identifier for the campaign. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteDataCampaign(string campaignId)
        {
            SqlQueryDelete sqlQueryDelete = new SqlQueryDelete();
            sqlQueryDelete.RunData(insertDelete, campaignId, DeleteProduct);
        }


    }
}
