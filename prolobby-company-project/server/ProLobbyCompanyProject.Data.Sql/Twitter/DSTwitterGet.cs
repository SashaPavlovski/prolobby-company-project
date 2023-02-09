using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model.Twitter;
using System;
using System.Collections.Generic;
using Utilities.Logger;


// file:	Twitter\DSTwitterGet.cs
// summary:	Implements the ds twitter get class

namespace ProLobbyCompanyProject.Data.Sql.Twitter
{
    public class DSTwitterGet: BaseDataSql
    {
        public DSTwitterGet(Logger Logger) : base(Logger) { }

        //Add data about the user for the list
        //Checks if the user has already tweeted
        //And what is the date of the last tweet?
        //or the date of joining if no tweet was made
        public object AddTwitterUserRow(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            List<MATwitter> twitterData = new List<MATwitter>();
            twitterData.Clear();

            bool Flag = true;
            
            while (Flag)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string Answer = reader["Answer"].ToString();
                        switch (Answer)
                        {

                            case "No tweets and valid":

                                try
                                {
                                    DateTime? DateTweetsValid = DateTime.Parse(reader["MoneyDateActive"].ToString());
                                    string AnswerTweetsValid = reader["Answer"].ToString();
                                    SetTwitterDataValues(reader, twitterData, DateTweetsValid, AnswerTweetsValid);
                                }
                                catch (Exception EX)
                                {

                                    throw;
                                }

                                break;

                            case "No tweets and invalid":

                                try
                                {
                                    DateTime? DatTweetsInvalide = null;
                                    string AnswerTweetsInvalide = reader["Answer"].ToString();
                                    SetTwitterDataValues(reader, twitterData, DatTweetsInvalide, AnswerTweetsInvalide);
                                }
                                catch (Exception EX)
                                {

                                    throw;
                                }

                                break;

                            case "Exist tweets and valid":

                                try
                                {
                                    DateTime? DatExistTweetsValid = DateTime.Parse(reader["PostsDateActive"].ToString());
                                    string AnswerExistTweetsValid = reader["Answer"].ToString();
                                    SetTwitterDataValues(reader, twitterData, DatExistTweetsValid, AnswerExistTweetsValid);
                                }
                                catch (Exception EX)
                                {

                                    throw;
                                }

                                break;

                            case "Exist tweets and invalid":

                                try
                                {
                                    DateTime? DatExistTweetsInvalid = null;
                                    string AnswerExistTweetsInvalid = reader["Answer"].ToString();
                                    SetTwitterDataValues(reader, twitterData, DatExistTweetsInvalid, AnswerExistTweetsInvalid);
                                }
                                catch (Exception EX)
                                {

                                    throw;
                                }

                                break;

                        }
                    }
                }

                if (!reader.NextResult())
                {
                    Flag = false;
                    return twitterData;

                }
            }
            return null;
        }

        //Add data about the user for the list
        public void SetTwitterDataValues(System.Data.SqlClient.SqlDataReader reader,List<MATwitter> twitterData , DateTime? data,string answer)
        {
            if (reader.HasRows)
            {
                try
                {
                    twitterData.Add(new MATwitter
                    {
                        MoneyTracking_Id = int.Parse(reader["MoneyTracking_Id"].ToString()),
                        Tweets_Message_Id = reader["Tweets_Message_Id"].ToString(),
                        SocialActivists_Id = int.Parse(reader["SocialActivists_Id"].ToString()),
                        Twitter_user = reader["Twitter_user"].ToString(),
                        Hashtag = reader["Hashtag"].ToString(),
                        Accumulated_money = double.Parse(reader["Accumulated_money"].ToString()),
                        Answer = answer,
                        Date = data
                    });
                }
                catch (Exception EX)
                {

                    throw;
                }
            }
            return;
        }
        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            //command.CommandType = CommandType.StoredProcedure;
            return;
        }


        /// <summary>   Identifier for the terabytes 3. campaigns. </summary>
        string insertGetData = "AllUserDetails";


        /// <summary>   Gets twitter user row. </summary>
        /// <returns>   The twitter user List row. </returns>
        public List<MATwitter> GetTwitterUserRow()
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<MATwitter> newData = null;

            try
            {
                object listNewData = sqlQuery1.RunCommand(insertGetData, AddTwitterUserRow, SetValues, null, null, null, null);

                if (listNewData is List<MATwitter>)
                {
                    newData = (List<MATwitter>)listNewData;
                }
            }
            catch (Exception EX)
            {

                throw;
            }

            return newData;
        }


    }
}
