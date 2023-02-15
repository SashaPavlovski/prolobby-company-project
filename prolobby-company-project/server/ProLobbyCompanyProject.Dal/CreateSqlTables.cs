using ProLobbyCompanyProject.Model;
using ProLobbyCompanyProject.Model.Tables;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

// CreateSqlTables.cs
// Implements the create SQL tables class
namespace ProLobbyCompanyProject.Dal
{
    /// <summary>   A create SQL tables. </summary>
    public class CreateSqlTables : BaseDal
    {
        /// <summary>   The data. </summary>
        private static CreateSqlTables data;

        /// <summary>   Default constructor. </summary>
        public CreateSqlTables() : base(connectionString)
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
                catch (Exception)
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
                    ProLobbyOwner.Add(new TBProLobbyOwner
                    {
                        Email = "Email2@gmail.com",
                        FirstName = "FirstName",
                        LastName = "LastName",
                        Phone_number = "0525381628",
                        User_Id = "111",
                        Date = DateTime.Now
                    });

                    Keys.Add(new TBKeys
                    {
                        ApiKey = "36kPxWu2NiCOLPT0TIQWhSg6A",
                        ApiKeySecret = "ZBPV84cGVuTLKfOizWXqKxg5GkwYAz2yUmWaqzXKuQGz4UOIQc",
                        BearerToken = "AAAAAAAAAAAAAAAAAAAAAIKmlAEAAAAAi4dUwLeoayKuJvRAVvp99%2BNVzXQ%3DSoycLC7ReE1jcWXN4roMBNMjGVuko4HGREzxjtuX3X9kZwzylW",
                        AccessToken = "1613252594201247745-n1Vnhu76k9Qp9YsgoalMyppKnQx1NA",
                        AccessTokenSecret = "955oQxhXL3HRHZxxfaxs5kXSEwJwipYUJSlErnZ8c0rVU",
                        BearerTokenAuth0 = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6Im5GWHNNbEloR2JBUUkyZDRmY2tpciJ9.eyJpc3MiOiJodHRwczovL2Rldi1tbHV1YWh4amJ2ZjUyNGFwLnVzLmF1dGgwLmNvbS8iLCJzdWIiOiJIcUFwSkJNTGdoTGhoTlk3SWFHbVhBZkNRWlI2UmMxc0BjbGllbnRzIiwiYXVkIjoiaHR0cHM6Ly9kZXYtbWx1dWFoeGpidmY1MjRhcC51cy5hdXRoMC5jb20vYXBpL3YyLyIsImlhdCI6MTY3NjM5NzgxOCwiZXhwIjoxNjc3Mzk3ODE4LCJhenAiOiJIcUFwSkJNTGdoTGhoTlk3SWFHbVhBZkNRWlI2UmMxcyIsInNjb3BlIjoicmVhZDpjbGllbnRfZ3JhbnRzIGNyZWF0ZTpjbGllbnRfZ3JhbnRzIGRlbGV0ZTpjbGllbnRfZ3JhbnRzIHVwZGF0ZTpjbGllbnRfZ3JhbnRzIHJlYWQ6dXNlcnMgdXBkYXRlOnVzZXJzIGRlbGV0ZTp1c2VycyBjcmVhdGU6dXNlcnMgcmVhZDp1c2Vyc19hcHBfbWV0YWRhdGEgdXBkYXRlOnVzZXJzX2FwcF9tZXRhZGF0YSBkZWxldGU6dXNlcnNfYXBwX21ldGFkYXRhIGNyZWF0ZTp1c2Vyc19hcHBfbWV0YWRhdGEgcmVhZDp1c2VyX2N1c3RvbV9ibG9ja3MgY3JlYXRlOnVzZXJfY3VzdG9tX2Jsb2NrcyBkZWxldGU6dXNlcl9jdXN0b21fYmxvY2tzIGNyZWF0ZTp1c2VyX3RpY2tldHMgcmVhZDpjbGllbnRzIHVwZGF0ZTpjbGllbnRzIGRlbGV0ZTpjbGllbnRzIGNyZWF0ZTpjbGllbnRzIHJlYWQ6Y2xpZW50X2tleXMgdXBkYXRlOmNsaWVudF9rZXlzIGRlbGV0ZTpjbGllbnRfa2V5cyBjcmVhdGU6Y2xpZW50X2tleXMgcmVhZDpjb25uZWN0aW9ucyB1cGRhdGU6Y29ubmVjdGlvbnMgZGVsZXRlOmNvbm5lY3Rpb25zIGNyZWF0ZTpjb25uZWN0aW9ucyByZWFkOnJlc291cmNlX3NlcnZlcnMgdXBkYXRlOnJlc291cmNlX3NlcnZlcnMgZGVsZXRlOnJlc291cmNlX3NlcnZlcnMgY3JlYXRlOnJlc291cmNlX3NlcnZlcnMgcmVhZDpkZXZpY2VfY3JlZGVudGlhbHMgdXBkYXRlOmRldmljZV9jcmVkZW50aWFscyBkZWxldGU6ZGV2aWNlX2NyZWRlbnRpYWxzIGNyZWF0ZTpkZXZpY2VfY3JlZGVudGlhbHMgcmVhZDpydWxlcyB1cGRhdGU6cnVsZXMgZGVsZXRlOnJ1bGVzIGNyZWF0ZTpydWxlcyByZWFkOnJ1bGVzX2NvbmZpZ3MgdXBkYXRlOnJ1bGVzX2NvbmZpZ3MgZGVsZXRlOnJ1bGVzX2NvbmZpZ3MgcmVhZDpob29rcyB1cGRhdGU6aG9va3MgZGVsZXRlOmhvb2tzIGNyZWF0ZTpob29rcyByZWFkOmFjdGlvbnMgdXBkYXRlOmFjdGlvbnMgZGVsZXRlOmFjdGlvbnMgY3JlYXRlOmFjdGlvbnMgcmVhZDplbWFpbF9wcm92aWRlciB1cGRhdGU6ZW1haWxfcHJvdmlkZXIgZGVsZXRlOmVtYWlsX3Byb3ZpZGVyIGNyZWF0ZTplbWFpbF9wcm92aWRlciBibGFja2xpc3Q6dG9rZW5zIHJlYWQ6c3RhdHMgcmVhZDppbnNpZ2h0cyByZWFkOnRlbmFudF9zZXR0aW5ncyB1cGRhdGU6dGVuYW50X3NldHRpbmdzIHJlYWQ6bG9ncyByZWFkOmxvZ3NfdXNlcnMgcmVhZDpzaGllbGRzIGNyZWF0ZTpzaGllbGRzIHVwZGF0ZTpzaGllbGRzIGRlbGV0ZTpzaGllbGRzIHJlYWQ6YW5vbWFseV9ibG9ja3MgZGVsZXRlOmFub21hbHlfYmxvY2tzIHVwZGF0ZTp0cmlnZ2VycyByZWFkOnRyaWdnZXJzIHJlYWQ6Z3JhbnRzIGRlbGV0ZTpncmFudHMgcmVhZDpndWFyZGlhbl9mYWN0b3JzIHVwZGF0ZTpndWFyZGlhbl9mYWN0b3JzIHJlYWQ6Z3VhcmRpYW5fZW5yb2xsbWVudHMgZGVsZXRlOmd1YXJkaWFuX2Vucm9sbG1lbnRzIGNyZWF0ZTpndWFyZGlhbl9lbnJvbGxtZW50X3RpY2tldHMgcmVhZDp1c2VyX2lkcF90b2tlbnMgY3JlYXRlOnBhc3N3b3Jkc19jaGVja2luZ19qb2IgZGVsZXRlOnBhc3N3b3Jkc19jaGVja2luZ19qb2IgcmVhZDpjdXN0b21fZG9tYWlucyBkZWxldGU6Y3VzdG9tX2RvbWFpbnMgY3JlYXRlOmN1c3RvbV9kb21haW5zIHVwZGF0ZTpjdXN0b21fZG9tYWlucyByZWFkOmVtYWlsX3RlbXBsYXRlcyBjcmVhdGU6ZW1haWxfdGVtcGxhdGVzIHVwZGF0ZTplbWFpbF90ZW1wbGF0ZXMgcmVhZDptZmFfcG9saWNpZXMgdXBkYXRlOm1mYV9wb2xpY2llcyByZWFkOnJvbGVzIGNyZWF0ZTpyb2xlcyBkZWxldGU6cm9sZXMgdXBkYXRlOnJvbGVzIHJlYWQ6cHJvbXB0cyB1cGRhdGU6cHJvbXB0cyByZWFkOmJyYW5kaW5nIHVwZGF0ZTpicmFuZGluZyBkZWxldGU6YnJhbmRpbmcgcmVhZDpsb2dfc3RyZWFtcyBjcmVhdGU6bG9nX3N0cmVhbXMgZGVsZXRlOmxvZ19zdHJlYW1zIHVwZGF0ZTpsb2dfc3RyZWFtcyBjcmVhdGU6c2lnbmluZ19rZXlzIHJlYWQ6c2lnbmluZ19rZXlzIHVwZGF0ZTpzaWduaW5nX2tleXMgcmVhZDpsaW1pdHMgdXBkYXRlOmxpbWl0cyBjcmVhdGU6cm9sZV9tZW1iZXJzIHJlYWQ6cm9sZV9tZW1iZXJzIGRlbGV0ZTpyb2xlX21lbWJlcnMgcmVhZDplbnRpdGxlbWVudHMgcmVhZDphdHRhY2tfcHJvdGVjdGlvbiB1cGRhdGU6YXR0YWNrX3Byb3RlY3Rpb24gcmVhZDpvcmdhbml6YXRpb25zIHVwZGF0ZTpvcmdhbml6YXRpb25zIGNyZWF0ZTpvcmdhbml6YXRpb25zIGRlbGV0ZTpvcmdhbml6YXRpb25zIGNyZWF0ZTpvcmdhbml6YXRpb25fbWVtYmVycyByZWFkOm9yZ2FuaXphdGlvbl9tZW1iZXJzIGRlbGV0ZTpvcmdhbml6YXRpb25fbWVtYmVycyBjcmVhdGU6b3JnYW5pemF0aW9uX2Nvbm5lY3Rpb25zIHJlYWQ6b3JnYW5pemF0aW9uX2Nvbm5lY3Rpb25zIHVwZGF0ZTpvcmdhbml6YXRpb25fY29ubmVjdGlvbnMgZGVsZXRlOm9yZ2FuaXphdGlvbl9jb25uZWN0aW9ucyBjcmVhdGU6b3JnYW5pemF0aW9uX21lbWJlcl9yb2xlcyByZWFkOm9yZ2FuaXphdGlvbl9tZW1iZXJfcm9sZXMgZGVsZXRlOm9yZ2FuaXphdGlvbl9tZW1iZXJfcm9sZXMgY3JlYXRlOm9yZ2FuaXphdGlvbl9pbnZpdGF0aW9ucyByZWFkOm9yZ2FuaXphdGlvbl9pbnZpdGF0aW9ucyBkZWxldGU6b3JnYW5pemF0aW9uX2ludml0YXRpb25zIHJlYWQ6b3JnYW5pemF0aW9uc19zdW1tYXJ5IGNyZWF0ZTphY3Rpb25zX2xvZ19zZXNzaW9ucyBjcmVhdGU6YXV0aGVudGljYXRpb25fbWV0aG9kcyByZWFkOmF1dGhlbnRpY2F0aW9uX21ldGhvZHMgdXBkYXRlOmF1dGhlbnRpY2F0aW9uX21ldGhvZHMgZGVsZXRlOmF1dGhlbnRpY2F0aW9uX21ldGhvZHMiLCJndHkiOiJjbGllbnQtY3JlZGVudGlhbHMifQ.NGYBFnhQfLWCNkx26kvX8nlklVogrWnxHpHS4GdD2bDbs459hvPnu7vtHisJZJCsl85kN96B8w-OUlD7b18DhsdrDacKX4uKGWgrJIBQ9Dajp_-VBfWjp4titz84PmsR4dQmF6UmxGxcAQVdpWhd4mDnV9IT6JJuZdjwAUPYIjDnvx1v9TJbjmDCA0B-wR0LbEOzb6ejBjgs7akcDZMamijcYszO8LXqTv7jl2I0w1bRi2IM52ouIXmGT4eLAgQzPsK05-2nHWqDZtn9P-o6vPy5g0rIcQdDO3zr88fdrEkRFsTOf5B3idEiW-y1gRqWPM1VC4Ri14lOJRZf5A6n3g"
                    });

                    SaveChanges();
                }
                catch (SqlException Ex)
                {
                    Console.WriteLine(Ex.Message);
                    Console.WriteLine(Ex.StackTrace);
                    throw;
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                    Console.WriteLine(Ex.StackTrace);
                    throw;
                }

            }
        }


        ///Creating the tables
        public DbSet<TBBusinessCompanyRepresentative> BusinessCompanyRepresentative { get; set; }
        public DbSet<TBCampaigns> Campaigns { get; set; }
        public DbSet<TBDonatedProducts> DonatedProducts { get; set; }
        public DbSet<TBMoneyTracking> MoneyTracking { get; set; }
        public DbSet<TBNonProfitOrganization> NonProfitOrganization { get; set; }
        public DbSet<TBProLobbyOwner> ProLobbyOwner { get; set; }
        public DbSet<TBShippers> Shippers { get; set; }
        public DbSet<TBSocialActivists> SocialActivists { get; set; }
        public DbSet<TBPostsTracking> PostsTracking { get; set; }
        public DbSet<TBKeys> Keys { get; set; }
    }
}
