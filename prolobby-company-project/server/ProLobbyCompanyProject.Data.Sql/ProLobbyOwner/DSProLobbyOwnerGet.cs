////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	ProLobbyOwner\DSProLobbyOwnerGet.cs
//
// summary:	Implements the ds pro lobby owner get class
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
    /// <summary>   The ds pro lobby owner get. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DSProLobbyOwnerGet
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DSProLobbyOwnerGet() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a pro lobby owner information. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="reader">   The reader. </param>
        /// <param name="command">  The command. </param>
        /// <param name="UserId">   Identifier for the user. </param>
        ///
        /// <returns>   An object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public object AddProLobbyOwnerInformation(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            List<TBProLobbyOwner> proLobbyOwner = new List<TBProLobbyOwner>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    proLobbyOwner.Add(new TBProLobbyOwner() { ProLobbyOwner_Id = int.Parse(reader["ProLobbyOwner_Id"].ToString()), FirstName = reader["FirstName"].ToString(), LastName = reader["LastName"].ToString(), Phone_number = reader["Phone_number"].ToString(), Email = reader["Email"].ToString() });
                }
                return proLobbyOwner;
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

        /// <summary>   The owner of the insert pro lobby. </summary>
        string insertProLobbyOwner = "if exists (select  [User_Id]  from [dbo].[TBProLobbyOwners] where [User_Id] = @User_Id)\r\nbegin\r\n select ProLobbyOwner_Id,[FirstName],[LastName],[Email],[Phone_number]\r\n\t   from [dbo].[TBProLobbyOwners]\r\n\t   where [User_Id] = @User_Id\r\nend";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets pro lobby owner user row. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="IdUser">   The identifier user. </param>
        ///
        /// <returns>   The pro lobby owner user row. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<TBProLobbyOwner> GetProLobbyOwnerUserRow(string IdUser)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBProLobbyOwner> ProLobbyOwnerList = null;
            object listProLobbyOwner = sqlQuery1.RunCommand(insertProLobbyOwner, AddProLobbyOwnerInformation, SetValues, "User_Id", IdUser, null, null); ;

            if (listProLobbyOwner is List<TBProLobbyOwner>)
            {
                ProLobbyOwnerList = (List<TBProLobbyOwner>)listProLobbyOwner;
            }
            return ProLobbyOwnerList;
        }

    }
}
