using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using System;
using System.Data.SqlClient;
using Utilities.Logger;

// file:	Campaigns\DSCampaignsDelete.cs
// summary:	Implements the ds campaigns delete class
namespace ProLobbyCompanyProject.Data.Sql.Campaigns
{
    /// <summary>   The ds campaigns delete. </summary>
    public class DSCampaignsDelete: BaseDataSql
    {
        SqlQueryDelete sqlQueryDelete;
        /// <summary>   Default constructor. </summary>
        public DSCampaignsDelete(Logger Logger) : base(Logger)
        {
            sqlQueryDelete = new SqlQueryDelete();
        }

        /// <summary>   Deletes the product. </summary>
        /// <param name="command">  The command. </param>
        /// <param name="Id">       The identifier. </param>

        public void DeleteCampaign(SqlCommand command, string Id)
        {
            Logger.LogEvent("Enter into DeleteCampaign function");

            Logger.LogEvent("Deletion of the campaign with the Id");


            if (command == null && (Id == null))
            {
                Logger.LogError("End DeleteCampaign function and null campaignId value was received");

                return;
            }
            try
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue($"@Campaigns_Id", int.Parse(Id));
                int rows = command.ExecuteNonQuery();
            }
            catch (SqlException Ex)
            {
                Logger.LogException(Ex.Message, Ex);

                throw;
            }
            catch (Exception Ex)
            {
                Logger.LogException(Ex.Message, Ex);

                throw;
            }

            Logger.LogEvent("End DeleteCampaign function and the deletion operation was performed successfully");
        }





        /// <summary>   The insert delete. </summary>
        string insertDelete = "DeleteCampaign";


        /// <summary>   Deletes the data campaign described by campaignId. </summary>
        /// <param name="campaignId">   Identifier for the campaign. </param>
        public void DeleteDataCampaign(string campaignId)
        {
            Logger.LogEvent("\n\nEnter into DeleteDataCampaign function");

            if (campaignId == null)
            {
                Logger.LogError("End DeleteDataCampaign function and null campaignId value was received");

                return;
            }
            try
            {
                sqlQueryDelete.RunData(insertDelete, campaignId, DeleteCampaign);
            }
            catch (Exception Ex)
            {
                Logger.LogException(Ex.Message, Ex);

                throw;
            }

            Logger.LogEvent("End DeleteDataCampaign function");
        }
    }
}
