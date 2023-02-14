using System;
using System.ComponentModel.DataAnnotations;

namespace ProLobbyCompanyProject.Model
{
    public class TBMoneyTracking
    {
        [Key]
        public int MoneyTracking_Id { get; set; }
        public int SocialActivists_Id { get; set; }
        public int Campaigns_Id { get; set; }
        public double Accumulated_money { get; set; }
        public bool Active { get; set; }
        public DateTime Date { get; set; }
       // public DateTime DateLastTweet { get; set; }
    }
}
