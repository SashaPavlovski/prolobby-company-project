////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Campaigns\DSCampaignsGet.cs
//
// summary:	Implements the ds campaigns get class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using ProLobbyCompanyProject.Model.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.Campaigns
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The ds campaigns get. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DSCampaignsGet
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DSCampaignsGet() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a campaign. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="reader">       The reader. </param>
        /// <param name="command">      The command. </param>
        /// <param name="campaignName"> Name of the campaign. </param>
        ///
        /// <returns>   An object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public object AddCampaign(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string campaignName)
        {
            List<TBCampaigns> campaigns = new List<TBCampaigns>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    campaigns.Add(new TBCampaigns() { Campaigns_Id = int.Parse(reader["Campaigns_Id"].ToString()), Campaigns_Name = reader["Campaigns_Name"].ToString(), Descreption = reader["Descreption"].ToString(), Hashtag = reader["Hashtag"].ToString() });

                }
                return campaigns;
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a campaign about data. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="reader">       The reader. </param>
        /// <param name="command">      The command. </param>
        /// <param name="campaignName"> Name of the campaign. </param>
        ///
        /// <returns>   An object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public object AddCampaignAboutData(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string campaignName)
        {
            if (reader.HasRows)
            {
                MAboutCampaign aboutCampaigns = null;

                while (reader.Read())
                {
                    aboutCampaigns = new MAboutCampaign() { NonProfitOrganizationName = reader["NonProfitOrganizationName"].ToString(), NonProfitOrganizationDecreption = reader["decreption"].ToString(), Url = reader["Url"].ToString(), Campaigns_Id = int.Parse(reader["Campaigns_Id"].ToString()), Campaigns_Name = reader["Campaigns_Name"].ToString(), Hashtag = reader["Hashtag"].ToString(), CampaignsDescreption = reader["Descreption"].ToString() };

                }
                return aboutCampaigns;
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets 2 values. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="command">  The command. </param>
        /// <param name="key">      The key. </param>
        /// <param name="value">    The value. </param>
        /// <param name="key2">     The second key. </param>
        /// <param name="value2">   The second value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Set2Values(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            if (key != null && value != null && key2 != null && key2.Contains("Hashtag"))
            {
                command.Parameters.AddWithValue($"@{key}", value);
                command.Parameters.AddWithValue($"@{key2}", value);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets the values. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="command">  The command. </param>
        /// <param name="key">      The key. </param>
        /// <param name="value">    The value. </param>
        /// <param name="key2">     The second key. </param>
        /// <param name="value2">   The second value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            command.Parameters.AddWithValue($"@{key}", value);
        }

        /// <summary>   The insert if exist campign. </summary>
        string insertIfExistCampign = "if  exists (select  [Campaigns_Name] from [dbo].[TBCampaigns] where [Campaigns_Name] = @Campaigns_Name and [Active] = 1 OR [Hashtag] = @Hashtag and [Active] = 1)\r\nbegin\r\n       select [Campaigns_Name],[Hashtag],[Descreption],[Campaigns_Id]\r\n\t   from [dbo].[TBCampaigns]\r\n\t   where [Campaigns_Name] = @Campaigns_Name OR [Hashtag] = @Hashtag\r\nend";

        /// <summary>   The insert campigns. </summary>
        string insertCampigns = "if  exists (select * from [dbo].[TBCampaigns] where [Active] =1)\r\nbegin\r\n       select [Campaigns_Name],[Descreption],[Campaigns_Id],[Hashtag]\r\n\t   from [dbo].[TBCampaigns]\r\n\t   where [Active] = 1\r\nend";

        /// <summary>   The insert about campaign. </summary>
        string insertAboutCampaign = "if  exists (select * from [dbo].[TBCampaigns] where [Active] =1)\r\nbegin\r\n        select Tb1.Url ,Tb1.NonProfitOrganizationName,\r\n        Tb1.decreption,Tb1.NonProfitOrganization_Id,\r\n        Tb2.Descreption,Tb2.Hashtag,Tb2.Campaigns_Name,\r\n        Tb2.Campaigns_Id from [dbo].[TBNonProfitOrganizations] Tb1 inner join [dbo].[TBCampaigns] Tb2\r\n        on  Tb1.NonProfitOrganization_Id = Tb2.NonProfitOrganization_Id where Tb2.Campaigns_Id = @Campaigns_Id\r\n\t\tand  Tb2.[Active] =1\r\nend";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets campaigns g. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="insert">   The insert. </param>
        /// <param name="key">      The key. </param>
        /// <param name="value">    The value. </param>
        /// <param name="key2">     The second key. </param>
        /// <param name="value2">   The second value. </param>
        ///
        /// <returns>   The campaigns g. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<TBCampaigns> GetCampaignsG(string insert, string key, string value, string key2, string value2)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBCampaigns> campaigns = null;

            object listCampign = sqlQuery1.RunCommand(insert, AddCampaign, Set2Values, key, value, key2, value2); ;
            if (listCampign != null)
            {

                if (listCampign is List<TBCampaigns>)
                {
                    campaigns = (List<TBCampaigns>)listCampign;
                }
            }
            return campaigns;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets campaign row. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="campaign"> The campaign. </param>
        ///
        /// <returns>   The campaign row. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<TBCampaigns> GetCampaignRow(TBCampaigns campaign)
        {
            return GetCampaignsG(insertIfExistCampign, "Campaigns_Name", campaign.Campaigns_Name, "Hashtag", campaign.Hashtag);

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets campaign list. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <returns>   The campaign list. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<TBCampaigns> GetCampaignList()
        {
            return GetCampaignsG(insertCampigns, null, null, null, null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets data about campaign. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="campaignsId">  Identifier for the campaigns. </param>
        ///
        /// <returns>   The data about campaign. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MAboutCampaign GetDataAboutCampaign(string campaignsId)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            MAboutCampaign aboutCampaign = null;

            object aboutCampaignData = sqlQuery1.RunCommand(insertAboutCampaign, AddCampaignAboutData, SetValues, "Campaigns_Id", campaignsId, null, null);
            if (aboutCampaignData != null)
            {
                if (aboutCampaignData is MAboutCampaign)
                {
                    aboutCampaign = (MAboutCampaign)aboutCampaignData;
                }
            }
            return aboutCampaign;
        }
    }
}
