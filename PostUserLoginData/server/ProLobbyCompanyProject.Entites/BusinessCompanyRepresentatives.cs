using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Data.Sql.BusinessCompanyRepresentatives;
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

        public List<TBBusinessCompanyRepresentative> CheckingIfExistUser(string UI)
        {
            DSBusinessCompanyRepresentativesGet dSUserData = new DSBusinessCompanyRepresentativesGet();
            return dSUserData.GetBusinessCompanyUserRow(UI);
        }

        public void PostUsersCompanys(TBBusinessCompanyRepresentative userCompanyData)
        {
            DSBusinessCompanyRepresentativesPost usersComments = new DSBusinessCompanyRepresentativesPost();
            usersComments.PostUsersData(userCompanyData);
        }
    }
}
