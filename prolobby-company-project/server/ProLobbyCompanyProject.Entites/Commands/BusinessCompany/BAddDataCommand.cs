using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites.Commands.BusinessCompany
{
    public class BAddDataCommand: ICommand
    {
        //Enters new data 
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if(item is TBBusinessCompanyRepresentative)
                {
                    TBBusinessCompanyRepresentative userCompany = (TBBusinessCompanyRepresentative)item;
                    if (userCompany.Url != null && userCompany.Email != null && userCompany.CompanyName != null && userCompany.RepresentativeFirstName != null && userCompany.RepresentativeLastName != null && userCompany.User_Id != null && userCompany.Phone_number != null)
                    {
                        MainManager.INSTANCE.BusinessCompanyRepresentatives.PostUsersCompanys(userCompany);
                        return "The operation was successful";
                    }

                    return "The operation failed";
                }
            }

            return "The operation failed";

        }
        public void Init()
        {

        }
    }
}
