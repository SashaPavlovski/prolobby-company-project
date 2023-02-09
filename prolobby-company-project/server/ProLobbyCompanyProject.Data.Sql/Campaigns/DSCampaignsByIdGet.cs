using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql.Campaigns
{
    public class DSCampaignsByIdGet: BaseDataSql
    {
        SqlQuery SqlQuery;
        public DSCampaignsByIdGet(Logger Logger) : base(Logger) 
        {
            SqlQuery = new SqlQuery();
        }

        //Receiving campaign details
        //With organization's id
        public object AddCampaignById(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string campaignName)
        {
            Logger.LogEvent("Enter into AddCampaignById function");

            Logger.LogEvent("Receiving campaign details by organization's id");

            try
            {
                List<TBCampaigns> campaigns = new List<TBCampaigns>();

                if (reader.HasRows)
                {
                    try
                    {
                        while (reader.Read())
                        {
                            campaigns.Add(new TBCampaigns
                            {
                                Campaigns_Id = int.Parse(reader["Campaigns_Id"].ToString()),
                                Campaigns_Name = reader["Campaigns_Name"].ToString(),
                                Descreption = reader["Descreption"].ToString(),
                                Hashtag = reader["Hashtag"].ToString()
                            });

                        }
                    }
                    catch (Exception EX)
                    {

                        throw;
                    }

                    Logger.LogEvent("End AddCampaignById function and receiving campaign details");

                    return campaigns;
                }
            }
            catch (Exception EX)
            {

                throw;
            }

            Logger.LogError("End AddCampaignById function and return null");
            
            return null;
        }

  


        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            Logger.LogEvent("Enter into SetValues function");

            Logger.LogEvent("Entering values");

            try
            {
                command.Parameters.AddWithValue($"@{key}", int.Parse(value));

                Logger.LogEvent("End SetValues function and done successfully");

            }
            catch (Exception EX)
            {

                throw;
            }
        }


        string insertCampaignsById = "if  exists (select * from [dbo].[TBCampaigns] where [Active] =1 and [NonProfitOrganization_Id] = @NonProfitOrganization_Id)\r\nbegin\r\n       select [Campaigns_Name],[Descreption],[Campaigns_Id],[Hashtag]\r\n\t   from [dbo].[TBCampaigns]\r\n\t   where [Active] = 1 and [NonProfitOrganization_Id] = @NonProfitOrganization_Id\r\nend";

        //Enter the details of the campaign into a list
        public List<TBCampaigns> GetCampaignsById(string organizationId )
        {
            Logger.LogEvent("Enter into GetCampaignsById function");

            List<TBCampaigns> campaignsById = null;

            try
            {
                object listCampign = SqlQuery.RunCommand(insertCampaignsById, AddCampaignById, SetValues, "NonProfitOrganization_Id", organizationId, null, null); 

                if (listCampign != null)
                {

                    if (listCampign is List<TBCampaigns>)
                    {
                        campaignsById = (List<TBCampaigns>)listCampign;

                        Logger.LogEvent("End GetCampaignsById function and sending campigns list");

                        return campaignsById;
                    }
                }
            }
            catch (Exception EX)
            {

                throw;
            }

            Logger.LogEvent("End GetCampaignsById function and sending null");

            return campaignsById;
        }
    }
}
