using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Model.SortingTables.SortingUsers
{
    public class SortingUsersDefaultCampaigns
    {
        public SortingUsersDefaultCampaigns() { }
        public string PermissionType { get; set; }
        public string FullName { get; set; }

        public DateTime Date { get; set; }
        public string Phone_number { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }

    }
    public class SortingUsersDefaultOrganization
    {
        public SortingUsersDefaultOrganization() { }
        public string PermissionType { get; set; }
        public string FullName { get; set; }

        public DateTime Date { get; set; }
        public string Phone_number { get; set; }
        public string Email { get; set; }
        public string NonProfitOrganizationName { get; set; }

    }
    public class SortingUsersDefaultOwnerAndActivist
    {
        public SortingUsersDefaultOwnerAndActivist() { }
        public string PermissionType { get; set; }
        public string FullName { get; set; }

        public DateTime Date { get; set; }
        public string Phone_number { get; set; }
        public string Email { get; set; }

    }

}
