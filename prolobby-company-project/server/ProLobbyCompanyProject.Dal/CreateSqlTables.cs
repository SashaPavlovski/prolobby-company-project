
using ProLobbyCompanyProject.Model;
using ProLobbyCompanyProject.Model.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

// CreateSqlTables.cs
// Implements the create SQL tables class
namespace ProLobbyCompanyProject.Dal
{
    /// <summary>   A create SQL tables. </summary>
    public class CreateSqlTables : DbContext
    {
        /// <summary>   The data. </summary>
        private static CreateSqlTables data;

        /// <summary>   Default constructor. </summary>
        public CreateSqlTables() : base("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProLobbyCompanyProject;Data Source=localhost\\SQLEXPRESS")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CreateSqlTables>());
            if ((SocialActivists.Count() == 0) || (Shippers.Count() == 0) || (ProLobbyOwner.Count() == 0) || (NonProfitOrganization.Count() == 0) || (MoneyTracking.Count() == 0) || (DonatedProducts.Count() == 0) || (Campaigns.Count() == 0) || (BusinessCompanyRepresentative.Count() == 0) || (PostsTracking.Count() == 0)) Seed();
            Database.Connection.Close();

        }

        /// <summary> Gets the data. </summary>
        /// <value> The data. </value>
        public static CreateSqlTables Data
        {
            get
            {
                if (data == null) data = new CreateSqlTables();
                return data;
            }
        }

        /// <summary>  Seed first row. </summary>
        private void Seed()
        {
            if (BusinessCompanyRepresentative.Count() == 0)
            {
                TBBusinessCompanyRepresentative businessCompanyRepresentative = new TBBusinessCompanyRepresentative { CompanyName = "CompanyName", Email = "Email@gmail.com", Phone_number = "0525381648", RepresentativeFirstName = "RepresentativeFirstName", RepresentativeLastName = "RepresentativeLastName", Url = "@WWW.Url.com", User_Id = "111" ,Date = DateTime.Now };
                BusinessCompanyRepresentative.Add(businessCompanyRepresentative);
            }
            else if (Campaigns.Count() == 0)
            {
                TBCampaigns campaigns = new TBCampaigns { Campaigns_Name = "Campaigns_Name", Descreption = "Descreption", Hashtag = "#Hashtag", NonProfitOrganization_Id = 1, Active = false, MoneyDonations = 0 ,Date = DateTime.Now };

                Campaigns.Add(campaigns);
            }
            else if (DonatedProducts.Count() == 0)
            {
                TBDonatedProducts donatedProducts = new TBDonatedProducts { BusinessCompany_Id = 1, Campaigns_Id = 1, Price = 0, Product_Name = "Product_Name", Status_Product = 1 ,Active = false, Date = DateTime.Now };
                DonatedProducts.Add(donatedProducts);
            }
            else if (MoneyTracking.Count() == 0)
            {
                TBMoneyTracking moneyTracking = new TBMoneyTracking { SocialActivists_Id = 1, Campaigns_Id = 1, Accumulated_money = 0, Active = false, Date = DateTime.Now };
                MoneyTracking.Add(moneyTracking);
            }
            else if (NonProfitOrganization.Count() == 0)
            {
                TBNonProfitOrganization nonProfitOrganization = new TBNonProfitOrganization { decreption = "decreption", Email = "Email1@gmail.com", NonProfitOrganizationName = "NonProfitOrganizationName", Phone_number = "0525381648", User_Id = "111", RepresentativeFirstName = "RepresentativeFirstName", RepresentativeLastName = "RepresentativeLastName", Url = "@url.com", Date = DateTime.Now };
                NonProfitOrganization.Add(nonProfitOrganization);
            }
            else if (ProLobbyOwner.Count() == 0)
            {
                TBProLobbyOwner proLobbyOwner = new TBProLobbyOwner { Email = "Email2@gmail.com", FirstName = "FirstName", LastName = "LastName", Phone_number = "0525381628", User_Id = "111", Date = DateTime.Now };
                ProLobbyOwner.Add(proLobbyOwner);
            }
            else if (Shippers.Count() == 0)
            {
                TBShippers shippers = new TBShippers { Date = DateTime.Now, BusinessCompany_Id = 1, DonatedProducts_Id = 1, Sent = false, SocialActivists_Id = 1 };
                Shippers.Add(shippers);
            }
            else if (SocialActivists.Count() == 0)
            {
                TBSocialActivists socialActivists = new TBSocialActivists { Twitter_user = "Twitter_user", Address = "Address", FirstName = "FirstName", LastName = "LastName", Email = "Email3@gmail.com", Phone_number = "0525381628", User_Id = "111", Date = DateTime.Now };
                SocialActivists.Add(socialActivists);
            }
            else if (PostsTracking.Count() == 0)
            {
                TBPostsTracking postsTracking = new TBPostsTracking { SocialActivists_Id = 1, Campaigns_Id = 1, Amount_publications = 0, Active = false, Date = DateTime.Now };
                PostsTracking.Add(postsTracking);
            }
            SaveChanges();
        }


        //Creating the tables
        public DbSet<TBBusinessCompanyRepresentative> BusinessCompanyRepresentative { get; set; }
        public DbSet<TBCampaigns> Campaigns { get; set; }
        public DbSet<TBDonatedProducts> DonatedProducts { get; set; }
        public DbSet<TBMoneyTracking> MoneyTracking { get; set; }
        public DbSet<TBNonProfitOrganization> NonProfitOrganization { get; set; }
        public DbSet<TBProLobbyOwner> ProLobbyOwner { get; set; }
        public DbSet<TBShippers> Shippers { get; set; }
        public DbSet<TBSocialActivists> SocialActivists { get; set; }
        public DbSet<TBPostsTracking> PostsTracking { get; set; }
    }
}
