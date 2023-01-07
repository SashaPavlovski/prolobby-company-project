using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProLobbyCompanyProject.Dal
{
    public class ConnectionWithSql
    {
        public ConnectionWithSql() { }

        private  readonly static ConnectionWithSql connectionWithSql = new ConnectionWithSql();

        public static  ConnectionWithSql _ConnectionWithSql
        {
            get { return connectionWithSql; }
        }


        public void CreateTables()
        {
            List<TBBusinessCompanyRepresentative> BusinessCompanyRepresentative1 = CreateSqlTables.Data.BusinessCompanyRepresentative.ToList();

            List<TBCampaigns> Campaigns1 = CreateSqlTables.Data.Campaigns.ToList();

            List<TBDonatedProducts> DonatedProducts1 = CreateSqlTables.Data.DonatedProducts.ToList();
            List<TBMoneyTracking> MoneyTracking1 = CreateSqlTables.Data.MoneyTracking.ToList();

            List<TBNonProfitOrganization> NonProfitOrganization1 = CreateSqlTables.Data.NonProfitOrganization.ToList();

            List<TBProLobbyOwner> ProLobbyOwner1 = CreateSqlTables.Data.ProLobbyOwner.ToList();

            List<TBShippers> Shippers1 = CreateSqlTables.Data.Shippers.ToList();

            List<TBSocialActivists> SocialActivists1 = CreateSqlTables.Data.SocialActivists.ToList();
        }
    }
}
