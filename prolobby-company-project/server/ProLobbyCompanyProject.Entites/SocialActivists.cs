using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Data.Sql.SocialActivists;
using ProLobbyCompanyProject.Model;
using System.Collections.Generic;

namespace ProLobbyCompanyProject.Entites
{
    public partial class SocialActivists: BaseEntity
    {
        DSSocialActivistsGet dSUserData;
        DSSocialActivistsPost usersComments;
        DSSocialActivistsUpdate usersNewData;

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
            Logger.LogEvent("Enter into CheckingIfExistUser function");

            return dSUserData.GetSocialActivistsRow(userId);
        }

        /// <summary>
        /// Entering data on a social activist
        /// </summary>
        /// <param name="userActivistsData"> data of social activist. </param>
        public void PostUsersActivists(TBSocialActivists userActivistsData)
        {
            Logger.LogEvent("Enter into PostUsersActivists function");

            usersComments.PostUsersData(userActivistsData);

            Logger.LogEvent("End PostUsersActivists function");

        }

        /// <summary>
        /// Updating data of a social activist
        /// </summary>
        /// <param name="updateUserData"> New data of social activist. </param>
        public void UpdateActivist(TBSocialActivists updateUserData)
        {
            Logger.LogEvent("Enter into UpdateActivist function");

            usersNewData.UpdateUsersData(updateUserData);

            Logger.LogEvent("End UpdateActivist function");

        }
    }
}
