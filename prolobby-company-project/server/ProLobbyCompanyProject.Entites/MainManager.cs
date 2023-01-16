////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	MainManager.cs
//
// summary:	Implements the main manager class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Data.Sql.Campaigns;
using ProLobbyCompanyProject.Entites.ENSortingTables;
using ProLobbyCompanyProject.Model;
using ProLobbyCompanyProject.Model.Campaigns;
using ProLobbyCompanyProject.Model.MoneyTracking;
using ProLobbyCompanyProject.Model.Shippers;
using ProLobbyCompanyProject.Model.SortingTables.SortingCampaigns;
using ProLobbyCompanyProject.Model.SortingTables.SortingPosts;
using ProLobbyCompanyProject.Model.SortingTables.SortingProducts;
using ProLobbyCompanyProject.Model.SortingTables.SortingUsers;
using ProLobbyCompanyProject.Model.Twitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for mains. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class MainManager
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MainManager() { }

        /// <summary>   The instance. </summary>
        private readonly static MainManager _INSTANCE = new MainManager();
        /// <summary>   The SQL. </summary>
        SqlQuery sql;
        /// <summary>   The second business company representatives. </summary>
        BusinessCompanyRepresentatives businessCompanyRepresentatives2;
        /// <summary>   The second pro lobby owner. </summary>
        ProLobbyOwner proLobbyOwner2;
        /// <summary>   The second social activists. </summary>
        SocialActivists socialActivists2;
        /// <summary>   The second non profit organizations. </summary>
        NonProfitOrganizations nonProfitOrganizations2;
        /// <summary>   The second campaigns. </summary>
        Campaigns campaigns2;
        /// <summary>   The second donated products. </summary>
        DonatedProducts donatedProducts2;
        /// <summary>   The second money tracking. </summary>
        MoneyTracking moneyTracking2;
        /// <summary>   The second shippers. </summary>
        Shippers shippers2;
        /// <summary>   The second twitter. </summary>
        Twitter twitter2;
        ENSortingCampaigns eNSortingCampaigns2;
        ENSortingPosts eNSortingPosts2;
        ENSortingProducts eNSortingProducts2;
        ENSortingUsers eNSortingUsers2;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the instance. </summary>
        ///
        /// <value> The instance. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static MainManager INSTANCE
        {
            get { return _INSTANCE; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   S this object. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init()
        {
            InitClasses();
            sql.CreateTables();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Init classes. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void InitClasses()
        {

            sql = new SqlQuery();
            businessCompanyRepresentatives2 = new BusinessCompanyRepresentatives();
            proLobbyOwner2 = new ProLobbyOwner();
            socialActivists2 = new SocialActivists();
            nonProfitOrganizations2 = new NonProfitOrganizations();
            campaigns2 = new Campaigns();
            donatedProducts2 = new DonatedProducts();
            moneyTracking2 = new MoneyTracking();
            shippers2 = new Shippers();
            twitter2 = new Twitter();
            eNSortingCampaigns2 = new ENSortingCampaigns();
            eNSortingPosts2 = new ENSortingPosts();
            eNSortingProducts2 = new ENSortingProducts();
            eNSortingUsers2 = new ENSortingUsers();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Checking business company representative. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="idUser">   The identifier user. </param>
        ///
        /// <returns>   A List&lt;TBBusinessCompanyRepresentative&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<TBBusinessCompanyRepresentative> CheckingBusinessCompanyRepresentative(string idUser)
        {
            Init();
            return businessCompanyRepresentatives2.CheckingIfExistUser(idUser);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Checking terabytes pro lobby owner. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="idUser">   The identifier user. </param>
        ///
        /// <returns>   A List&lt;TBProLobbyOwner&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<TBProLobbyOwner> CheckingTBProLobbyOwner(string idUser)
        {
            Init();
            return proLobbyOwner2.CheckingIfExistUser(idUser);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Checking terabytes non profit organization. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="idUser">   The identifier user. </param>
        ///
        /// <returns>   A List&lt;TBNonProfitOrganization&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<TBNonProfitOrganization> CheckingTBNonProfitOrganization(string idUser)
        {
            Init();
            return nonProfitOrganizations2.CheckingIfExistUser(idUser);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Checking terabytes social activists. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="idUser">   The identifier user. </param>
        ///
        /// <returns>   A List&lt;TBSocialActivists&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<TBSocialActivists> CheckingTBSocialActivists(string idUser)
        {
            Init();
            return socialActivists2.CheckingIfExistUser(idUser);
        }

        //******************************************************************

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts a non profit organization data. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="organizationData"> Information describing the organization. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PostNonProfitOrganizationData(TBNonProfitOrganization organizationData)
        {
            if (organizationData == null) return;
            InitClasses();
            nonProfitOrganizations2.PostUsersOrganization(organizationData);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts a non profit company data. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="companyData">  Information describing the company. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PostNonProfitCompanyData(TBBusinessCompanyRepresentative companyData)
        {
            if (companyData == null) return;
            InitClasses();
            businessCompanyRepresentatives2.PostUsersCompanys(companyData);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts a pro lobby owner data. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="ownerData">    The data that owns this item. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PostProLobbyOwnerData(TBProLobbyOwner ownerData)
        {
            InitClasses();
            proLobbyOwner2.PostUsersOwner(ownerData);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts a social activists data. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="activistsData">    Information describing the activists. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PostSocialActivistsData(TBSocialActivists activistsData)
        {
            if (activistsData == null) return;
            InitClasses();
            socialActivists2.PostUsersActivists(activistsData);
        }

        //*******************************************************************

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the social activists data described by activistsData. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="activistsData">    Information describing the activists. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void UpdateSocialActivistsData(TBSocialActivists activistsData)
        {
            if (activistsData == null) return;
            InitClasses();
            socialActivists2.UpdateActivist(activistsData);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the pro lobby owner data described by activistsData. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="activistsData">    Information describing the activists. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void UpdateProLobbyOwnerData(TBProLobbyOwner activistsData)
        {

            if (activistsData == null) return;
            InitClasses();
            proLobbyOwner2.UpdateActivist(activistsData);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the organization data described by activistsData. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="activistsData">    Information describing the activists. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void UpdateOrganizationData(TBNonProfitOrganization activistsData)
        {
            if (activistsData == null) return;
            InitClasses();
            nonProfitOrganizations2.UpdateActivist(activistsData);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the business company data described by activistsData. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="activistsData">    Information describing the activists. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void UpdateBusinessCompanyData(TBBusinessCompanyRepresentative activistsData)
        {
            if (activistsData == null) return;
            InitClasses();
            businessCompanyRepresentatives2.UpdateActivist(activistsData);
        }

        //*******************************************************************

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Checking terabytes campaigns name. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="Campaign"> The campaign. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string CheckingTBCampaignsName(TBCampaigns Campaign)
        {
            if (Campaign == null) return null;
            InitClasses();
            return campaigns2.GetCampaignName(Campaign);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets terabytes campaigns. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <returns>   The terabytes campaigns. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<TBCampaigns> GetTBCampaigns()
        {
            InitClasses();
            return campaigns2.GetCampaigns();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets m about campaign. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="campaignsId">  Identifier for the campaigns. </param>
        ///
        /// <returns>   The m about campaign. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MAboutCampaign GetMAboutCampaign(string campaignsId)
        {
            if (campaignsId == null) return null;
            InitClasses();
            return campaigns2.GetAboutCampaign(campaignsId);

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes the campaign described by campaignId. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="campaignId">   Identifier for the campaign. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void RemoveCampaign(string campaignId)
        {
            if (campaignId == null) return;
            InitClasses();
            campaigns2.RemoveCampaignData(campaignId);
        }
        public List<TBCampaigns> GetCampaignsOrganizationById(string organizationId)
        {
            if (organizationId == null) return null;
            InitClasses();
            return campaigns2.GetByIdCampaigns(organizationId);
        }


        //*******************************************************************

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets donated products. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="campaignsId">  Identifier for the campaigns. </param>
        ///
        /// <returns>   The donated products. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<TBDonatedProducts> GetDonatedProducts(string campaignsId)
        {
            if (campaignsId == null) return null;
            InitClasses();
            return donatedProducts2.GetCampaignProducts(campaignsId);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts a donated product. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="donatedProduct">   The donated product. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PostDonatedProduct(TBDonatedProducts donatedProduct)
        {
            if (donatedProduct == null) return;
            InitClasses();
            donatedProducts2.PostProduct(donatedProduct);
        }

        //**********************************************************************

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts a money tracking. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="moneyTracking">    The money tracking. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PostMoneyTracking(TBMoneyTracking moneyTracking)
        {
            if (moneyTracking == null) return;
            InitClasses();
            moneyTracking2.PostDataTracking(moneyTracking);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets money tracking. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="idUser">   The identifier user. </param>
        ///
        /// <returns>   The money tracking. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<MAMoneyTracking> GetMoneyTracking(string idUser)
        {
            if (idUser == null) return null;
            InitClasses();
            return moneyTracking2.GetMoneyData(idUser);
        }

        //**********************************************************************

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Buy product. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="productData">  Information describing the product. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string BuyProduct(MAbuyProduct productData)
        {
            if (productData == null) return null;
            InitClasses();
            return shippers2.PostProduct(productData);
        }
        public string DonationProduct(MAbuyProduct productData)
        {
            if (productData == null) return null;
            InitClasses();
            return shippers2.PostDonationProduct(productData);
        }

        public List<TBDonatedProducts> GetUserProductsByUserId(string userId)
        {
            if (userId == null) return null;
            return donatedProducts2.GetByUserIdProducts(userId);

        }

        public List<MADeliveryProductList> GetDeliveryDataProductList()
        {
            InitClasses();
            return shippers2.GetDeliveryList();
        }

        public void SetDeliveryProduct(string idUser)
        {
            if (idUser == null) return ;
            InitClasses();
            shippers2.SetProductDelivery(idUser);
        }

        //**********************************************************************

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets twitter user data. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <returns>   The twitter user data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<MATwitter> GetTwitterUserData()
        {
            InitClasses();
            return twitter2.GetTwitterData();
        }

        public void UpdateNewUserMoneyTracking (MATwitter userTwitterMoney, double UserMoney)
        {
            if (userTwitterMoney == null || UserMoney == 0) return;
            InitClasses();
            twitter2.UpdateMoneyTracking(userTwitterMoney, UserMoney);
        }

        public bool CheckingIfExistPosts()
        {
            InitClasses();
            return twitter2.IfExistPosts();
        }

        //**********************************************************************

        public List<TBSortingCampaigns> GetReportsCampaigns(string CaseOf)
        {
            InitClasses();
            return eNSortingCampaigns2.GetSortingCampaigns(CaseOf);
        }
        public List<TBSortingPosts> GetReportsPosts(string CaseOf)
        {
            InitClasses();
            return eNSortingPosts2.GetSortingPosts(CaseOf);
        }
        public List<TBSortingProducts> GetReportsProducts(string CaseOf)
        {
            InitClasses();
            return eNSortingProducts2.GetSortingProducts(CaseOf);
        }

        public List<TBSortingUsers> GetReportsUsers(string CaseOf)
        {
            InitClasses();
            return eNSortingUsers2.GetSortingUsers(CaseOf);
        }

    }
}
