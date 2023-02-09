using CommunicationSocial;
using ProLobbyCompanyProject.Dal;
using System.Configuration;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites
{
    /// <summary>   Manager for mains. </summary>
    public class MainManager
    {
        /// <summary>   The instance. </summary>
        private readonly static MainManager _INSTANCE = new MainManager();
        private MainManager()
        {
            Init();

            Logger.LogEvent("Exited the MainManager");
        }
        public static MainManager INSTANCE
        {
            get { return _INSTANCE; }
        }

        readonly string ProviderType  = ConfigurationManager.AppSettings["ProviderType"];
        /// <summary>   The second business company representatives. </summary>
        public BusinessCompanyRepresentatives BusinessCompanyRepresentatives;
        /// <summary>   The second pro lobby owner. </summary>
        public ProLobbyOwner ProLobbyOwner;
        /// <summary>   The second social activists. </summary>
        public SocialActivists SocialActivists;
        /// <summary>   The second non profit organizations. </summary>
        public NonProfitOrganizations NonProfitOrganizations;
        /// <summary>   The second twitter. </summary>
        public Twitter Twitter;

        Logger Logger;

        AddTwitter AddTwitter;

        public void Init()
        {
            InitClasses();

            try
            {
                Logger.LogEvent("Create DB table");

                ConnectionWithSql._ConnectionWithSql.CreateTables();
            }
            catch (System.Exception EX)
            {

                throw;
            }
        }

        /// <summary>   Init classes. </summary>
        public void InitClasses()
        {

            Logger = new Logger(ProviderType);
            BusinessCompanyRepresentatives = new BusinessCompanyRepresentatives(Logger);
            ProLobbyOwner = new ProLobbyOwner(Logger);
            SocialActivists = new SocialActivists(Logger);
            NonProfitOrganizations = new NonProfitOrganizations(Logger);
            Twitter = new Twitter(Logger);
            AddTwitter = new AddTwitter(Logger);

            Logger.LogEvent("Initialize the entities classes");
        }
    }
}
