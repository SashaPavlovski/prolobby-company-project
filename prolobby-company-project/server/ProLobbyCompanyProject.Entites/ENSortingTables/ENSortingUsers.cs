using ProLobbyCompanyProject.Data.Sql.SortingTables.SortingUsers;
using ProLobbyCompanyProject.Model.SortingTables.SortingUsers;
using System.Collections.Generic;

namespace ProLobbyCompanyProject
{
    public partial class Twitter
    {
        DSSortingUsersDefault dSSortingUsersDefault;
        DSSortingUsersByCompany dSSortingUsersByCompany;
        DSSortingUsersByOrganization dSSortingUsersByOrganization;

        /// <summary>
        /// Get the reports by sorting.
        /// </summary>
        /// <param name="CaseOf"> Sort type from the client </param>
        /// <returns> list of reports by sorting. </returns>
        public List<TBSortingUsers> GetSortingUsers(string CaseOf)
        {
            Logger.LogEvent("\n\nEnter into GetSortingUsers function");

            Logger.LogEvent("Sorting the report table of the users");

            if (CaseOf == "1") return dSSortingUsersByOrganization.GetByOrganizations();

            else if (CaseOf == "2") return dSSortingUsersByCompany.GetByCompany();

            else if (CaseOf == "3") return dSSortingUsersDefault.GetByProLobbyOwners();

            else if (CaseOf == "4") return dSSortingUsersDefault.GetBySocialActivists();

            else return null;
        }
    }
}
