using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Model
{
    public class TBProLobbyOwner
    {
        [Key]
        public int ProLobbyOwner_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "please enter right email")]
        public string Email { get; set; }
        public string Phone_number { get; set; }
        public string User_Id { get; set; }
    }
}
