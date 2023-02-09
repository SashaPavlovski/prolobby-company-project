using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Data.Sql.NonProfitOrganizations;
using ProLobbyCompanyProject.Model;
using System.Collections.Generic;

namespace ProLobbyCompanyProject.Entites
{
    public partial class NonProfitOrganizations: BaseEntity
    {
        DSNonProfitOrganizationsGet dSUserData;
        DSNonProfitOrganizationsPost usersComments;
        DSNonProfitOrganizationsUpdate usersNewData;

        //Checking whether there is a user representative of an organization
        public List<TBNonProfitOrganization> CheckingIfExistUser(string UI)
        {
            Logger.LogEvent("Enter into CheckingIfExistUser function");

            return dSUserData.GetNonProfitUserRow(UI);
        }

        //Entering data of an organization representative
        public void PostUsersOrganization(TBNonProfitOrganization userOrganizationData)
        {
            Logger.LogEvent("Enter into PostUsersOrganization function");

            usersComments.PostUsersData(userOrganizationData);

            Logger.LogEvent("End PostUsersOrganization function");

        }

        //Updating data of an organization representative
        public void UpdateActivist(TBNonProfitOrganization updateUserData)
        {
            Logger.LogEvent("Enter into UpdateActivist function");

            usersNewData.UpdateUsersData(updateUserData);

            Logger.LogEvent("End UpdateActivist function");

        }

    }
}
