using ProLobbyCompanyProject.Data.Sql;
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
            DSUserData dSUserData = new DSUserData();
            return dSUserData.GetProLobbyOwnerUserRow(UI);
        }
    }
}
