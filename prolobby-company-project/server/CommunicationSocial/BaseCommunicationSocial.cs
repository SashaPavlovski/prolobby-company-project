using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Model.Tables;
using Utilities.Logger;

namespace CommunicationSocial
{
    public class BaseCommunicationSocial
    {
        public Logger Logger;
        public TBKeys Keys;
        public BaseDataSql BaseDataSql;

        public BaseCommunicationSocial(Logger logger)
        {
            Logger = logger;
            BaseDataSql = new BaseDataSql(Logger);
            Keys = BaseDataSql.GetKeys();
        }
    }
}
