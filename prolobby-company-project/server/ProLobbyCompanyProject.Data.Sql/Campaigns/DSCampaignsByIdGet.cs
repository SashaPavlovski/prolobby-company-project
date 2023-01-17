using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model.Campaigns;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.Campaigns
{
    public class DSCampaignsByIdGet
    {
        public DSCampaignsByIdGet() { }

        //Receiving campaign details
        //With organization's id
        public object AddCampaignById(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string campaignName)
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

  


        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            command.Parameters.AddWithValue($"@{key}", int.Parse(value));
        }


        string insertCampaignsById = "if  exists (select * from [dbo].[TBCampaigns] where [Active] =1 and [NonProfitOrganization_Id] = @NonProfitOrganization_Id)\r\nbegin\r\n       select [Campaigns_Name],[Descreption],[Campaigns_Id],[Hashtag]\r\n\t   from [dbo].[TBCampaigns]\r\n\t   where [Active] = 1 and [NonProfitOrganization_Id] = @NonProfitOrganization_Id\r\nend";

        //Enter the details of the campaign into a list
        public List<TBCampaigns> GetCampaignsById(string organizationId )
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBCampaigns> campaignsById = null;

            object listCampign = sqlQuery1.RunCommand(insertCampaignsById, AddCampaignById, SetValues, "NonProfitOrganization_Id", organizationId, null, null); ;
            if (listCampign != null)
            {

                if (listCampign is List<TBCampaigns>)
                {
                    campaignsById = (List<TBCampaigns>)listCampign;
                }
            }
            return campaignsById;
        }

    }
}
