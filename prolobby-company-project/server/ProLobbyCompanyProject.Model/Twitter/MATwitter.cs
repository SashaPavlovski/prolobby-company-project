using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Model.Twitter
{
    public class MATwitter
    {
        public MATwitter() { }
        public int MoneyTracking_Id { get; set; }
        public int SocialActivists_Id { get; set; }
        public string Twitter_user { get; set; }
        public string Hashtag { get; set; }
        public double Accumulated_money { get { return 0; } set { } }

    }
}
