using ProLobbyCompanyProject.Model.SortingTables.SortingPosts;
using System;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Entites.Commands.Reports
{
    public class RByPosts: BaseCommands,ICommand
    {
        public RByPosts(Logger logger) : base(logger) { }

        /// <summary>
        /// Sorting the posting reports on Twitter.
        /// </summary>
        /// <param name="argv">Sorting options Id</param>
        /// <returns>The sorted Twitter report.</returns>
        public object Execute(params object[] argv)
        {
            foreach (var item in argv)
            {
                if (item is string)
                {
                    string userId = (string)item;

                    List<TBSortingPosts> ListSortingPosts = MainManager.INSTANCE.Twitter.GetSortingPosts(userId);

                    string responsePostsList = System.Text.Json.JsonSerializer.Serialize(ListSortingPosts);

                    Console.WriteLine(responsePostsList);

                    base.Logger.LogEvent("The operation of sorting the Twitter posts reports was carried out successfully in RByPosts");

                    return responsePostsList;
                }
            }

            base.Logger.LogError("\nThe Twitter posts report sorting operation failed, no sorting option was received in RByPosts.\n");

            return null;
        }
        public void Init() { }
    }
}
