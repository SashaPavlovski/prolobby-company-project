using ProLobbyCompanyProject.Model;
using System;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.DonatedProducts
{
    public class DAddData: BaseCommands,ICommand
    {
        public DAddData(Logger logger) : base(logger) { }

        /// <summary>
        /// Adding a new product
        /// </summary>
        /// <param name="argv">Details about the product.</param>
        /// <returns>Answer whether the operation was successful or not.</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is TBDonatedProducts)
                {
                    TBDonatedProducts donatedProduct = (TBDonatedProducts)item;

                    if (donatedProduct.Product_Name != null)
                    {
                        MainManager.INSTANCE.BusinessCompanyRepresentatives.PostProduct(donatedProduct);

                        base.Logger.LogEvent("The product save operation was performed successfully in DAddData.");
                        return "The operation was successful";
                    }
                }
            }

            base.Logger.LogError("\nSave operation failed, details are incorrect in DAddData.\n");

            return "The operation failed";
        }
        public void Init() { }
    }
}
