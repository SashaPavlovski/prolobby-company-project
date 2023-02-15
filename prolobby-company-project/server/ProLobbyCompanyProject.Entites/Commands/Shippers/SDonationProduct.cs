using ProLobbyCompanyProject.Model.Shippers;
using System;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.Shippers
{
    public class SDonationProduct: BaseCommands,ICommand
    {
        public SDonationProduct(Logger logger) : base(logger) { }

        /// <summary>
        /// Donation a product by activist,
        /// Getting an product ID,
        /// Checking whether it is possible to donation,
        /// </summary>
        /// <param name="argv">ID of social activist and the product.</param>
        /// <returns>whether the operation succeeded or failed.</returns>

        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is MAbuyProduct)
                {

                    MAbuyProduct donationProduct = (MAbuyProduct)item;

                    if (donationProduct != null)
                    {
                        string answer = MainManager.INSTANCE.BusinessCompanyRepresentatives.PostDonationProduct(donationProduct);

                        base.Logger.LogEvent("Done successfully in SDonationProduct");

                        base.Logger.LogEvent($"In SDonationProduct:\nThe answer is: {answer}");

                        if (answer.Contains("Succeeded")) return "The operation was carried out successfully,Thanks for the donation";

                        else if (answer.Contains("you do not have enough money")) return "We're sorry you don't have enough money for the product";

                        else if (answer.Contains("You are not following the campaign")) return "We are sorry, to donate a product you must join the campaign";

                        base.Logger.LogError("\nThe answer received about donation the product is invalid in SDonationProduct.\n");

                        return "failedNotFollowing";
                    }

                }
            }

            base.Logger.LogError("\nThe product donation by the activist failed, The Data of activist and the product received is invalid in SDonationProduct.\n");

            return "The operation failed";
        }
        public void Init() { }
    }
}
