using ProLobbyCompanyProject.Data.Sql.SortingTables.SortingCampaigns;
using ProLobbyCompanyProject.Data.Sql.SortingTables.SortingUsers;
using ProLobbyCompanyProject.Model.SortingTables.SortingCampaigns;
using ProLobbyCompanyProject.Model.SortingTables.SortingUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites.ENSortingTables
{
    public class ENSortingUsers
    {
        public ENSortingUsers() { dSSortingUsersDefault = new DSSortingUsersDefault(); dSSortingUsersByCompany = new DSSortingUsersByCompany(); dSSortingUsersByOrganization = new DSSortingUsersByOrganization(); }

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
