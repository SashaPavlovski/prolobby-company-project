using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Data.Sql.MoneyTracking;
using ProLobbyCompanyProject.Data.Sql.SocialActivists;
using ProLobbyCompanyProject.Model;
using ProLobbyCompanyProject.Model.MoneyTracking;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites
{
    public partial class SocialActivists: BaseEntity
    {
        DSMoneyTrackingPost newData;
        DSMoneyTrackingGetUserMoney dSMoneyTrackingGetUserMoney;
        public SocialActivists(Logger logger) : base(logger)
        {
            newData = new DSMoneyTrackingPost(base.Logger);
            dSMoneyTrackingGetUserMoney = new DSMoneyTrackingGetUserMoney(base.Logger);
            dSUserData = new DSSocialActivistsGet(base.Logger);
            usersComments = new DSSocialActivistsPost(base.Logger);
            usersNewData = new DSSocialActivistsUpdate(base.Logger);

            Logger.LogEvent("initialization of classes in SocialActivists constructor");

        }

        //Entering financial data of the social activists
        public void PostDataTracking(TBMoneyTracking moneyTracking)
        {
            Logger.LogEvent("Enter into PostDataTracking function");

            newData.PostMoneyTracking(moneyTracking);

            Logger.LogEvent("End PostDataTracking function");

        }

        //Receiving financial data of the social activists
        public List<MAMoneyTracking> GetMoneyData(string idUser)
        {
            Logger.LogEvent("Enter into GetMoneyData function");

            return dSMoneyTrackingGetUserMoney.GetMonetDataRow(idUser);
        }
    }
}
