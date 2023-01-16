////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Campaigns\DSCampaignsPost.cs
//
// summary:	Implements the ds campaigns post class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.Campaigns
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The ds campaigns post. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DSCampaignsPost
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DSCampaignsPost() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a campaign data to 'command'. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="userData"> Information describing the user. </param>
        /// <param name="command">  The command. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int AddCampaignData(object userData, System.Data.SqlClient.SqlCommand command)
        {
            if (userData is TBCampaigns)
            {
                TBCampaigns Campaign = (TBCampaigns)userData;

                command.Parameters.AddWithValue("@Campaigns_Name", Campaign.Campaigns_Name);
                command.Parameters.AddWithValue("@Hashtag", Campaign.Hashtag);
                command.Parameters.AddWithValue("@Descreption", Campaign.Descreption);
                command.Parameters.AddWithValue("@Date", DateTime.Now);
                //command.Parameters.AddWithValue("@Active", Campaign.Active);
                command.Parameters.AddWithValue("@User_Id", Campaign.User_Id);

            }
            int rows = command.ExecuteNonQuery();
            return rows;
        }

        /// <summary>   The insert campign. </summary>
        string insertCampign = "declare @NonProfitOrganization_Id int\r\nif  not exists (select [Active] from [dbo].[TBCampaigns] where [Campaigns_Name] = @Campaigns_Name and [Active] = 0 OR [Hashtag] = @Hashtag and [Active] = 0  )\r\nbegin\r\n       SET @NonProfitOrganization_Id =( select NonProfitOrganization_Id from [dbo].[TBNonProfitOrganizations] where @User_Id = [User_Id])\r\n\t   insert into [dbo].[TBCampaigns] \r\n       values (@NonProfitOrganization_Id,@Campaigns_Name,@Hashtag,@Descreption,@Date,1,@User_Id,0)\r\nend";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts a campaign row. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="campaign"> The campaign. </param>
        ///
        /// <returns>   An int? </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int? PostCampaignRow(TBCampaigns campaign)
        {

            if (campaign == null) return null;

            SqlQueryPost sqlQuery = new SqlQueryPost();
            int? answer = sqlQuery.RunAdd(insertCampign, AddCampaignData, campaign);

            if (answer != null) return answer;
            return null;

        }
    }
}
