using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Model
{
    public class TBNonProfitOrganization
    {
        [Key]
        public int NonProfitOrganization_Id { get; set; }
        public string NonProfitOrganizationName { get; set; }

        public string Url { get; set; }
        public string decreption { get; set; }

        [EmailAddress(ErrorMessage = "please enter right email")]
        public string Email { get; set; }
        public string RepresentativeFirstName { get; set; }
        public string RepresentativeLastName { get; set; }
        public string Phone_number { get; set; }
        //public byte[] Logo { get; set; }

        //public IFormFile SetImage
        //{

        //    set
        //    {
        //        if (value == null) return;
        //        MemoryStream stream = new MemoryStream();
        //        value.CopyTo(stream);
        //        Logo = stream.ToArray();
        //    }
        //}
        public string User_Id { get; set; }
        public DateTime Date { get; set; }
    }
}
