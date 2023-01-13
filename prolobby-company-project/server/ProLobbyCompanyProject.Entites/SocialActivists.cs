////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	SocialActivists.cs
//
// summary:	Implements the social activists class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Data.Sql;
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
    /// <summary>   A social activists. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SocialActivists
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Checking if exist user. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="UI">   The user interface. </param>
        ///
        /// <returns>   A List&lt;TBSocialActivists&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<TBSocialActivists> CheckingIfExistUser(string UI)
        {
            DSSocialActivistsGet dSUserData = new DSSocialActivistsGet();
            return dSUserData.GetSocialActivistsRow(UI);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts the users activists. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="userActivistsData">    Information describing the user activists. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PostUsersActivists(TBSocialActivists userActivistsData)
        {
            DSSocialActivistsPost usersComments = new DSSocialActivistsPost();
            usersComments.PostUsersData(userActivistsData);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the activist described by updateUserData. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="updateUserData">   Information describing the update user. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void UpdateActivist(TBSocialActivists updateUserData)
        {
            DSSocialActivistsUpdate usersNewData = new DSSocialActivistsUpdate();
            usersNewData.UpdateUsersData(updateUserData);
        }


    }
}
