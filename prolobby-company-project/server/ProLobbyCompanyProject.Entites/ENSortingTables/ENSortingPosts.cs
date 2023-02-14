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

            Logger.LogEvent("Initializing the classes in twitter constructor");

        }

        /// <summary>
        /// Get the reports by sorting.
        /// </summary>
        /// <param name="CaseOf"> Sort type from the client </param>
        /// <returns> list of reports by sorting. </returns>
        public List<TBSortingPosts> GetSortingPosts(string CaseOf)
        {
            Logger.LogEvent("\n\nEnter into GetSortingPosts function");

            if (CaseOf == "0") return dSSortingPostsDefault.GetByAll();

            else if(CaseOf == "1") return dSSortingPostsDefault.GetByDate();

            else if (CaseOf == "2") return dSSortingPostsDefault.GetByTweets();

            else if (CaseOf == "3") return dSSortingPostsDefault.GetByRetweetsCount();

            else return null;
        }
    }
}
