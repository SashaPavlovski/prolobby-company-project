using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Data.Sql.BusinessCompanyRepresentatives;
using ProLobbyCompanyProject.Model;
using System.Collections.Generic;


namespace ProLobbyCompanyProject.Entites
{
    public partial class BusinessCompanyRepresentatives: BaseEntity
    {
        /// <summary> Checking if exist user. </summary>
        /// <param name="UI">   The user interface. </param>
        
        DSBusinessCompanyRepresentativesGet dSUserData;
        DSBusinessCompanyRepresentativesPost usersComments;
        DSBusinessCompanyRepresentativesUpdate usersNewData;


        public List<TBBusinessCompanyRepresentative> CheckingIfExistUser(string UI)
        {
            Logger.LogEvent("Enter into CheckingIfExistUser function");

            return dSUserData.GetBusinessCompanyUserRow(UI);


        }

        /// <summary>   Posts the users companys. </summary>

        /// <param name="userCompanyData">  Information describing the user company. </param>


        public void PostUsersCompanys(TBBusinessCompanyRepresentative userCompanyData)
        {
            Logger.LogEvent("Enter into PostUsersCompanys function");

            usersComments.PostUsersData(userCompanyData);

            Logger.LogEvent("End PostUsersCompanys function");

        }


        /// <summary>   Updates the activist described by updateUserData. </summary>

        /// <param name="updateUserData">   Information describing the update user. </param>

        public void UpdateActivist(TBBusinessCompanyRepresentative updateUserData)
        {
            Logger.LogEvent("Enter into UpdateActivist function");

            usersNewData.UpdateUsersData(updateUserData);

            Logger.LogEvent("End UpdateActivist function");

        }
    }
}
