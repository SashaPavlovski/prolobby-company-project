using ProLobbyCompanyProject.Data.Sql.Twitter;
using ProLobbyCompanyProject.Model.Twitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites
{
    public class Twitter
    {
        public Twitter() { }
        public List<MATwitter> GetTwitterData()
        {
            DSTwitterGet dSTwitterGet = new DSTwitterGet();
            return dSTwitterGet.GetTwitterUserRow();
        }
    }
}
