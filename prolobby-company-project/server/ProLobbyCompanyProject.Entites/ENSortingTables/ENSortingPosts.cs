using ProLobbyCompanyProject.Data.Sql.SortingTables.SortingPosts;
using ProLobbyCompanyProject.Data.Sql.SortingTables.SortingUsers;
using ProLobbyCompanyProject.Entites;
using ProLobbyCompanyProject.Model.SortingTables.SortingPosts;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject
{
    public partial class Twitter : BaseEntity
    {
        DSSortingPostsDefault dSSortingPostsDefault;
        public Twitter(Logger logger) : base(logger)
        {
            dSSortingPostsDefault = new DSSortingPostsDefault(base.Logger);
            dSSortingUsersDefault = new DSSortingUsersDefault(base.Logger);
            dSSortingUsersByCompany = new DSSortingUsersByCompany(base.Logger);
            dSSortingUsersByOrganization = new DSSortingUsersByOrganization(base.Logger);
        }
        public List<TBSortingPosts> GetSortingPosts(string CaseOf)
        {
            if (CaseOf == "1") return dSSortingPostsDefault.GetByDate();

            else if (CaseOf == "2") return dSSortingPostsDefault.GetByTweets();

            else return null;
        }
    }
}
