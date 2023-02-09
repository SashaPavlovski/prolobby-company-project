using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Data.Sql.ProLobbyOwner;
using ProLobbyCompanyProject.Model;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites
{
    public class ProLobbyOwner: BaseEntity
    {
        DSProLobbyOwnerGet dSUserData;
        DSProLobbyOwnerPost userOwnerPost;
        DSProLobbyOwnerUpdate usersNewData;

        public ProLobbyOwner(Logger logger):base(logger)
        {
            DSProLobbyOwnerGet dSUserData = new DSProLobbyOwnerGet(base.Logger);
            DSProLobbyOwnerPost userOwnerPost = new DSProLobbyOwnerPost(base.Logger);
            DSProLobbyOwnerUpdate usersNewData = new DSProLobbyOwnerUpdate(base.Logger);
        }
        public List<TBProLobbyOwner> CheckingIfExistUser(string UI)
        {
            return dSUserData.GetProLobbyOwnerUserRow(UI);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts the users owner. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="userOwnerData">    Information describing the user owner. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PostUsersOwner(TBProLobbyOwner userOwnerData)
        {
            userOwnerPost.PostUsersData(userOwnerData);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the activist described by updateUserData. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="updateUserData">   Information describing the update user. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void UpdateActivist(TBProLobbyOwner updateUserData)
        {
            usersNewData.UpdateUsersData(updateUserData);
        }
    }
}
