using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Model
{
    public class TBDonatedProducts
    {
        [Key]
        public int DonatedProducts_Id { get; set; }
        public int BusinessCompany_Id { get; set; }
        public int Campaigns_Id { get; set; }
        public string Product_Name { get; set; }
        public double Price { get; set; }
        public int Status_Product { get { return 1; } set { } }
        public bool Active { get { return true; } set { } }
        public byte[] MyImage { get; set; }
        public IFormFile SetImage
        {

            set
            {
                if (value == null) return;
                MemoryStream stream = new MemoryStream();
                value.CopyTo(stream);
                MyImage = stream.ToArray();
            }
        }
    }
}
