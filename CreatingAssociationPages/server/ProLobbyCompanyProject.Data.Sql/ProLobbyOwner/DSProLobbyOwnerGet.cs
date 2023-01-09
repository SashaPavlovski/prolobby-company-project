using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql
{
    public class DSProLobbyOwnerGet
    {
        public DSProLobbyOwnerGet() { }

        public object AddProLobbyOwnerInformation(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            List<TBProLobbyOwner> proLobbyOwner = new List<TBProLobbyOwner>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    proLobbyOwner.Add(new TBProLobbyOwner() { ProLobbyOwner_Id = int.Parse(reader["ProLobbyOwner_Id"].ToString()),FirstName = reader["FirstName"].ToString(), LastName = reader["LastName"].ToString(), Phone_number = reader["Phone_number"].ToString(), Email = reader["Email"].ToString() });
                }
                return proLobbyOwner;
            }
            return null;
        }


        string insertProLobbyOwner = "if exists (select  [User_Id]  from [dbo].[TBProLobbyOwners] where [User_Id] = @User_Id)\r\nbegin\r\n select ProLobbyOwner_Id,[FirstName],[LastName],[Email],[Phone_number]\r\n\t   from [dbo].[TBProLobbyOwners]\r\n\t   where [User_Id] = @User_Id\r\nend";


        public List<TBProLobbyOwner> GetProLobbyOwnerUserRow(string IdUser)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBProLobbyOwner> ProLobbyOwnerList = null;
            object listProLobbyOwner = sqlQuery1.RunCommand(insertProLobbyOwner, AddProLobbyOwnerInformation, "User_Id", IdUser); ;

            if (listProLobbyOwner is List<TBProLobbyOwner>)
            {
                ProLobbyOwnerList = (List<TBProLobbyOwner>)listProLobbyOwner;
            }
            return ProLobbyOwnerList;
        }

    }
}
