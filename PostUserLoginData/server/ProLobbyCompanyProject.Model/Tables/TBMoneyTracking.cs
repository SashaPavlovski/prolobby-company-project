using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Model
{
    public class TBMoneyTracking
    {
        [Key]
        public int MoneyTracking_Id { get; set; }
        public int SocialActivists_Id { get; set; }
        public int DonatedProducts_Id { get; set; }
        public SqlMoney Accumulated_money { get; set; }
    }
}
