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
    public class DSCampaignsGet
    {
        public DSCampaignsGet() { }

        public object AddCampaign(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string campaignName)
        {
            List<TBCampaigns> campaigns = new List<TBCampaigns>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    campaigns.Add(new TBCampaigns() { Campaigns_Id = int.Parse(reader["Campaigns_Id"].ToString()),Campaigns_Name = reader["Campaigns_Name"].ToString(),Descreption = reader["Descreption"].ToString(),Hashtag = reader["Hashtag"].ToString() });

                }
                return campaigns;
            }
            return null;
        }
        public object AddCampaignAboutData(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string campaignName)
        {
            if (reader.HasRows)
            {
                MAboutCampaign aboutCampaigns = null;

                while (reader.Read())
                {
                    aboutCampaigns = new MAboutCampaign() { NonProfitOrganizationName =reader["NonProfitOrganizationName"].ToString(), NonProfitOrganizationDecreption = reader["decreption"].ToString(), Url = reader["Url"].ToString(), Campaigns_Id = int.Parse( reader["Campaigns_Id"].ToString()), Campaigns_Name = reader["Campaigns_Name"].ToString(), Hashtag = reader["Hashtag"].ToString(), CampaignsDescreption = reader["Descreption"].ToString() };

                }
                return aboutCampaigns;
            }
            return null;
        }



        string insertIfExistCampign = "if exists (select  [Campaigns_Name] from [dbo].[TBCampaigns] where [Campaigns_Name] = @Campaigns_Name and [Active] = 1 )\r\nbegin\r\n       select [Campaigns_Name],[Hashtag],[Descreption],[Campaigns_Id]\r\n\t   from [dbo].[TBCampaigns]\r\n\t   where [Campaigns_Name] = @Campaigns_Name\r\nend";

        string insertCampigns = "if  exists (select * from [dbo].[TBCampaigns] where [Active] =1)\r\nbegin\r\n       select [Campaigns_Name],[Descreption],[Campaigns_Id],[Hashtag]\r\n\t   from [dbo].[TBCampaigns]\r\n\t   where [Active] = 1\r\nend";
        
        string insertAboutCampaign = "if  exists (select * from [dbo].[TBCampaigns] where [Active] =1)\r\nbegin\r\n        select Tb1.Url ,Tb1.NonProfitOrganizationName,\r\n        Tb1.decreption,Tb1.NonProfitOrganization_Id,\r\n        Tb2.Descreption,Tb2.Hashtag,Tb2.Campaigns_Name,\r\n        Tb2.Campaigns_Id from [dbo].[TBNonProfitOrganizations] Tb1 inner join [dbo].[TBCampaigns] Tb2\r\n        on  Tb1.NonProfitOrganization_Id = Tb2.NonProfitOrganization_Id where Tb2.Campaigns_Id = @Campaigns_Id\r\n\t\tand  Tb2.[Active] =1\r\nend";

        public List<TBCampaigns> GetCampaignsG(string insert,string key, string value )
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBCampaigns> campaigns = null;

            object listCampign = sqlQuery1.RunCommand(insert, AddCampaign, key, value); ;
            if (listCampign != null)
            {

                if (listCampign is List<TBCampaigns>)
                {
                    campaigns = (List<TBCampaigns>)listCampign;
                }
            }
            return campaigns;
        }
        public List<TBCampaigns> GetCampaignRow(TBCampaigns campaign)
        {
            return GetCampaignsG(insertIfExistCampign, "Campaigns_Name", campaign.Campaigns_Name);

        }
        public List<TBCampaigns> GetCampaignList()
        {
            return GetCampaignsG(insertCampigns, null, null);
        }
        public MAboutCampaign GetDataAboutCampaign(string campaignsId)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            MAboutCampaign aboutCampaign = null;

            object aboutCampaignData = sqlQuery1.RunCommand(insertAboutCampaign, AddCampaignAboutData, "Campaigns_Id", campaignsId); 
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
