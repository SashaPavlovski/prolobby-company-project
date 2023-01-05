using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Data.Sql.ProLobbyOwner;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites
{
    public class ProLobbyOwner
    {
        public ProLobbyOwner() { }

        public List<TBProLobbyOwner> CheckingIfExistUser(string UI)
        {
            DSProLobbyOwnerGet dSUserData = new DSProLobbyOwnerGet();
            return dSUserData.GetProLobbyOwnerUserRow(UI);
        }
        public void PostUsersOwner(TBProLobbyOwner userOwnerData)
        {
            DSProLobbyOwnerPost userOwnerPost = new DSProLobbyOwnerPost();
            userOwnerPost.PostUsersData(userOwnerData);
        }
    }
}
