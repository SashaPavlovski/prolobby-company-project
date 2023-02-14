using ProLobbyCompanyProject.Entites.Commands.BusinessCompany;
using ProLobbyCompanyProject.Entites.Commands.Campaigns;
using ProLobbyCompanyProject.Entites.Commands.DonatedProducts;
using ProLobbyCompanyProject.Entites.Commands.MoneyTracking;
using ProLobbyCompanyProject.Entites.Commands.NonProfitOrganization;
using ProLobbyCompanyProject.Entites.Commands.ProLobbyOwner;
using ProLobbyCompanyProject.Entites.Commands.Reports;
using ProLobbyCompanyProject.Entites.Commands.Shippers;
using ProLobbyCompanyProject.Entites.Commands.SocialActivists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Entites.Commands
{
    public class CommandsManager: BaseCommands
    {
        private Dictionary<string, ICommand> _CommandList;
        public Dictionary<string, ICommand> CommandList
        {
            get
            {
                if (_CommandList == null)
                {
                    try
                    {
                        Init();
                    }
                    catch (Exception Ex)
                    {

                        throw;
                    }
                }

                return _CommandList;
            }
        }
        public CommandsManager() 
        {
            
        }
        private void Init()
        {
            _CommandList = new Dictionary<string, ICommand>();

            _CommandList.Clear();

            _CommandList.Add("BusinessCompanyRepresentative/userData", new BUserDataCommand());
            _CommandList.Add("BusinessCompanyRepresentative/addData", new BAddDataCommand());
            _CommandList.Add("BusinessCompanyRepresentative/updateData", new BUpdateDataCommand());
            _CommandList.Add("NonProfitOrganization/userData", new NUserData());
            _CommandList.Add("NonProfitOrganization/addData", new NAddData());
            _CommandList.Add("NonProfitOrganization/updateData", new NUpdateData());
            _CommandList.Add("ProLobbyOwner/userData", new PUserData());
            _CommandList.Add("ProLobbyOwner/addData", new PAddData());
            _CommandList.Add("ProLobbyOwner/updateData", new PUpdateData());
            _CommandList.Add("SocialActivists/userData", new SUserData());
            _CommandList.Add("SocialActivists/addData", new SAddData());
            _CommandList.Add("SocialActivists/updateData", new SUpdateData());
            _CommandList.Add("Campaigns/getData", new CGetData());
            _CommandList.Add("Campaigns/getDataById", new CGetDataById());
            _CommandList.Add("Campaigns/addData", new CAddData());
            _CommandList.Add("Campaigns/getOneData", new CGetOneData());
            _CommandList.Add("Campaigns/deleteData", new CDeleteData());
            _CommandList.Add("DonatedProducts/getData", new DGetData());
            _CommandList.Add("DonatedProducts/addData", new DAddData());
            _CommandList.Add("MoneyTracking/addTrack", new MAddTrack());
            _CommandList.Add("MoneyTracking/getDataMoney", new MGetDataMoney());
            _CommandList.Add("Reports/byCampaign", new RByCampaign());
            _CommandList.Add("Reports/byPosts", new RByPosts());
            _CommandList.Add("Reports/byProducts", new RByProducts());
            _CommandList.Add("Reports/byUsers", new RByUsers());
            _CommandList.Add("Shippers/buyProduct", new SBuyProduct());
            _CommandList.Add("Shippers/getProductById", new SGetProductById());
            _CommandList.Add("Shippers/donationProduct", new SDonationProduct());
            _CommandList.Add("Shippers/getDeliveryList", new SGetDeliveryList());
            _CommandList.Add("Shippers/sendProduct", new SSendProduct());
        }
    }
}
