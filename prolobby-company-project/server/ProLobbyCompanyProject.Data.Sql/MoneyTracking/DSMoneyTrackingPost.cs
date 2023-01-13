////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	MoneyTracking\DSMoneyTrackingPost.cs
//
// summary:	Implements the ds money tracking post class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.MoneyTracking
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The ds money tracking post. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DSMoneyTrackingPost
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DSMoneyTrackingPost() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a user data to 'command'. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="newData">  Information describing the new. </param>
        /// <param name="command">  The command. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AddUserData(object newData, System.Data.SqlClient.SqlCommand command)
        {
            if (newData is TBMoneyTracking)
            {
                TBMoneyTracking moneyTracking = (TBMoneyTracking)newData;

                command.Parameters.AddWithValue("@SocialActivists_Id", moneyTracking.SocialActivists_Id);
                command.Parameters.AddWithValue("@Campaigns_Id", moneyTracking.Campaigns_Id);
                //command.Parameters.AddWithValue("@Accumulated_money", moneyTracking.Accumulated_money);
                //command.Parameters.AddWithValue("@Active", moneyTracking.Active);

            }
            int rows = command.ExecuteNonQuery();
        }

        /// <summary>   Information describing the insert new. </summary>
        string insertNewData = "if not exists (select * from [dbo].[TBMoneyTrackings] where [SocialActivists_Id] = @SocialActivists_Id  and [Campaigns_Id] = @Campaigns_Id)\r\nbegin\r\ninsert into [dbo].[TBMoneyTrackings]\r\nvalues (@SocialActivists_Id ,@Campaigns_Id ,0,1)\r\nend";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Posts a money tracking. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="moneyTracking">    The money tracking. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PostMoneyTracking(TBMoneyTracking moneyTracking)
        {
            SqlQueryPost sqlQuery = new SqlQueryPost();
            sqlQuery.RunAddUser(insertNewData, AddUserData, moneyTracking);
        }

    }
}
