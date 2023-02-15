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


        /// <summary>
        /// Entering financial data of the social activists
        /// </summary>
        /// <param name="moneyTracking">id of the campaign and id of the activist.</param>
        public void PostDataTracking(TBMoneyTracking moneyTracking)
        {
            Logger.LogEvent("\n\nEnter into PostDataTracking function");

            newData.PostMoneyTracking(moneyTracking);

            Logger.LogEvent("End PostDataTracking function");

        }

        /// <summary>
        /// Receiving financial data of the social activists
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns>Details about campaign and how much money accumulated.</returns>
        public List<MAMoneyTracking> GetMoneyData(string idUser)
        {
            Logger.LogEvent("\n\nEnter into GetMoneyData function");

            return dSMoneyTrackingGetUserMoney.GetMonetDataRow(idUser);
        }
    }
}
