using ProLobbyCompanyProject.Model.SortingTables.SortingUsers;
using System;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.Reports
{
    public class RByUsers: BaseCommands,ICommand
    {
        public RByUsers(Logger logger) : base(logger) { }

        /// <summary>
        /// Sort user reports.
        /// </summary>
        /// <param name="argv">Sorting options Id</param>
        /// <returns>A report is sorted according to the sorting option.</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is string)
                {
                    string userId = (string)item;

                    List<TBSortingUsers> ListSortingUsers = MainManager.INSTANCE.Twitter.GetSortingUsers(userId);

                    string responseUsersList = System.Text.Json.JsonSerializer.Serialize(ListSortingUsers);

                    Console.WriteLine(responseUsersList);

                    base.Logger.LogEvent("The operation of sorting the user reports was carried out successfully in RByProducts");

                    return responseUsersList;
                }
            }

            base.Logger.LogError("\nThe user report sorting operation failed, no sorting option was received in RByProducts.\n"); 
            return null;
        }
        public void Init() { }
    }
}
