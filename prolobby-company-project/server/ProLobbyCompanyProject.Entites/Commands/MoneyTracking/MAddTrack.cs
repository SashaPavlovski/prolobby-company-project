using ProLobbyCompanyProject.Model;
using System;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.MoneyTracking
{
    public class MAddTrack: BaseCommands,ICommand
    {
        public MAddTrack(Logger logger) : base(logger) { }

        /// <summary>
        /// joining the campaign
        /// Adding the data into the table of the Money tracking.
        /// </summary>
        /// <param name="argv">Id of the campaign and the active.</param>
        /// <returns>If the operation was successful.</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is TBMoneyTracking)
                {
                    TBMoneyTracking moneyTracking = (TBMoneyTracking)item;

                    if (moneyTracking != null)
                    {
                        MainManager.INSTANCE.SocialActivists.PostDataTracking(moneyTracking);

                        base.Logger.LogEvent("The operation of joining and saving the data was carried out successfully in MAddTrack");

                        return"The operation was successful";
                    }
                }
            }

            base.Logger.LogEvent("\nThe operation of joining and saving the data failed, the details received are incorrect\n");

            return "The operation failed";
        }
        public void Init() { }
    }
}
