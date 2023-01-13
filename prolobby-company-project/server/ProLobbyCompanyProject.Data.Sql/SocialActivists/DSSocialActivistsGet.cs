////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	SocialActivists\DSSocialActivistsGet.cs
//
// summary:	Implements the ds social activists get class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The ds social activists get. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DSSocialActivistsGet
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DSSocialActivistsGet() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a social activists information. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="reader">   The reader. </param>
        /// <param name="command">  The command. </param>
        /// <param name="UserId">   Identifier for the user. </param>
        ///
        /// <returns>   An object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public object AddSocialActivistsInformation(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            List<TBSocialActivists> socialActivists = new List<TBSocialActivists>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    socialActivists.Add(new TBSocialActivists() { SocialActivists_Id = int.Parse(reader["SocialActivists_Id"].ToString()), Address = reader["Address"].ToString(), Email = reader["Email"].ToString(), FirstName = reader["FirstName"].ToString(), LastName = reader["LastName"].ToString(), Phone_number = reader["Phone_number"].ToString(), Twitter_user = reader["Twitter_user"].ToString() });

                }
                return socialActivists;
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
            command.Parameters.AddWithValue($"@{key}", value);
        }

        /// <summary>   The insert social activists. </summary>
        string insertSocialActivists = "if exists (select  [User_Id]  from [dbo].[TBSocialActivists] where [User_Id] = @User_Id)\r\nbegin\r\n       select SocialActivists_Id,[FirstName],[LastName],[Address],[Email],[Twitter_user],[Phone_number]\r\n\t   from [dbo].[TBSocialActivists]\r\n\t   where [User_Id] = @User_Id\r\nend";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets social activists row. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="IdUser">   The identifier user. </param>
        ///
        /// <returns>   The social activists row. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<TBSocialActivists> GetSocialActivistsRow(string IdUser)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBSocialActivists> SocialActivists = null;
            object listSocialActivists = sqlQuery1.RunCommand(insertSocialActivists, AddSocialActivistsInformation, SetValues, "User_Id", IdUser, null, null);

            if (listSocialActivists is List<TBSocialActivists>)
            {
                SocialActivists = (List<TBSocialActivists>)listSocialActivists;
            }
            return SocialActivists;
        }
    }
}
