﻿using System;
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
        public double Accumulated_money { get; set; }
        public DateTime? Date { get; set; }//יותר משבוע אז לא מחזירים
        public string Answer { get; set; }
        public string Tweets_Message_Id { get; set; }


    }
}
