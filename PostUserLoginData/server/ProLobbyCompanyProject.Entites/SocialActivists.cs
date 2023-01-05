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
    public class SocialActivists
    {
        public List<TBSocialActivists> CheckingIfExistUser(string UI)
        {
            DSSocialActivistsGet dSUserData = new DSSocialActivistsGet();
            return dSUserData.GetSocialActivistsRow(UI);
        }
        public void PostUsersActivists(TBSocialActivists userActivistsData)
        {
            DSSocialActivistsPost usersComments = new DSSocialActivistsPost();
            usersComments.PostUsersData(userActivistsData);
        }
    }
}
