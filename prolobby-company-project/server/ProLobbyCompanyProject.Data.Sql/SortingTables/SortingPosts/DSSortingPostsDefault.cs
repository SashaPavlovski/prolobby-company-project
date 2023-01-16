using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model.SortingTables.SortingCampaigns;
using ProLobbyCompanyProject.Model.SortingTables.SortingPosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.SortingTables.SortingPosts
{
    public class DSSortingPostsDefault
    {
        public DSSortingPostsDefault() { }

        public object AddSortingCampaigns(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string campaignName)
        {
            List<TBSortingPosts> sortingPosts = new List<TBSortingPosts>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    sortingPosts.Add(new TBSortingPosts() { Campaigns_Name = reader["Campaigns_Name"].ToString(), Twitter_user = reader["Twitter_user"].ToString(),Date = DateTime.Parse(reader["Date"].ToString()), Amount_publications = int.Parse(reader["Amount_publications"].ToString()),NonProfitOrganizationName = reader["NonProfitOrganizationName"].ToString(),Active = reader["Active"].ToString() });

                }
                return sortingPosts;
            }
            return null;
        }



        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            return;
        }

    
        public string EnteringValueToInsert(string value)
        {

            string insert = $"select CONVERT(NVARCHAR(10), TB1.[Date],3) AS [Date],TB1.Amount_publications,\r\ncase when TB1.Active = 0 then 'inactive'\r\nelse 'active'end as 'Active',\r\nTB2.Twitter_user,\r\nTB3.Campaigns_Name,TB4.NonProfitOrganizationName\r\nfrom [dbo].[TBPostsTrackings] TB1 inner join [dbo].[TBSocialActivists] TB2\r\non  TB1.SocialActivists_Id = TB2.SocialActivists_Id inner join [dbo].[TBCampaigns] TB3\r\non  TB1.Campaigns_Id = TB3.Campaigns_Id inner join [dbo].[TBNonProfitOrganizations] TB4\r\non  TB3.NonProfitOrganization_Id = TB4.NonProfitOrganization_Id ORDER BY {value}";
            return insert;
        }

        public List<TBSortingPosts> GetSortingPostsDefault(string insert)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBSortingPosts> sortingPosts = null;

            object listSortingPosts = sqlQuery1.RunCommand(insert, AddSortingCampaigns, SetValues, null, null, null, null);
            if (listSortingPosts != null)
            {

                if (listSortingPosts is List<TBSortingPosts>)
                {
                    sortingPosts = (List<TBSortingPosts>)listSortingPosts;
                }
            }
            return sortingPosts;
        }
        public List<TBSortingPosts> GetByDate()
        {
            return GetSortingPostsDefault(EnteringValueToInsert("TB1.[Date]"));
        }
        public List<TBSortingPosts> GetByTweets()
        {
            return GetSortingPostsDefault(EnteringValueToInsert("TB1.Amount_publications desc"));
        }


    }
}
