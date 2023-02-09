using Utilities.Logger;

namespace ProLobbyCompanyProject.Dal
{
    public class BaseDal
    {
        public Logger Logger;
        public BaseDal(Logger logger)
        {
            Logger = logger;
        }
    }
}
