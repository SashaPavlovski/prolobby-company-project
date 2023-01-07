using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Model
{
    public class TBSocialActivists
    {
        [Key]
        public int SocialActivists_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        [EmailAddress(ErrorMessage = "please enter right email")]
        public string Email { get; set; }
        public string Twitter_user { get; set; }
        public string Phone_number { get; set; }

        public string User_Id { get; set; }
    }
}
