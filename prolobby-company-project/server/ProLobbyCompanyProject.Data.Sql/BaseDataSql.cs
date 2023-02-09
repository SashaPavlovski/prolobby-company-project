using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql
{
    public class BaseDataSql
    {
        public Logger Logger;
        public BaseDataSql(Logger logger)
        {
            Logger=logger;
        }
    }
}
