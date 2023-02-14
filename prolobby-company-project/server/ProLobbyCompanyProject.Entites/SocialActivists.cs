using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Data.Sql.MoneyTracking;
using ProLobbyCompanyProject.Data.Sql.SocialActivists;
using ProLobbyCompanyProject.Model;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites
{
    public partial class SocialActivists: BaseEntity
    {
        DSSocialActivistsGet dSUserData;
        DSSocialActivistsPost usersComments;
        DSSocialActivistsUpdate usersNewData;


        public SocialActivists(Logger logger) : base(logger)
        {
            newData = new DSMoneyTrackingPost(base.Logger);
            dSMoneyTrackingGetUserMoney = new DSMoneyTrackingGetUserMoney(base.Logger);
            dSUserData = new DSSocialActivistsGet(base.Logger);
            usersComments = new DSSocialActivistsPost(base.Logger);
            usersNewData = new DSSocialActivistsUpdate(base.Logger);

            Logger.LogEvent("initialization of classes in SocialActivists constructor");
        }

        /// <summary>
        /// Checking whether social activist is existing 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns> 
        /// Returns null if not exists,
        /// User information if exists.
        /// </returns>
        public List<TBSocialActivists> CheckingIfExistUser(string userId)
        {
            Logger.LogEvent("\n\nEnter into CheckingIfExistUser function");

            return dSUserData.GetSocialActivistsRow(userId);
        }

        /// <summary>
        /// Entering data on a social activist
        /// </summary>
        /// <param name="userActivistsData"> data of social activist. </param>
        public void PostUsersActivists(TBSocialActivists userActivistsData)
        {
            Logger.LogEvent("\n\nEnter into PostUsersActivists function");

            usersComments.PostUsersData(userActivistsData);

            Logger.LogEvent("End PostUsersActivists function");

        }

        /// <summary>
        /// Updating data of a social activist
        /// </summary>
        /// <param name="updateUserData"> New data of social activist. </param>
        public void UpdateActivist(TBSocialActivists updateUserData)
        {
            Logger.LogEvent("\n\nEnter into UpdateActivist function");

            usersNewData.UpdateUsersData(updateUserData);

            Logger.LogEvent("End UpdateActivist function");

        }
    }
}
