using ProLobbyCompanyProject.Data.Sql.SortingTables.SortingCampaigns;
using ProLobbyCompanyProject.Data.Sql.SortingTables.SortingPosts;
using ProLobbyCompanyProject.Model.SortingTables.SortingCampaigns;
using ProLobbyCompanyProject.Model.SortingTables.SortingPosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites.ENSortingTables
{
    public class ENSortingPosts
    {
        public ENSortingPosts() { dSSortingPostsDefault = new DSSortingPostsDefault(); }

        DSSortingPostsDefault dSSortingPostsDefault;

        public List<TBSortingPosts> GetSortingPosts(string CaseOf)
        {
            if (CaseOf == "1") return dSSortingPostsDefault.GetByDate();

            else if (CaseOf == "2") return dSSortingPostsDefault.GetByTweets();

            else return null;
        }
    }
}
