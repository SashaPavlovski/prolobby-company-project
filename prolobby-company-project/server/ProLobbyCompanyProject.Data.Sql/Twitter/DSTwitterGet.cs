////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Twitter\DSTwitterGet.cs
//
// summary:	Implements the ds twitter get class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using ProLobbyCompanyProject.Model.Twitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.Twitter
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The ds twitter get. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DSTwitterGet
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DSTwitterGet() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a non profit organization information. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="reader">   The reader. </param>
        /// <param name="command">  The command. </param>
        /// <param name="UserId">   Identifier for the user. </param>
        ///
        /// <returns>   An object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public object AddNonProfitOrganizationInformation(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            List<MATwitter> twittwrData = new List<MATwitter>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    twittwrData.Add(new MATwitter() { MoneyTracking_Id = int.Parse(reader["MoneyTracking_Id"].ToString()), SocialActivists_Id = int.Parse(reader["SocialActivists_Id"].ToString()), Twitter_user = reader["Twitter_user"].ToString(), Hashtag = reader["Hashtag"].ToString(), Accumulated_money = double.Parse(reader["Accumulated_money"].ToString()) });
                }
                return twittwrData;
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
            return;
        }


        /// <summary>   Identifier for the terabytes 3. campaigns. </summary>
        string insertGetData = "select TB1.[SocialActivists_Id],TB2.Twitter_user,TB3.Hashtag,TB1.Accumulated_money,\r\nTB1.MoneyTracking_Id\r\nfrom [dbo].[TBMoneyTrackings] TB1 inner join [dbo].[TBSocialActivists] TB2\r\non TB2.SocialActivists_Id = TB1.SocialActivists_Id\r\ninner join [dbo].[TBCampaigns] TB3 on TB3.Campaigns_Id = TB1.Campaigns_Id";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets twitter user row. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <returns>   The twitter user row. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<MATwitter> GetTwitterUserRow()
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<MATwitter> newData = null;
            object listNewData = sqlQuery1.RunCommand(insertGetData, AddNonProfitOrganizationInformation, SetValues, null, null, null, null);

            if (listNewData is List<MATwitter>)
            {
                newData = (List<MATwitter>)listNewData;
            }
            return newData;
        }


    }
}
