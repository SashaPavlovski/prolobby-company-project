////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	MoneyTracking\DSMoneyTrackingGetUserMoney.cs
//
// summary:	Implements the ds money tracking get user money class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using ProLobbyCompanyProject.Model.MoneyTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.MoneyTracking
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The ds money tracking get user money. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DSMoneyTrackingGetUserMoney
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DSMoneyTrackingGetUserMoney() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a money data. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="reader">   The reader. </param>
        /// <param name="command">  The command. </param>
        /// <param name="UserId">   Identifier for the user. </param>
        ///
        /// <returns>   An object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public object AddMoneyData(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            List<MAMoneyTracking> moneyTracking = new List<MAMoneyTracking>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    moneyTracking.Add(new MAMoneyTracking() { NonProfitOrganizationName = reader["NonProfitOrganizationName"].ToString(), Campaigns_Name = reader["Campaigns_Name"].ToString(), Hashtag = reader["Hashtag"].ToString(), Accumulated_money = int.Parse(reader["Accumulated_money"].ToString()), Active = bool.Parse(reader["Active"].ToString()) });
                }
                return moneyTracking;
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets the values. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="command">  The command. </param>
        /// <param name="key">      The key. </param>
        /// <param name="value">    The value. </param>
        /// <param name="key2">     The second key. </param>
        /// <param name="value2">   The second value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            command.Parameters.AddWithValue($"@{key}", int.Parse(value));
        }
        /// <summary>   Information describing the insertget money. </summary>
        string insertgetMoneyData = "if  exists (select * from [dbo].[TBMoneyTrackings] where [SocialActivists_Id] = @SocialActivists_Id )\r\nbegin\r\n        select TB1.Accumulated_money ,TB1.Active,\r\n\t\tTB2.Campaigns_Name,TB2.Hashtag, TB3.NonProfitOrganizationName\r\n\t\tfrom [dbo].[TBMoneyTrackings] TB1 inner join [dbo].[TBCampaigns] TB2\r\n        on  TB1.Campaigns_Id = TB2.Campaigns_Id \r\n\t\tinner join [dbo].[TBNonProfitOrganizations] TB3 on\r\n\t\tTB3.NonProfitOrganization_Id = TB2.NonProfitOrganization_Id\r\n\t\twhere TB1.SocialActivists_Id = @SocialActivists_Id\r\n\t\r\nend";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets monet data row. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="IdUser">   The identifier user. </param>
        ///
        /// <returns>   The monet data row. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<MAMoneyTracking> GetMonetDataRow(string IdUser)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<MAMoneyTracking> moneyTrackingList = null;


            object listData = sqlQuery1.RunCommand(insertgetMoneyData, AddMoneyData, SetValues, "SocialActivists_Id", IdUser, null, null);

            if (listData is List<MAMoneyTracking>)
            {
                moneyTrackingList = (List<MAMoneyTracking>)listData;
            }
            return moneyTrackingList;
        }


    }
}
