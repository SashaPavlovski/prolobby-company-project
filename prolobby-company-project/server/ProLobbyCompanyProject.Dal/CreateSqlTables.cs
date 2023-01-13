////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	CreateSqlTables.cs
//
// summary:	Implements the create SQL tables class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Dal
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A create SQL tables. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CreateSqlTables : DbContext
    {
        /// <summary>   The data. </summary>
        private static CreateSqlTables data;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CreateSqlTables() : base("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProLobbyCompanyProject;Data Source=localhost\\SQLEXPRESS")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CreateSqlTables>());
            if ((SocialActivists.Count() == 0) || (Shippers.Count() == 0) || (ProLobbyOwner.Count() == 0) || (NonProfitOrganization.Count() == 0) || (MoneyTracking.Count() == 0) || (DonatedProducts.Count() == 0) || (Campaigns.Count() == 0) || (BusinessCompanyRepresentative.Count() == 0)) Seed();
            Database.Connection.Close();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the data. </summary>
        ///
        /// <value> The data. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static CreateSqlTables Data
        {
            get
            {
                if (data == null) data = new CreateSqlTables();
                return data;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Seed this object. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Seed()
        {
            if (BusinessCompanyRepresentative.Count() == 0)
            {
                TBBusinessCompanyRepresentative businessCompanyRepresentative = new TBBusinessCompanyRepresentative { CompanyName = "CompanyName", Email = "Email@gmail.com", Phone_number = "0525381648", RepresentativeFirstName = "RepresentativeFirstName", RepresentativeLastName = "RepresentativeLastName", Url = "@WWW.Url.com", User_Id = "111" };
                BusinessCompanyRepresentative.Add(businessCompanyRepresentative);
            }
            else if (Campaigns.Count() == 0)
            {
                TBCampaigns campaigns = new TBCampaigns { Campaigns_Name = "Campaigns_Name", Descreption = "Descreption", Hashtag = "#Hashtag", NonProfitOrganization_Id = 1, Active = false, MoneyDonations = 0 ,Date = DateTime.Now
            };
                Campaigns.Add(campaigns);
            }
            else if (DonatedProducts.Count() == 0)
            {
                TBDonatedProducts donatedProducts = new TBDonatedProducts { BusinessCompany_Id = 1, Campaigns_Id = 1, Price = 0, Product_Name = "Product_Name", Status_Product = 1 ,Active = true};
                DonatedProducts.Add(donatedProducts);
            }
            else if (MoneyTracking.Count() == 0)
            {
                TBMoneyTracking moneyTracking = new TBMoneyTracking { SocialActivists_Id = 1, Campaigns_Id = 1, Accumulated_money = 0, Active = true };
                MoneyTracking.Add(moneyTracking);
            }
            else if (NonProfitOrganization.Count() == 0)
            {
                TBNonProfitOrganization nonProfitOrganization = new TBNonProfitOrganization { decreption = "decreption", Email = "Email1@gmail.com", NonProfitOrganizationName = "NonProfitOrganizationName", Phone_number = "0525381648", User_Id = "111", RepresentativeFirstName = "RepresentativeFirstName", RepresentativeLastName = "RepresentativeLastName", Url = "@url.com" };
                NonProfitOrganization.Add(nonProfitOrganization);
            }
            else if (ProLobbyOwner.Count() == 0)
            {
                TBProLobbyOwner proLobbyOwner = new TBProLobbyOwner { Email = "Email2@gmail.com", FirstName = "FirstName", LastName = "LastName", Phone_number = "0525381628", User_Id = "111" };
                ProLobbyOwner.Add(proLobbyOwner);
            }
            else if (Shippers.Count() == 0)
            {
                TBShippers shippers = new TBShippers { Date = DateTime.Now.AddYears(+0), BusinessCompany_Id = 1, DonatedProducts_Id = 1, Sent = true, SocialActivists_Id = 1 };
                Shippers.Add(shippers);
            }
            else if (SocialActivists.Count() == 0)
            {
                TBSocialActivists socialActivists = new TBSocialActivists { Twitter_user = "Twitter_user", Address = "Address", FirstName = "FirstName", LastName = "LastName", Email = "Email3@gmail.com", Phone_number = "0525381628", User_Id = "111" };
                SocialActivists.Add(socialActivists);
            }
            SaveChanges();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the business company representative. </summary>
        ///
        /// <value> The business company representative. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DbSet<TBBusinessCompanyRepresentative> BusinessCompanyRepresentative { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the campaigns. </summary>
        ///
        /// <value> The campaigns. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DbSet<TBCampaigns> Campaigns { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the donated products. </summary>
        ///
        /// <value> The donated products. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DbSet<TBDonatedProducts> DonatedProducts { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the money tracking. </summary>
        ///
        /// <value> The money tracking. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DbSet<TBMoneyTracking> MoneyTracking { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the non profit organization. </summary>
        ///
        /// <value> The non profit organization. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DbSet<TBNonProfitOrganization> NonProfitOrganization { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the pro lobby that owns this item. </summary>
        ///
        /// <value> The pro lobby owner. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DbSet<TBProLobbyOwner> ProLobbyOwner { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the shippers. </summary>
        ///
        /// <value> The shippers. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DbSet<TBShippers> Shippers { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the social activists. </summary>
        ///
        /// <value> The social activists. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DbSet<TBSocialActivists> SocialActivists { get; set; }
    }
}
