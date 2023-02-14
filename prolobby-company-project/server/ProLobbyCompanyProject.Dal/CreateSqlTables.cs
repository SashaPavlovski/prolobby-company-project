using ProLobbyCompanyProject.Model;
using ProLobbyCompanyProject.Model.Tables;
using System;
using System.Data.Entity;
using System.Linq;

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
        public CreateSqlTables() : base(OpenConnection.connectionString)
        {
            try
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CreateSqlTables>());
                if (ProLobbyOwner.Count() == 0) Seed();
                Database.Connection.Close();

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                Console.WriteLine(Ex.StackTrace);

                throw;
            }

        }

        /// <summary> Gets the data. </summary>
        /// <value> The data. </value>
        public static CreateSqlTables Data
        {
            get
            {
                try
                {
                    if (data == null) data = new CreateSqlTables();
                    return data;
                }
                catch (Exception Ex)
                {

                    return null;
                }

            }
        }

        /// <summary>  Seed first row. </summary>
        private void Seed()
        {
            if (ProLobbyOwner.Count() == 0)
            {
                try
                {
                    ProLobbyOwner.Add(new TBProLobbyOwner { Email = "Email2@gmail.com", FirstName = "FirstName", LastName = "LastName", Phone_number = "0525381628", User_Id = "111", Date = DateTime.Now });

                    SaveChanges();
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                    Console.WriteLine(Ex.StackTrace);
                    throw;
                }

            }
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
