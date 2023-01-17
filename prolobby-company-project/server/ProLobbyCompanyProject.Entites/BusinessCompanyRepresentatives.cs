


 
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

    public class BusinessCompanyRepresentatives
    {

        /// <summary> Checking if exist user. </summary>
        /// <param name="UI">   The user interface. </param>

        public List<TBBusinessCompanyRepresentative> CheckingIfExistUser(string UI)
        {
            DSBusinessCompanyRepresentativesGet dSUserData = new DSBusinessCompanyRepresentativesGet();
            return dSUserData.GetBusinessCompanyUserRow(UI);
        }

        /// <summary>   Posts the users companys. </summary>

        /// <param name="userCompanyData">  Information describing the user company. </param>


        public void PostUsersCompanys(TBBusinessCompanyRepresentative userCompanyData)
        {
            DSBusinessCompanyRepresentativesPost usersComments = new DSBusinessCompanyRepresentativesPost();
            usersComments.PostUsersData(userCompanyData);
        }


        /// <summary>   Updates the activist described by updateUserData. </summary>

        /// <param name="updateUserData">   Information describing the update user. </param>

        public void UpdateActivist(TBBusinessCompanyRepresentative updateUserData)
        {
            DSBusinessCompanyRepresentativesUpdate usersNewData = new DSBusinessCompanyRepresentativesUpdate();
            usersNewData.UpdateUsersData(updateUserData);
        }
    }
}
