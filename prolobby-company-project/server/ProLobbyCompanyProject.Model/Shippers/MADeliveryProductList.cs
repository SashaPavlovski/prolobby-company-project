using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Model.Shippers
{
    public class MADeliveryProductList
    {
        public MADeliveryProductList() { }
        public int Shippers_Id { get; set; }
        public string FullName { get; set; }
        public string Product_Name { get; set; }
        public string Phone_number { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool Sent { get; set; }
    }
}
