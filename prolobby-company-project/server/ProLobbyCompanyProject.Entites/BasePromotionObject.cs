using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites
{
    public class BasePromotionObject
    {
        public Logger Logger;
        public BasePromotionObject(Logger logger)
        {
            Logger = logger;

            Logger.LogEvent("The Logger initialization operation was performed successfully");

            Logger.LogEvent("In the BasePromotionObject constructor");

        }
    }
}
