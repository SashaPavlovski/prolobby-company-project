using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql
{
    public class BaseDataSql
    {
        public Logger Logger;
        public BaseDataSql(Logger logger)
        {
            Logger=logger;

            Logger.LogEvent("The Logger initialization operation was performed successfully");

            Logger.LogEvent("In the BaseDataSql constructor");
        }
    }
}
