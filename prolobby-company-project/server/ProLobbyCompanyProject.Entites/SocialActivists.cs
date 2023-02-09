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

        //Checking whether social activist is existing 
        public List<TBSocialActivists> CheckingIfExistUser(string UI)
        {
            return dSUserData.GetSocialActivistsRow(UI);
        }

        //Entering data on a social activist
        public void PostUsersActivists(TBSocialActivists userActivistsData)
        {
            usersComments.PostUsersData(userActivistsData);
        }

        //Updating data of a social activist
        public void UpdateActivist(TBSocialActivists updateUserData)
        {
            usersNewData.UpdateUsersData(updateUserData);
        }
    }
}
