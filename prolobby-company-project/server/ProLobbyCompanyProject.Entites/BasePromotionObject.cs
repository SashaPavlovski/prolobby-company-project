using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Model.Tables;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites
{
    public class BasePromotionObject
    {
        public Logger Logger;

        public TBKeys TBKeys;

        private BaseDataSql BaseDataSql;

        public BasePromotionObject(Logger logger)
        {
            Logger = logger;

            BaseDataSql = new BaseDataSql(Logger);

            TBKeys = BaseDataSql.GetKeys();

            Logger.LogEvent("The Logger initialization operation was performed successfully");

            Logger.LogEvent("In the BasePromotionObject constructor");

        }

    }
}
