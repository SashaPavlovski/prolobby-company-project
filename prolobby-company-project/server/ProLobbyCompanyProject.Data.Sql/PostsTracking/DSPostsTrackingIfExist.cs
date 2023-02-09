using ProLobbyCompanyProject.Dal.SqlQueryClasses;
using System.Data.SqlClient;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql.PostsTracking
{
    public class DSPostsTrackingIfExist: BaseDataSql
    {
        //Checking whether this date of yesterday exists in the table
        //Checking whether a Twitter scan has already been done
        public DSPostsTrackingIfExist(Logger Logger) : base(Logger) { }
        public int CheckIfExistPostTracking(object newData, System.Data.SqlClient.SqlCommand command)
        {
            int answer = 0;
            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            try
                            {
                                answer = int.Parse(reader["answer"].ToString());
                            }
                            catch (System.Exception EX)
                            {

                                throw;
                            }
                        }
                    }
                }
            }
            catch (System.Exception EX)
            {

                throw;
            }
            return answer;
        }

        string insertCheck = "declare @answer int\r\n if exists (select [Date] from [dbo].[TBPostsTrackings] \r\n   where DATEPART (YEAR,[Date])  =  DATEPART (YEAR,getdate()-1)\r\n   and DATEPART (MONTH,[Date])  =  DATEPART (MONTH,getdate()-1)\r\n   and DATEPART (DAY,[Date])  =  DATEPART (DAY,getdate()-1) \r\n   and [Active] = 1 )\r\n      begin \r\n\t  SET @answer = 1\r\n\t  select @answer as 'answer'\r\n\t  end\r\n else\r\n \t  begin \r\n\t  SET @answer = -1\r\n\t  select @answer as 'answer'\r\n\t  end\r\n";

        public int? IfExistPostsTracking()
        {
            try
            {
                SqlQueryPost sqlQuery = new SqlQueryPost();
                return sqlQuery.RunAdd(insertCheck, CheckIfExistPostTracking, null);
            }
            catch (System.Exception EX)
            {

                throw;
            }
        }
    }
}
