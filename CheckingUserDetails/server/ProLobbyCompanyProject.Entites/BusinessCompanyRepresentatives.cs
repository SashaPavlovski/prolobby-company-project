using ProLobbyCompanyProject.Data.Sql;
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
            DSUserData dSUserData = new DSUserData();
            return dSUserData.GetBusinessCompanyUserRow(UI);
        }
    }
}
