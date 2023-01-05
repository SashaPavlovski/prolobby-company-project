using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
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
        public void PostNonProfitOrganizationData(TBNonProfitOrganization organizationData)
        {
            nonProfitOrganizations2.PostUsersOrganization(organizationData);
        }
        public void PostNonProfitCompanyData(TBBusinessCompanyRepresentative companyData)
        {
            businessCompanyRepresentatives2.PostUsersCompanys(companyData);
        }
        public void PostProLobbyOwnerData(TBProLobbyOwner ownerData)
        {
            proLobbyOwner2.PostUsersOwner(ownerData);
        }
        public void PostSocialActivistsData(TBSocialActivists activistsData)
        {
            socialActivists2.PostUsersActivists(activistsData);
        }
    }
}
