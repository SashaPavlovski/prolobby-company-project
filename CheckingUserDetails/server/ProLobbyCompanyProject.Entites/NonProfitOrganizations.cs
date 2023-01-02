using ProLobbyCompanyProject.Data.Sql;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites
{
    public class NonProfitOrganizations
    {
        public List<TBNonProfitOrganization> CheckingIfExistUser(string UI)
        {
            DSUserData dSUserData = new DSUserData();
            return dSUserData.GetNonProfitUserRow(UI);
        }
    }
}
