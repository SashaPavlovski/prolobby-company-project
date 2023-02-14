using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Data.SqlClient;
using Utilities.Logger;

// file:Campaigns\DSCampaignsPost.cs
// summary:	Implements the ds campaigns post class

namespace ProLobbyCompanyProject.Data.Sql.Campaigns
{

    /// <summary>   The post campaigns data. </summary>
    public class DSCampaignsPost: BaseDataSql
    {

        SqlQueryPost sqlQuery;

        /// <summary>   Default constructor. </summary>
        public DSCampaignsPost(Logger Logger) : base(Logger)
        {
            sqlQuery = new SqlQueryPost();
        }

        /// <summary>   Adds a campaign data to Campaigns class. </summary>
        /// <param name="userData"> Information describing the user. </param>
        /// <param name="command">  The command. </param>
        /// <returns>   An int . </returns>

        public int AddCampaignData(object userData, System.Data.SqlClient.SqlCommand command)
        {
            Logger.LogEvent("Enter into AddCampaignData function");

            Logger.LogEvent("Entering campaign details");

            int rows = 0;

            if (userData is TBCampaigns)
            {
                TBCampaigns Campaign = (TBCampaigns)userData;

                try
                {
                    command.Parameters.AddWithValue("@Campaigns_Name", Campaign.Campaigns_Name);
                    command.Parameters.AddWithValue("@Hashtag", Campaign.Hashtag);
                    command.Parameters.AddWithValue("@Descreption", Campaign.Descreption);
                    command.Parameters.AddWithValue("@Date", DateTime.Now);
                    command.Parameters.AddWithValue("@User_Id", Campaign.User_Id);

                    rows = command.ExecuteNonQuery();

                    Logger.LogEvent("The operation was carried out successfully");

                    Logger.LogEvent("End AddCampaignData function");

                    return rows;
                }
                catch (SqlException Ex) { Logger.LogException(Ex.Message, Ex); throw; }
                catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }
            }

            Logger.LogError("End AddCampaignData function and Invalid data received ");

            return rows;
        }

        /// <summary>   The insert campign. </summary>
        string insertCampign = "declare @NonProfitOrganization_Id int\r\nif  not exists (select [Active] from [dbo].[TBCampaigns] where [Campaigns_Name] = @Campaigns_Name and [Active] = 0 OR [Hashtag] = @Hashtag and [Active] = 0  )\r\nbegin\r\n       SET @NonProfitOrganization_Id =( select NonProfitOrganization_Id from [dbo].[TBNonProfitOrganizations] where @User_Id = [User_Id])\r\n\t   insert into [dbo].[TBCampaigns] \r\n       values (@NonProfitOrganization_Id,@Campaigns_Name,@Hashtag,@Descreption,@Date,1,@User_Id,0)\r\nend";

        /// <summary>   Posts a campaign row. </summary>
        /// <param name="campaign"> The campaign. </param>
        /// <returns>   An int? </returns>

        public int? PostCampaignRow(TBCampaigns campaign)
        {
            Logger.LogEvent("\n\nEnter into PostCampaignRow function");

            if (campaign == null)
            {
                Logger.LogError("Invalid data received and campaign is null");

                return null;
            }

            int? answer;
            
            try
            {
                answer = sqlQuery.RunAdd(insertCampign, AddCampaignData, campaign);
            }
            catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }

            Logger.LogEvent("End PostCampaignRow function and sending a answer");

            return answer;

        }
    }
}
