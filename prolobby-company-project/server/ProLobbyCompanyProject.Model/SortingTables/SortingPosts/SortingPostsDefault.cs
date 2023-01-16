using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Model.SortingTables.SortingPosts
{
    public class SortingPostsDefault
    {
        public SortingPostsDefault() { }
        public string Twitter_user { get; set; }
        public DateTime Date { get; set; }
        public int Amount_publications { get; set; }
        public string Campaigns_Name { get; set; }
        public string NonProfitOrganizationName { get; set; }
        public string Active { get; set; }
    }
}
