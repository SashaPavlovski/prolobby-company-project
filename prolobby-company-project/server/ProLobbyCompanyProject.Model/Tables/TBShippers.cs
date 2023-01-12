using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Model
{
    public class TBShippers
    {
        [Key]
        public int Shippers_Id { get; set; }
        public int DonatedProducts_Id { get; set; }
        public int SocialActivists_Id { get; set; }
        public int BusinessCompany_Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public bool Sent { get { return true; } set { } }
    }
}
