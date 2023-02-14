using CommunicationSocial;
using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Entites.Commands;
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

        readonly string ProviderType  = "LogConsole";

        public BusinessCompanyRepresentatives BusinessCompanyRepresentatives;

        public ProLobbyOwner ProLobbyOwner;

        public SocialActivists SocialActivists;

        public NonProfitOrganizations NonProfitOrganizations;

        public Twitter Twitter;

        public CommandsManager CommandsManager;

        private Logger Logger;

        private AddTwitter AddTwitter;

        public void Init()
        {
            InitClasses();

            try
            {
                Logger.LogEvent("\n\nCreate DB table");

                ConnectionWithSql._ConnectionWithSql.CreateTables();
            }
            catch (System.Exception EX)
            {
                Logger.LogException(EX.Message, EX);

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
            CommandsManager = new CommandsManager();

            Logger.LogEvent("Initialize the entities classes");
        }
    }
}
