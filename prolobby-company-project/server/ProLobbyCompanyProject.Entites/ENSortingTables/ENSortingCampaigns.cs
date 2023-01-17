using ProLobbyCompanyProject.Data.Sql.SortingTables.SortingCampaigns;
using ProLobbyCompanyProject.Data.Sql.SortingTables.SortingUsers;
using ProLobbyCompanyProject.Model.SortingTables.SortingCampaigns;
using ProLobbyCompanyProject.Model.SortingTables.SortingUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites
{
    public class ENSortingCampaigns
    {
        public ENSortingCampaigns() { dSSortingCampaignsDefault = new DSSortingCampaignsDefault(); dSSortingCampaignsByAmountUsers = new DSSortingCampaignsByAmountUsers(); dSSortingCampaignsByAmountProducts = new DSSortingCampaignsByAmountProducts(); }

        DSSortingCampaignsDefault dSSortingCampaignsDefault;
        DSSortingCampaignsByAmountUsers dSSortingCampaignsByAmountUsers;
        DSSortingCampaignsByAmountProducts dSSortingCampaignsByAmountProducts;

        public List<TBSortingCampaigns> GetSortingCampaigns(string CaseOf)
        {
            if (CaseOf == "2") return dSSortingCampaignsDefault.GetByDate();

            else if (CaseOf == "4") return dSSortingCampaignsDefault.GetByOrganization();

            else if (CaseOf == "5") return dSSortingCampaignsDefault.GetByActivity();

            else if (CaseOf == "1") return dSSortingCampaignsByAmountUsers.GetSortingCampaignsByAmountUsers();
            else if (CaseOf == "3") return dSSortingCampaignsByAmountProducts.GetSortingCampaignsByProductAmount();

            else return null;
        }
    }
}
