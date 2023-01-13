////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	ConnectionWithSql.cs
//
// summary:	Implements the connection with SQL class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProLobbyCompanyProject.Dal
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A connection with sql. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ConnectionWithSql
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ConnectionWithSql() { }

        /// <summary>   The connection with SQL. </summary>
        private readonly static ConnectionWithSql connectionWithSql = new ConnectionWithSql();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the connection with SQL. </summary>
        ///
        /// <value> The connection with SQL. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static ConnectionWithSql _ConnectionWithSql
        {
            get { return connectionWithSql; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates the tables. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
