using ProLobbyCompanyProject.Data.Sql.MoneyTracking;
using ProLobbyCompanyProject.Model;
using ProLobbyCompanyProject.Model.MoneyTracking;
using System.Collections.Generic;

namespace ProLobbyCompanyProject.Entites
{
    public partial class SocialActivists: BaseEntity
    {
        DSMoneyTrackingPost newData;
        DSMoneyTrackingGetUserMoney dSMoneyTrackingGetUserMoney;


        //Entering financial data of the social activists
        public void PostDataTracking(TBMoneyTracking moneyTracking)
        {
            Logger.LogEvent("\n\nEnter into PostDataTracking function");

            newData.PostMoneyTracking(moneyTracking);

            Logger.LogEvent("End PostDataTracking function");

        }

        //Receiving financial data of the social activists
        public List<MAMoneyTracking> GetMoneyData(string idUser)
        {
            Logger.LogEvent("\n\nEnter into GetMoneyData function");

            return dSMoneyTrackingGetUserMoney.GetMonetDataRow(idUser);
        }
    }
}
