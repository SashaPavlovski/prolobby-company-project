using ProLobbyCompanyProject.Data.Sql.SortingTables.SortingCampaigns;
using ProLobbyCompanyProject.Model.SortingTables.SortingCampaigns;
using System.Collections.Generic;

namespace ProLobbyCompanyProject.Entites
{
    public partial class NonProfitOrganizations: BaseEntity
    {

        DSSortingCampaignsDefault dSSortingCampaignsDefault;
        DSSortingCampaignsByAmountUsers dSSortingCampaignsByAmountUsers;
        DSSortingCampaignsByAmountProducts dSSortingCampaignsByAmountProducts;


        /// <summary>
        /// Get the reports by sorting.
        /// </summary>
        /// <param name="CaseOf"> Sort type from the client </param>
        /// <returns> list of reports by sorting. </returns>
        public List<TBSortingCampaigns> GetSortingCampaigns(string CaseOf)
        {
            Logger.LogEvent("\n\nEnter into GetSortingCampaigns function");

            if (CaseOf == "2") return dSSortingCampaignsDefault.GetByDate();

            else if (CaseOf == "4") return dSSortingCampaignsDefault.GetByOrganization();

            else if (CaseOf == "5") return dSSortingCampaignsDefault.GetByActivity();

            else if (CaseOf == "1") return dSSortingCampaignsByAmountUsers.GetSortingCampaignsByAmountUsers();
          
            else if (CaseOf == "3") return dSSortingCampaignsByAmountProducts.GetSortingCampaignsByProductAmount();

            else return null;
        }
    }
}