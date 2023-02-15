using ProLobbyCompanyProject.Model.Shippers;
using System;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.Shippers
{
    public class SBuyProduct: BaseCommands,ICommand
    {
        public SBuyProduct(Logger logger) : base(logger) { }

        /// <summary>
        /// Buying a product,
        /// by getting an ID,
        /// Checking whether it is possible to buy,
        /// If it can be bought, post about it on Twitter,
        /// </summary>
        /// <param name="argv">ID of social activist and the product</param>
        /// <returns>whether the operation succeeded or failed.</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is MAbuyProduct)
                {
                    MAbuyProduct buyProduct = (MAbuyProduct)item;

                    if (buyProduct != null)
                    {
                        string answer = MainManager.INSTANCE.BusinessCompanyRepresentatives.BuyProduct(buyProduct);

                        base.Logger.LogEvent("Done successfully in SBuyProduct");

                        base.Logger.LogEvent($"In SBuyProduct:\nThe answer is: {answer}");

                        if (answer == null)
                        {
                            base.Logger.LogError("\nThe answer received about buying the product is invalid in SBuyProduct.\n");

                            return "The operation failed";
                        }

                        if (answer.Contains("Succeeded"))
                        {
                            MainManager.INSTANCE.PostTwitter.PostTweets(buyProduct);

                            return "The operation was carried out successfully, the package passes through the delivery person";
                        }

                        else if (answer.Contains("you do not have enough money")) return "We're sorry you don't have enough money for the product";

                        else if (answer.Contains("You are not following the campaign")) return "We are sorry, to buy the product you must join the campaign";

                        base.Logger.LogError("\nThe answer received about buying the product is invalid in SBuyProduct.\n");

                        return "failedNotFollowing";
                    }
                }
            }

            base.Logger.LogError("\nProduct purchase failed, The Data of activist and the product received is invalid in SBuyProduct.\n");

            return "The operation failed";
        }
        public void Init() { }
    }
}
