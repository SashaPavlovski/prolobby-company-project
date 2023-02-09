using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Model.Tables
{
    public class TBPostsTracking
    {
        [Key]
        public int PostsTracking_Id { get; set; }
        public int MoneyTracking_Id { get; set; }
        public int Campaigns_Id { get; set; }
        public int SocialActivists_Id { get; set; }
        // public int Amount_publications { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public string Tweets_Message { get; set; }
        public int Retweets_Count { get; set; }
        public string Tweets_Message_Id { get; set; }

    }
}
