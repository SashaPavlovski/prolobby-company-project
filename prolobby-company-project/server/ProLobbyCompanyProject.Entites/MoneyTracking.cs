////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	MoneyTracking.cs
//
// summary:	Implements the money tracking class
////////////////////////////////////////////////////////////////////////////////////////////////////

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
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A money tracking. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class MoneyTracking
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MoneyTracking() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts a data tracking. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="moneyTracking">    The money tracking. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PostDataTracking(TBMoneyTracking moneyTracking)
        {
            DSMoneyTrackingPost newData = new DSMoneyTrackingPost();
            newData.PostMoneyTracking(moneyTracking);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets money data. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="idUser">   The identifier user. </param>
        ///
        /// <returns>   The money data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<MAMoneyTracking> GetMoneyData(string idUser)
        {
            DSMoneyTrackingGetUserMoney dSMoneyTrackingGetUserMoney = new DSMoneyTrackingGetUserMoney();
            return dSMoneyTrackingGetUserMoney.GetMonetDataRow(idUser);
        }
    }
}
