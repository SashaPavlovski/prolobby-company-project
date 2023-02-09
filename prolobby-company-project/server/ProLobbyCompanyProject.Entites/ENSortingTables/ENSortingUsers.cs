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

        public List<TBSortingUsers> GetSortingUsers(string CaseOf)
        {
            if (CaseOf == "1") return dSSortingUsersByOrganization.GetByOrganizations();

            else if (CaseOf == "2") return dSSortingUsersByCompany.GetByCompany();

            else if (CaseOf == "3") return dSSortingUsersDefault.GetByProLobbyOwners();

            else if (CaseOf == "4") return dSSortingUsersDefault.GetBySocialActivists();

            else return null;
        }
    }
}
