using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// file:	ProLobbyOwner\DSProLobbyOwnerGet.cs
// summary:	Implements the ds pro lobby owner get class

namespace ProLobbyCompanyProject.Data.Sql
{
    /// <summary>  Checking whether it exists prolobby owner . </summary>
    /// <summary>  If exists, receiving the details . </summary>
    public class DSProLobbyOwnerGet
    {
        /// <summary>   Default constructor. </summary>
        public DSProLobbyOwnerGet() { }

        /// <summary>   Adds a prolobby owner information. </summary>
        /// <param name="reader">   The reader. </param>
        /// <param name="command">  The command. </param>
        /// <param name="UserId">   Identifier for the user. </param>
        /// <returns>   An object TBProLobbyOwner List. </returns>
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

        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            command.Parameters.AddWithValue($"@{key}", value);
        }

        /// <summary>   The owner of the insert pro lobby. </summary>
        string insertProLobbyOwner = "if exists (select  [User_Id]  from [dbo].[TBProLobbyOwners] where [User_Id] = @User_Id)\r\nbegin\r\n select ProLobbyOwner_Id,[FirstName],[LastName],[Email],[Phone_number]\r\n\t   from [dbo].[TBProLobbyOwners]\r\n\t   where [User_Id] = @User_Id\r\nend";


        /// <summary>   Gets prolobby owner user row. </summary>
        /// <param name="IdUser">   The identifier user. </param>
        /// <returns>   The pro lobby owner user row List. </returns>
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
