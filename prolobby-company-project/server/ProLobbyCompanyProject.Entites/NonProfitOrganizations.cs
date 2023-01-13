////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	NonProfitOrganizations.cs
//
// summary:	Implements the non profit organizations class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Data.Sql.NonProfitOrganizations;
using ProLobbyCompanyProject.Data.Sql.ProLobbyOwner;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A non profit organizations. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class NonProfitOrganizations
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Checking if exist user. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="UI">   The user interface. </param>
        ///
        /// <returns>   A List&lt;TBNonProfitOrganization&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<TBNonProfitOrganization> CheckingIfExistUser(string UI)
        {
            DSNonProfitOrganizationsGet dSUserData = new DSNonProfitOrganizationsGet();
            return dSUserData.GetNonProfitUserRow(UI);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts the users organization. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="userOrganizationData"> Information describing the user organization. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PostUsersOrganization(TBNonProfitOrganization userOrganizationData)
        {
            DSNonProfitOrganizationsPost usersComments = new DSNonProfitOrganizationsPost();
            usersComments.PostUsersData(userOrganizationData);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the activist described by updateUserData. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="updateUserData">   Information describing the update user. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void UpdateActivist(TBNonProfitOrganization updateUserData)
        {
            DSNonProfitOrganizationsUpdate usersNewData = new DSNonProfitOrganizationsUpdate();
            usersNewData.UpdateUsersData(updateUserData);
        }

    }
}
