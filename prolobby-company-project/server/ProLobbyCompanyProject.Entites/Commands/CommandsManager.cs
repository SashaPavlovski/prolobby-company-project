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
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands
{
    public class CommandsManager: BaseCommands
    {
        /// <summary>
        /// Commands Dictionary.
        /// </summary>
        private Dictionary<string, ICommand> _CommandList;
        public CommandsManager(Logger logger) : base(logger) { }

        /// <summary>
        /// Commands Dictionary.
        /// </summary>
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
                        base.Logger.LogException(Ex.Message, Ex);
                        throw;
                    }
                }

                return _CommandList;
            }
        }

        /// <summary>
        /// Inserting the command classes to dictionary.
        /// </summary>
        private void Init()
        {
            _CommandList = new Dictionary<string, ICommand>();
            _CommandList.Clear();

            _CommandList.Add("BusinessCompanyRepresentative/userData", new BUserDataCommand(base.Logger));
            _CommandList.Add("BusinessCompanyRepresentative/addData", new BAddDataCommand(base.Logger));
            _CommandList.Add("BusinessCompanyRepresentative/updateData", new BUpdateDataCommand(base.Logger));
            _CommandList.Add("NonProfitOrganization/userData", new NUserData(base.Logger));
            _CommandList.Add("NonProfitOrganization/addData", new NAddData(base.Logger));
            _CommandList.Add("NonProfitOrganization/updateData", new NUpdateData(base.Logger));
            _CommandList.Add("ProLobbyOwner/userData", new PUserData(base.Logger));
            _CommandList.Add("ProLobbyOwner/addData", new PAddData(base.Logger));
            _CommandList.Add("ProLobbyOwner/updateData", new PUpdateData(base.Logger));
            _CommandList.Add("SocialActivists/userData", new SUserData(base.Logger));
            _CommandList.Add("SocialActivists/addData", new SAddData(base.Logger));
            _CommandList.Add("SocialActivists/updateData", new SUpdateData(base.Logger));
            _CommandList.Add("Campaigns/getData", new CGetData(base.Logger));
            _CommandList.Add("Campaigns/getDataById", new CGetDataById(base.Logger));
            _CommandList.Add("Campaigns/addData", new CAddData(base.Logger));
            _CommandList.Add("Campaigns/getOneData", new CGetOneData(base.Logger));
            _CommandList.Add("Campaigns/deleteData", new CDeleteData(base.Logger));
            _CommandList.Add("DonatedProducts/getData", new DGetData(base.Logger));
            _CommandList.Add("DonatedProducts/addData", new DAddData(base.Logger));
            _CommandList.Add("MoneyTracking/addTrack", new MAddTrack(base.Logger));
            _CommandList.Add("MoneyTracking/getDataMoney", new MGetDataMoney(base.Logger));
            _CommandList.Add("Reports/byCampaign", new RByCampaign(base.Logger));
            _CommandList.Add("Reports/byPosts", new RByPosts(base.Logger));
            _CommandList.Add("Reports/byProducts", new RByProducts(base.Logger));
            _CommandList.Add("Reports/byUsers", new RByUsers(base.Logger));
            _CommandList.Add("Shippers/buyProduct", new SBuyProduct(base.Logger));
            _CommandList.Add("Shippers/getProductById", new SGetProductById(base.Logger));
            _CommandList.Add("Shippers/donationProduct", new SDonationProduct(base.Logger));
            _CommandList.Add("Shippers/getDeliveryList", new SGetDeliveryList(base.Logger));
            _CommandList.Add("Shippers/sendProduct", new SSendProduct(base.Logger));
        }
    }
}
