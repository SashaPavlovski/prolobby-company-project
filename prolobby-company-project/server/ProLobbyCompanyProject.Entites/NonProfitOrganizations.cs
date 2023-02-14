using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Data.Sql.Campaigns;
using ProLobbyCompanyProject.Data.Sql.NonProfitOrganizations;
using ProLobbyCompanyProject.Data.Sql.SortingTables.SortingCampaigns;
using ProLobbyCompanyProject.Model;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites
{
    public partial class NonProfitOrganizations: BaseEntity
    {
        DSNonProfitOrganizationsGet dSUserData;
        DSNonProfitOrganizationsPost usersComments;
        DSNonProfitOrganizationsUpdate usersNewData;

        public NonProfitOrganizations(Logger logger) : base(logger)
        {
            dSSortingCampaignsDefault = new DSSortingCampaignsDefault(base.Logger);
            dSSortingCampaignsByAmountUsers = new DSSortingCampaignsByAmountUsers(base.Logger);
            dSSortingCampaignsByAmountProducts = new DSSortingCampaignsByAmountProducts(base.Logger);
            dSCampaignsGet = new DSCampaignsGet(base.Logger);
            dSCampaignsPost = new DSCampaignsPost(base.Logger);
            dSCampaignsByIdGet = new DSCampaignsByIdGet(base.Logger);
            dSCampaignsDelete = new DSCampaignsDelete(base.Logger);
            dSUserData = new DSNonProfitOrganizationsGet(base.Logger);
            usersComments = new DSNonProfitOrganizationsPost(base.Logger);
            usersNewData = new DSNonProfitOrganizationsUpdate(base.Logger);

            Logger.LogEvent("Initializing the classes in NonProfitOrganizations constructor");

        }

        //Checking whether there is a user representative of an organization
        public List<TBNonProfitOrganization> CheckingIfExistUser(string UI)
        {
            Logger.LogEvent("\n\nEnter into CheckingIfExistUser function");

            return dSUserData.GetNonProfitUserRow(UI);
        }

        //Entering data of an organization representative
        public void PostUsersOrganization(TBNonProfitOrganization userOrganizationData)
        {
            Logger.LogEvent("\n\nEnter into PostUsersOrganization function");

            usersComments.PostUsersData(userOrganizationData);

            Logger.LogEvent("End PostUsersOrganization function");

        }

        //Updating data of an organization representative
        public void UpdateActivist(TBNonProfitOrganization updateUserData)
        {
            Logger.LogEvent("\n\nEnter into UpdateActivist function");

            usersNewData.UpdateUsersData(updateUserData);

            Logger.LogEvent("End UpdateActivist function");

        }

    }
}
