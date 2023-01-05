using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites
{
    public class NonProfitOrganizations
    {
        public List<TBNonProfitOrganization> CheckingIfExistUser(string UI)
        {
            DSNonProfitOrganizationsGet dSUserData = new DSNonProfitOrganizationsGet();
            return dSUserData.GetNonProfitUserRow(UI);
        }


        public void PostUsersOrganization(TBNonProfitOrganization userOrganizationData)
        {
            DSNonProfitOrganizationsPost usersComments = new DSNonProfitOrganizationsPost();
            usersComments.PostUsersData(userOrganizationData);
        }

    }
}
