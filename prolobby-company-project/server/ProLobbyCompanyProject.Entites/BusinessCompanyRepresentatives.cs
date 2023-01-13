
////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	BusinessCompanyRepresentatives.cs
//
// summary:	Implements the business company representatives class
////////////////////////////////////////////////////////////////////////////////////////////////////
 
using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Data.Sql.BusinessCompanyRepresentatives;
using ProLobbyCompanyProject.Data.Sql.NonProfitOrganizations;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The business company representatives. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class BusinessCompanyRepresentatives
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Checking if exist user. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="UI">   The user interface. </param>
        ///
        /// <returns>   A List&lt;TBBusinessCompanyRepresentative&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<TBBusinessCompanyRepresentative> CheckingIfExistUser(string UI)
        {
            DSBusinessCompanyRepresentativesGet dSUserData = new DSBusinessCompanyRepresentativesGet();
            return dSUserData.GetBusinessCompanyUserRow(UI);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts the users companys. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="userCompanyData">  Information describing the user company. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PostUsersCompanys(TBBusinessCompanyRepresentative userCompanyData)
        {
            DSBusinessCompanyRepresentativesPost usersComments = new DSBusinessCompanyRepresentativesPost();
            usersComments.PostUsersData(userCompanyData);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the activist described by updateUserData. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="updateUserData">   Information describing the update user. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void UpdateActivist(TBBusinessCompanyRepresentative updateUserData)
        {
            DSBusinessCompanyRepresentativesUpdate usersNewData = new DSBusinessCompanyRepresentativesUpdate();
            usersNewData.UpdateUsersData(updateUserData);
        }
    }
}
