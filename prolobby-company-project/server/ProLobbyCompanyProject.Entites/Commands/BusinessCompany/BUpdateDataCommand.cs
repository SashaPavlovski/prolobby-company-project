using Microsoft.AspNetCore.Mvc;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites.Commands.BusinessCompany
{
    public class BUpdateDataCommand: ICommand
    {
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is TBBusinessCompanyRepresentative)
                {
                    TBBusinessCompanyRepresentative UserCompanyData = (TBBusinessCompanyRepresentative)item;

                    if (UserCompanyData.BusinessCompany_Id != 0 && UserCompanyData.RepresentativeFirstName != null && UserCompanyData.RepresentativeLastName != null && UserCompanyData.CompanyName != null && UserCompanyData.Phone_number != null && UserCompanyData.Email != null)
                    {
                        MainManager.INSTANCE.BusinessCompanyRepresentatives.UpdateActivist(UserCompanyData);

                        return "The operation was successful";
                    }
                }
            }

            return "The operation failed";
        }

        public void Init()
        {

        }
    }
}
