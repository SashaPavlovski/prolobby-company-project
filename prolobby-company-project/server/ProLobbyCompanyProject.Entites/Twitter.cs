////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Twitter.cs
//
// summary:	Implements the twitter class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Data.Sql.MoneyTracking;
using ProLobbyCompanyProject.Data.Sql.Twitter;
using ProLobbyCompanyProject.Model;
using ProLobbyCompanyProject.Model.Twitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A twitter. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class Twitter
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Twitter() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets twitter data. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <returns>   The twitter data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<MATwitter> GetTwitterData()
        {
            DSTwitterGet dSTwitterGet = new DSTwitterGet();
            return dSTwitterGet.GetTwitterUserRow();
        }
        public void UpdateMoneyTracking(MATwitter userTwitterMoney, double UserMoney)
        {
            DSMoneyTrackingMoneyUpdate newData = new DSMoneyTrackingMoneyUpdate();
            newData.UpdateMoneyTracking(userTwitterMoney, UserMoney);
        }
    }
}
