using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites.Commands.BusinessCompany
{
    public class BUserDataCommand:ICommand
    {
        //User login with enter details
        //Checks if the user exists
        public object Execute (params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is string)
                {
                    string userId = (string)item;

                    List<TBBusinessCompanyRepresentative> ListBusinessCompany = MainManager.INSTANCE.BusinessCompanyRepresentatives.CheckingIfExistUser(userId);
                    string responseMessageLB = System.Text.Json.JsonSerializer.Serialize(ListBusinessCompany);
                    Console.WriteLine(responseMessageLB);

                    return responseMessageLB;
                }
            }

            return null;
        }

        public void Init()
        {

        }
    }
}
