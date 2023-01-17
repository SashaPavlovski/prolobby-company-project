using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model.Campaigns;
using ProLobbyCompanyProject.Model;
using ProLobbyCompanyProject.Model.Twitter;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProLobbyCompanyProject.Model.SortingTables.SortingCampaigns;

namespace ProLobbyCompanyProject.Data.Sql.SortingTables.SortingCampaigns
{
    public class DSSortingCampaignsDefault
    {
        //Sorting campaigns by date, organization and activity
        public DSSortingCampaignsDefault () { }
        public object AddSortingCampaigns(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string campaignName)
        {
            List<TBSortingCampaigns> sortingCampaigns = new List<TBSortingCampaigns>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    sortingCampaigns.Add(new TBSortingCampaigns() { Campaigns_Name = reader["Campaigns_Name"].ToString(), NonProfitOrganizationName = reader["NonProfitOrganizationName"].ToString(), MoneyDonations = double.Parse(reader["MoneyDonations"].ToString()), Active = reader["Active"].ToString(),Date = DateTime.Parse(reader["Date"].ToString()) });

                }
                return sortingCampaigns;
            }
            return null;
        }



        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            return;
        }
        

        public string EnteringValueToInsert(string value)
        {

            string insert = $"select TB1.Campaigns_Name,CONVERT(NVARCHAR(10), TB1.[Date],3) AS [Date],\r\ncase when TB1.Active = 0 then 'inactive'\r\nelse 'active'end as 'Active',TB1.MoneyDonations,\r\nTB2.NonProfitOrganizationName from [dbo].[TBCampaigns] TB1 inner join [dbo].[TBNonProfitOrganizations] TB2\r\non  TB1.NonProfitOrganization_Id = TB2.NonProfitOrganization_Id ORDER BY {value}";
            return insert;
        }

        public List<TBSortingCampaigns> GetSortingCampaignsDefault(string insert)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBSortingCampaigns> sortingCampaigns = null;

            object listSortingCampaigns = sqlQuery1.RunCommand(insert, AddSortingCampaigns, SetValues, null, null, null, null); 
            if (listSortingCampaigns != null)
            {

                if (listSortingCampaigns is List<TBSortingCampaigns>)
                {
                    sortingCampaigns = (List<TBSortingCampaigns>)listSortingCampaigns;
                }
            }
            return sortingCampaigns;
        }
        public List<TBSortingCampaigns> GetByDate()
        {
            return GetSortingCampaignsDefault(EnteringValueToInsert("TB1.[Date]"));
        }
        public List<TBSortingCampaigns> GetByOrganization()
        {
            return GetSortingCampaignsDefault(EnteringValueToInsert("TB2.NonProfitOrganizationName"));
        }
        public List<TBSortingCampaigns> GetByActivity()
        {
            return GetSortingCampaignsDefault(EnteringValueToInsert("TB1.Active"));
        }
    }
}
