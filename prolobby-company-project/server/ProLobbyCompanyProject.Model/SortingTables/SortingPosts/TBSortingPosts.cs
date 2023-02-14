using System;

namespace ProLobbyCompanyProject.Model.SortingTables.SortingPosts
{
    public class TBSortingPosts
    {
        public TBSortingPosts() { }
        public string Twitter_user { get; set; }
        public DateTime Date { get; set; }
        public int Amount_publications { get; set; }
        public string Campaigns_Name { get; set; }
        public string NonProfitOrganizationName { get; set; }
        public string Active { get; set; }
        public string Tweets_Message { get; set; }
        public int Retweets_Count { get; set; }
    }
}
