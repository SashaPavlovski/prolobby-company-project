using ProLobbyCompanyProject.Data.Sql.MoneyTracking;
using ProLobbyCompanyProject.Model;
using ProLobbyCompanyProject.Model.MoneyTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites
{
    public class MoneyTracking
    {
        public MoneyTracking() { }
        public void PostDataTracking(TBMoneyTracking moneyTracking)
        {
            DSMoneyTrackingPost newData = new DSMoneyTrackingPost();
            newData.PostMoneyTracking(moneyTracking);
        }
        public List<MAMoneyTracking> GetMoneyData (string idUser)
        {
            DSMoneyTrackingGetUserMoney dSMoneyTrackingGetUserMoney = new DSMoneyTrackingGetUserMoney();
            return dSMoneyTrackingGetUserMoney.GetMonetDataRow(idUser);
        }
    }
}
