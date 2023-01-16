using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Model
{
    public class TBBusinessCompanyRepresentative
    {
        [Key]
        public int BusinessCompany_Id { get; set; }
        public string RepresentativeFirstName { get; set; }
        public string RepresentativeLastName { get; set; }
        public string CompanyName { get; set; }
        public string Url { get; set; }

        [EmailAddress(ErrorMessage = "please enter right email")]
        public string Email { get; set; }

        public string Phone_number { get; set; }
        public string User_Id { get; set; }
        public DateTime Date { get; set; }

    }
}
