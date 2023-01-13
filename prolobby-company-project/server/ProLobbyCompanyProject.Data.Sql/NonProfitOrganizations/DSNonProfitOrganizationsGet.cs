////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	NonProfitOrganizations\DSNonProfitOrganizationsGet.cs
//
// summary:	Implements the ds non profit organizations get class
////////////////////////////////////////////////////////////////////////////////////////////////////

using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The ds non profit organizations get. </summary>
    ///
    /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DSNonProfitOrganizationsGet
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DSNonProfitOrganizationsGet() { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a photo. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="filePath"> Full pathname of the file. </param>
        ///
        /// <returns>   An array of byte. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public byte[] GetPhoto(string filePath)
        {
            FileStream stream = new FileStream(
                filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
        }

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
            List<TBNonProfitOrganization> nonProfitOrganization = new List<TBNonProfitOrganization>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    nonProfitOrganization.Add(new TBNonProfitOrganization() { NonProfitOrganization_Id = int.Parse(reader["NonProfitOrganization_Id"].ToString()), NonProfitOrganizationName = reader["NonProfitOrganizationName"].ToString(), RepresentativeFirstName = reader["RepresentativeFirstName"].ToString(), RepresentativeLastName = reader["RepresentativeLastName"].ToString(), decreption = reader["decreption"].ToString(), Phone_number = reader["Phone_number"].ToString(), Email = reader["Email"].ToString(), Logo = null, Url = reader["Url"].ToString() });

                }
                return nonProfitOrganization;
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

        /// <summary>   declare @User_Id  nvarchar(max)\r\n. </summary>

        string insertNonProfitOrganization = "if exists (select  [User_Id]  from [dbo].[TBNonProfitOrganizations] where [User_Id] = @User_Id)\r\nbegin\r\nselect  NonProfitOrganization_Id,[NonProfitOrganizationName],[Url],[decreption],[Email],[RepresentativeFirstName],\r\n[RepresentativeLastName],[Phone_number],[Logo]\r\n\t   from [dbo].[TBNonProfitOrganizations]\r\n\t   where [User_Id] = @User_Id\r\nend";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets non profit user row. </summary>
        ///
        /// <remarks>   Sasha Pavlovski, 1/12/2023. </remarks>
        ///
        /// <param name="IdUser">   The identifier user. </param>
        ///
        /// <returns>   The non profit user row. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<TBNonProfitOrganization> GetNonProfitUserRow(string IdUser)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBNonProfitOrganization> NonProfitOrganization = null;
            object listNonProfitOrganization = sqlQuery1.RunCommand(insertNonProfitOrganization, AddNonProfitOrganizationInformation, SetValues, "User_Id", IdUser, null, null);

            if (listNonProfitOrganization is List<TBNonProfitOrganization>)
            {
                NonProfitOrganization = (List<TBNonProfitOrganization>)listNonProfitOrganization;
            }
            return NonProfitOrganization;
        }
    }
}
