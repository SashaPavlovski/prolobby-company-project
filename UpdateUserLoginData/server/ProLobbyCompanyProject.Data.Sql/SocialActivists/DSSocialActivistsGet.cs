using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql
{
    public class DSSocialActivistsGet
    {
        public DSSocialActivistsGet() { }

        public object AddSocialActivistsInformation(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            List<TBSocialActivists> socialActivists = new List<TBSocialActivists>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    socialActivists.Add(new TBSocialActivists() { SocialActivists_Id = int.Parse(reader["SocialActivists_Id"].ToString()),Address = reader["Address"].ToString(), Email = reader["Email"].ToString(), FirstName = reader["FirstName"].ToString(), LastName = reader["LastName"].ToString(), Phone_number = reader["Phone_number"].ToString(), Twitter_user = reader["Twitter_user"].ToString() });

                }
                return socialActivists;
            }
            return null;
        }

        string insertSocialActivists = "if exists (select  [User_Id]  from [dbo].[TBSocialActivists] where [User_Id] = @User_Id)\r\nbegin\r\n       select SocialActivists_Id,[FirstName],[LastName],[Address],[Email],[Twitter_user],[Phone_number]\r\n\t   from [dbo].[TBSocialActivists]\r\n\t   where [User_Id] = @User_Id\r\nend";

        public List<TBSocialActivists> GetSocialActivistsRow(string IdUser)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBSocialActivists> SocialActivists = null;
            object listSocialActivists = sqlQuery1.RunCommand(insertSocialActivists, AddSocialActivistsInformation, IdUser); ;

            if (listSocialActivists is List<TBSocialActivists>)
            {
                SocialActivists = (List<TBSocialActivists>)listSocialActivists;
            }
            return SocialActivists;
        }
    }
}
