////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	ProLobbyOwner.cs
//
// summary:	Implements the pro lobby owner class
////////////////////////////////////////////////////////////////////////////////////////////////////


using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Data.Sql.ProLobbyOwner;
using ProLobbyCompanyProject.Data.Sql.SocialActivists;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A pro lobby owner. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ProLobbyOwner
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ProLobbyOwner() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Checking if exist user. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="UI">   The user interface. </param>
        ///
        /// <returns>   A List&lt;TBProLobbyOwner&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<TBProLobbyOwner> CheckingIfExistUser(string UI)
        {
            DSProLobbyOwnerGet dSUserData = new DSProLobbyOwnerGet();
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
            DSProLobbyOwnerPost userOwnerPost = new DSProLobbyOwnerPost();
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
            DSProLobbyOwnerUpdate usersNewData = new DSProLobbyOwnerUpdate();
            usersNewData.UpdateUsersData(updateUserData);
        }
    }
}
