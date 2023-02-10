using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Data.Sql.Campaigns;
using ProLobbyCompanyProject.Data.Sql.NonProfitOrganizations;
using ProLobbyCompanyProject.Data.Sql.SortingTables.SortingCampaigns;
using ProLobbyCompanyProject.Model.SortingTables.SortingCampaigns;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites
{
    public partial class NonProfitOrganizations: BaseEntity
    {

        DSSortingCampaignsDefault dSSortingCampaignsDefault;
        DSSortingCampaignsByAmountUsers dSSortingCampaignsByAmountUsers;
        DSSortingCampaignsByAmountProducts dSSortingCampaignsByAmountProducts;

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

        /// <summary>
        /// Get the reports by sorting.
        /// </summary>
        /// <param name="CaseOf"> Sort type from the client </param>
        /// <returns> list of reports by sorting. </returns>
        public List<TBSortingCampaigns> GetSortingCampaigns(string CaseOf)
        {
            Logger.LogEvent("Enter into GetSortingCampaigns function");

            if (CaseOf == "2") return dSSortingCampaignsDefault.GetByDate();

            else if (CaseOf == "4") return dSSortingCampaignsDefault.GetByOrganization();

            else if (CaseOf == "5") return dSSortingCampaignsDefault.GetByActivity();

            else if (CaseOf == "1") return dSSortingCampaignsByAmountUsers.GetSortingCampaignsByAmountUsers();
          
            else if (CaseOf == "3") return dSSortingCampaignsByAmountProducts.GetSortingCampaignsByProductAmount();

            else return null;
        }
    }
}
