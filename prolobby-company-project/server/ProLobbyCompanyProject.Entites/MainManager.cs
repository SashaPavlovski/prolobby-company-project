using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using ProLobbyCompanyProject.Model.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites
{
    public class MainManager
    {
        public MainManager() { }

        private readonly static MainManager _INSTANCE = new MainManager();
        SqlQuery sql;
        BusinessCompanyRepresentatives businessCompanyRepresentatives2;
        ProLobbyOwner proLobbyOwner2;
        SocialActivists socialActivists2;
        NonProfitOrganizations nonProfitOrganizations2;
        Campaigns campaigns2;
        DonatedProducts donatedProducts2;

        public static MainManager INSTANCE
        {
            get { return _INSTANCE; }
        }
        public void Init()
        {

            sql = new SqlQuery();
            businessCompanyRepresentatives2 = new BusinessCompanyRepresentatives();
            proLobbyOwner2 = new ProLobbyOwner();
            socialActivists2 = new SocialActivists();
            nonProfitOrganizations2 = new NonProfitOrganizations();
            sql.CreateTables();
        }
        public void InitClasses()
        {
            campaigns2 = new Campaigns();
            donatedProducts2 = new DonatedProducts();
        }


        public List<TBBusinessCompanyRepresentative> CheckingBusinessCompanyRepresentative(string idUser)
        {
            Init();
            return businessCompanyRepresentatives2.CheckingIfExistUser(idUser);
        }
        public List<TBProLobbyOwner> CheckingTBProLobbyOwner(string idUser)
        {
            Init();
            return proLobbyOwner2.CheckingIfExistUser(idUser);
        }
        public List<TBNonProfitOrganization> CheckingTBNonProfitOrganization(string idUser)
        {
            Init();
            return nonProfitOrganizations2.CheckingIfExistUser(idUser);
        }

        public List<TBSocialActivists> CheckingTBSocialActivists(string idUser)
        {
            Init();
            return socialActivists2.CheckingIfExistUser(idUser);
        }

        //******************************************************************
        public void PostNonProfitOrganizationData(TBNonProfitOrganization organizationData)
        {
            if (organizationData == null) return;

            nonProfitOrganizations2.PostUsersOrganization(organizationData);
        }
        public void PostNonProfitCompanyData(TBBusinessCompanyRepresentative companyData)
        {
            if (companyData == null) return;

            businessCompanyRepresentatives2.PostUsersCompanys(companyData);
        }
        public void PostProLobbyOwnerData(TBProLobbyOwner ownerData)
        {
            proLobbyOwner2.PostUsersOwner(ownerData);
        }
        public void PostSocialActivistsData(TBSocialActivists activistsData)
        {
            if (activistsData == null) return;

            socialActivists2.PostUsersActivists(activistsData);
        }

        //*******************************************************************
        public void UpdateSocialActivistsData(TBSocialActivists activistsData)
        {
            if (activistsData == null) return;

            socialActivists2.UpdateActivist(activistsData);
        }
        public void UpdateProLobbyOwnerData(TBProLobbyOwner activistsData)
        {

            if (activistsData == null) return;
            proLobbyOwner2.UpdateActivist(activistsData);
        }
        public void UpdateOrganizationData(TBNonProfitOrganization activistsData)
        {
            if (activistsData == null) return;

            nonProfitOrganizations2.UpdateActivist(activistsData);
        }
        public void UpdateBusinessCompanyData(TBBusinessCompanyRepresentative activistsData)
        {
            if (activistsData == null) return;

            businessCompanyRepresentatives2.UpdateActivist(activistsData);
        }

        //*******************************************************************
        public string CheckingTBCampaignsName (TBCampaigns Campaign) {
            if (Campaign == null) return null;
            InitClasses();
            return campaigns2.GetCampaignName(Campaign);
        }

        public List<TBCampaigns> GetTBCampaigns()
        {
            InitClasses();
            return campaigns2.GetCampaigns();
        }

        public MAboutCampaign GetMAboutCampaign( string campaignsId)
        {
            if(campaignsId == null) return null;
            return campaigns2.GetAboutCampaign(campaignsId);

        }

        public void RemoveCampaign (string campaignId)
        {
            if (campaignId == null) return;

            campaigns2.RemoveCampaignData(campaignId);
        }

        //*******************************************************************

        public List<TBDonatedProducts> GetDonatedProducts(string campaignsId)
        {
            if (campaignsId == null) return null;
            InitClasses();
            return donatedProducts2.GetCampaignProducts(campaignsId);
        }
        public void PostDonatedProduct(TBDonatedProducts donatedProduct)
        {
            if (donatedProduct == null) return;

            donatedProducts2.PostProduct(donatedProduct);
        }
    }
}
