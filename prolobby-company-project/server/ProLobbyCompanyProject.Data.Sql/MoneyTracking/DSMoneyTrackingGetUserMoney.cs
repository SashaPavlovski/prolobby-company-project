using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model.MoneyTracking;
using System;
using System.Collections.Generic;
using Utilities.Logger;


// file:	MoneyTracking\DSMoneyTrackingGetUserMoney.cs
// summary:	Implements the ds money tracking get user money class

namespace ProLobbyCompanyProject.Data.Sql.MoneyTracking
{
    /// <summary>   get user money from money tracking . </summary>

    public class DSMoneyTrackingGetUserMoney: BaseDataSql
    {
        SqlQuery SqlQuery;

        /// <summary>   Default constructor. </summary>
        public DSMoneyTrackingGetUserMoney(Logger Logger) : base(Logger)
        {
            SqlQuery = new SqlQuery();
        }

        /// <summary>   get a money data. </summary>
        /// <param name="reader">   The reader. </param>
        /// <param name="command">  The command. </param>
        /// <param name="UserId">   Identifier for the user. </param>
        /// <returns>   An object with MAMoneyTracking List . </returns>
        public object AddMoneyData(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            Logger.LogEvent("Enter into AddMoneyData function");

            Logger.LogEvent("Get financial data of social activists");

            List<MAMoneyTracking> moneyTracking = new List<MAMoneyTracking>();

            try
            {
                if (reader.HasRows)
                {
                    try
                    {
                        while (reader.Read())
                        {

                            moneyTracking.Add(new MAMoneyTracking
                            {
                                NonProfitOrganizationName = reader["NonProfitOrganizationName"].ToString(),
                                Campaigns_Name = reader["Campaigns_Name"].ToString(),
                                Hashtag = reader["Hashtag"].ToString(),
                                Accumulated_money = int.Parse(reader["Accumulated_money"].ToString()),
                                Active = bool.Parse(reader["Active"].ToString())
                            });

                        }

                        Logger.LogEvent("End AddMoneyData function Successfully");

                        return moneyTracking;

                    }
                    catch (Exception EX)
                    {

                        throw;
                    }
                }

                Logger.LogEvent("End AddMoneyData function and return null");

                return null;

            }
            catch (Exception EX)
            {

                throw;
            }
        }

        /// <summary>   Sets the values. </summary>
        /// <param name="command">  The command. </param>
        /// <param name="key">      The key. </param>
        /// <param name="value">    The value. </param>
        /// <param name="key2">     The second key. </param>
        /// <param name="value2">   The second value. </param>
        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            Logger.LogEvent("Enter into SetValues function");

            Logger.LogEvent("data entry");

            try
            {
                command.Parameters.AddWithValue($"@{key}", int.Parse(value));

                Logger.LogEvent("Operation performed successfully");

                Logger.LogEvent("End SetValues function");

            }
            catch (Exception EX)
            {

                throw;
            }
        }

        /// <summary>   Information describing the insertget money. </summary>
        string insertgetMoneyData = "if  exists (select * from [dbo].[TBMoneyTrackings] where [SocialActivists_Id] = @SocialActivists_Id )\r\nbegin\r\n        select TB1.Accumulated_money ,TB1.Active,\r\n\t\tTB2.Campaigns_Name,TB2.Hashtag, TB3.NonProfitOrganizationName\r\n\t\tfrom [dbo].[TBMoneyTrackings] TB1 inner join [dbo].[TBCampaigns] TB2\r\n        on  TB1.Campaigns_Id = TB2.Campaigns_Id \r\n\t\tinner join [dbo].[TBNonProfitOrganizations] TB3 on\r\n\t\tTB3.NonProfitOrganization_Id = TB2.NonProfitOrganization_Id\r\n\t\twhere TB1.SocialActivists_Id = @SocialActivists_Id\r\n\t\r\nend";

        /// <summary>   Gets monet data row. </summary>
        /// <param name="IdUser">   The identifier user. </param>
        /// <returns>   The monet data row in List. </returns>
        public List<MAMoneyTracking> GetMonetDataRow(string IdUser)
        {
            Logger.LogEvent("Enter into GetMonetDataRow function");

            List<MAMoneyTracking> moneyTrackingList = null;

            object listData;
            try
            {
                listData = SqlQuery.RunCommand(insertgetMoneyData, AddMoneyData, SetValues, "SocialActivists_Id", IdUser, null, null);
            }
            catch (Exception EX)
            {

                throw;
            }

            if (listData is List<MAMoneyTracking>)
            {
                moneyTrackingList = (List<MAMoneyTracking>)listData;

                Logger.LogEvent("End GetMonetDataRow function and return money tracking list");

                return moneyTrackingList;

            }

            Logger.LogEvent("End GetMonetDataRow function and return null");

            return moneyTrackingList;
        }
    }
}
