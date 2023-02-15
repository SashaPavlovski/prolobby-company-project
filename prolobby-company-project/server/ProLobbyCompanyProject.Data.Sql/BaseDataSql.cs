using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model.Tables;
using System.Collections.Generic;
using System;
using Utilities.Logger;
using System.Linq;

namespace ProLobbyCompanyProject.Data.Sql
{
    public class BaseDataSql
    {
        public Logger Logger;
        public BaseDataSql(Logger logger)
        {
            Logger = logger;

            Logger.LogEvent("The Logger initialization operation was performed successfully");

            Logger.LogEvent("In the BaseDataSql constructor");
        }
        /// <summary>
        /// Get twitter and auth0 Keys
        /// </summary>
        /// <returns>Keys data or null </returns>
        public TBKeys GetKeys()
        {
            Logger.LogEvent("Starting GetKeys function.");

            try
            {
                List<TBKeys> KeysList;

                KeysList = CreateSqlTables.Data.Keys.ToList();

                CreateSqlTables.Data.Database.Connection.Close();

                if (KeysList.First() != null)
                {
                    Logger.LogEvent("End GetKeys function return Keys.");

                    return KeysList.First();
                }
                Logger.LogEvent("End GetKeys function return null.");
                return null;

            }
            catch (Exception Ex)
            {
                Logger.LogException(Ex.Message, Ex);

                throw;
            }
        }
    }
}
