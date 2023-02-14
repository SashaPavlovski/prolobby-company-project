using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using ProLobbyCompanyProject.Model.Campaigns;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Utilities.Logger;

// file:	Campaigns\DSCampaignsGet.cs
// summary:	Implements the ds campaigns get class

namespace ProLobbyCompanyProject.Data.Sql.Campaigns
{
    /// <summary> Receiving details of all campaigns. </summary>

    public class DSCampaignsGet : BaseDataSql
    {
        SqlQuery sqlQuery1;

        /// <summary>   Default constructor. </summary>
        public DSCampaignsGet(Logger Logger) : base(Logger)
        {
            sqlQuery1 = new SqlQuery();
        }

        /// <summary>   Adds a campaign to list. </summary>
        /// <param name="reader">       The reader. </param>
        /// <param name="command">      The command. </param>
        /// <param name="campaignName"> Name of the campaign. </param>
        /// <returns>   An object of Campaigns List . </returns>

        public object AddCampaign(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string campaignName)
        {
            Logger.LogEvent("Enter into AddCampaign function");

            Logger.LogEvent("Getting all campaign");

            List<TBCampaigns> campaigns = new List<TBCampaigns>();
            try
            {
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

                        Logger.LogEvent("End AddCampaign function and get campaigns");

                        return campaigns;
                    }
                    catch (SqlException Ex) { Logger.LogException(Ex.Message, Ex); throw; }
                    catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }
                }
            }
            catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }

            Logger.LogEvent("End AddCampaign function and No information received");

            return null;
        }

        /// <summary>   Adds a campaign about data. </summary>
        /// <param name="reader">       The reader. </param>
        /// <param name="command">      The command. </param>
        /// <param name="campaignName"> Name of the campaign. </param>
        /// <returns>   An object of about campaign. </returns>
        public object AddCampaignAboutData(SqlDataReader reader, SqlCommand command, string campaignName)
        {
            Logger.LogEvent("Enter into AddCampaignAboutData function");

            Logger.LogEvent("Getting all the information about a specific campaign with ID");

            try
            {
                if (reader.HasRows)
                {
                    MAboutCampaign aboutCampaigns = null;

                    while (reader.Read())
                    {
                        try
                        {
                            aboutCampaigns = new MAboutCampaign
                            {
                                NonProfitOrganizationName = reader["NonProfitOrganizationName"].ToString(),
                                NonProfitOrganizationDecreption = reader["decreption"].ToString(),
                                Url = reader["Url"].ToString(),
                                Campaigns_Id = int.Parse(reader["Campaigns_Id"].ToString()),
                                Campaigns_Name = reader["Campaigns_Name"].ToString(),
                                Hashtag = reader["Hashtag"].ToString(),
                                CampaignsDescreption = reader["Descreption"].ToString()
                            };

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

                    }

                    Logger.LogEvent("End AddCampaignAboutData function and get campaigns data");

                    return aboutCampaigns;
                }
            }
            catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }

            Logger.LogEvent("End AddCampaignAboutData function and No information received");

            return null;
        }

        /// <summary>   Sets 2 values. </summary>
        /// <param name="command">  The command. </param>
        /// <param name="key">      The key. </param>
        /// <param name="value">    The value. </param>
        /// <param name="key2">     The second key. </param>
        /// <param name="value2">   The second value. </param>

        public void Set2Values(SqlCommand command, string key, string value, string key2, string value2)
        {
            Logger.LogEvent("Enter into Set2Values function");

            if (key != null && value != null && key2 != null && key2.Contains("Hashtag"))
            {
                Logger.LogEvent("Entering values ​​for variables");

                try
                {
                    command.Parameters.AddWithValue($"@{key}", value);
                    command.Parameters.AddWithValue($"@{key2}", value2);

                }
                catch (SqlException Ex) { Logger.LogException(Ex.Message, Ex); throw; }
                catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }
            }

            Logger.LogEvent("End Set2Values function");
        }


        /// <summary>   Sets the values. </summary>
        /// <param name="command">  The command. </param>
        /// <param name="key">      The key. </param>
        /// <param name="value">    The value. </param>
        /// <param name="key2">     The second key. </param>
        /// <param name="value2">   The second value. </param>
        public void SetValues(SqlCommand command, string key, string value, string key2, string value2)
        {
            Logger.LogEvent("Enter into SetValues function");

            if (key != null && value != null)
            {
                Logger.LogEvent("Entering values ​​for variables");

                try
                {
                    command.Parameters.AddWithValue($"@{key}", value);
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

                Logger.LogEvent("End SetValues function");
            }
        }

        /// <summary>   The insert if exist campign. </summary>
        string insertIfExistCampign = "if  exists (select  [Campaigns_Name] from [dbo].[TBCampaigns] where [Campaigns_Name] = @Campaigns_Name and [Active] = 1 OR [Hashtag] = @Hashtag and [Active] = 1)\r\nbegin\r\n       select [Campaigns_Name],[Hashtag],[Descreption],[Campaigns_Id]\r\n\t   from [dbo].[TBCampaigns]\r\n\t   where [Campaigns_Name] = @Campaigns_Name OR [Hashtag] = @Hashtag\r\nend";

        /// <summary>   The insert campigns. </summary>
        string insertCampigns = "if  exists (select * from [dbo].[TBCampaigns] where [Active] =1)\r\nbegin\r\n       select [Campaigns_Name],[Descreption],[Campaigns_Id],[Hashtag]\r\n\t   from [dbo].[TBCampaigns]\r\n\t   where [Active] = 1\r\nend";

        /// <summary>   The insert about campaign. </summary>
        string insertAboutCampaign = "if  exists (select * from [dbo].[TBCampaigns] where [Active] =1)\r\nbegin\r\n        select Tb1.Url ,Tb1.NonProfitOrganizationName,\r\n        Tb1.decreption,Tb1.NonProfitOrganization_Id,\r\n Tb2.Descreption,Tb2.Hashtag,Tb2.Campaigns_Name,\r\n        Tb2.Campaigns_Id from [dbo].[TBNonProfitOrganizations] Tb1 inner join [dbo].[TBCampaigns] Tb2\r\n        on  Tb1.NonProfitOrganization_Id = Tb2.NonProfitOrganization_Id where Tb2.Campaigns_Id = @Campaigns_Id\r\n\t\tand  Tb2.[Active] =1\r\nend";

        /// <summary>   Gets campaigns global. </summary>
        /// <param name="insert">   The insert. </param>
        /// <param name="key">      The key. </param>
        /// <param name="value">    The value. </param>
        /// <param name="key2">     The second key. </param>
        /// <param name="value2">   The second value. </param>
        /// <returns>   The campaigns global. </returns>
        public List<TBCampaigns> GetCampaignsG(string insert, string key, string value, string key2, string value2)
        {
            Logger.LogEvent("Enter into GetCampaignsG function");

            List<TBCampaigns> campaigns = null;
            object listCampign = null;

            try
            {
                listCampign = sqlQuery1.RunCommand(insert, AddCampaign, Set2Values, key, value, key2, value2); ;
            }
            catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }


            if (listCampign != null)
            {
                if (listCampign is List<TBCampaigns>)
                {
                    campaigns = (List<TBCampaigns>)listCampign;
                }
            }

            Logger.LogEvent("End GetCampaignsG function");

            return campaigns;
        }

        /// <summary>   Gets campaign row. </summary>
        /// <param name="campaign"> The campaign. </param>
        /// <returns>   The campaign row. </returns>

        public List<TBCampaigns> GetCampaignRow(TBCampaigns campaign)
        {
            Logger.LogEvent("\n\nEnter into GetCampaignRow function");

            Logger.LogEvent("Checking if the name of the campaign or the hashtag exists and returning an answer");

            return GetCampaignsG(insertIfExistCampign, "Campaigns_Name", campaign.Campaigns_Name, "Hashtag", campaign.Hashtag);
        }

        /// <summary>   Gets campaign list. </summary>
        /// <returns>   The campaign list. </returns>
        public List<TBCampaigns> GetCampaignList()
        {
            Logger.LogEvent("\n\nEnter into GetCampaignList function");

            Logger.LogEvent("Get all the data of all the campaigns");

            return GetCampaignsG(insertCampigns, null, null, null, null);
        }


        /// <summary>   Gets data about campaign. </summary>
        /// <param name="campaignsId">  Identifier for the campaigns. </param>
        /// <returns>   The data about campaign. </returns>

        public MAboutCampaign GetDataAboutCampaign(string campaignsId)
        {
            Logger.LogEvent("\n\nEnter into GetDataAboutCampaign function");

            Logger.LogEvent("Getting all the information about a specific campaign with ID");

            MAboutCampaign aboutCampaign = null;
            object aboutCampaignData = null;

            try
            {
                if (campaignsId != null)
                {
                    aboutCampaignData = sqlQuery1.RunCommand(insertAboutCampaign, AddCampaignAboutData, SetValues, "Campaigns_Id", campaignsId, null, null);
                }
                else
                {
                    Logger.LogError("End GetDataAboutCampaign function and the campaignsId is null ");
                    return null;

                }

            }
            catch (Exception Ex)
            {
                Logger.LogException(Ex.Message, Ex);

                throw;
            }

            if (aboutCampaignData != null)
            {
                if (aboutCampaignData is MAboutCampaign)
                {
                    aboutCampaign = (MAboutCampaign)aboutCampaignData;

                    Logger.LogEvent("End GetDataAboutCampaign function and end get information about a specific campaign");

                    return aboutCampaign;

                }
            }

            Logger.LogError("End GetDataAboutCampaign function and the aboutCampaignData is null ");

            return aboutCampaign;
        }
    }
}
