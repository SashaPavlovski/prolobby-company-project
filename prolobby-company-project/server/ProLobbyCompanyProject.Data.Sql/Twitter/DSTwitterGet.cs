using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model.Twitter;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Utilities.Logger;


// file:	Twitter\DSTwitterGet.cs
// summary:	Implements the ds twitter get class

namespace ProLobbyCompanyProject.Data.Sql.Twitter
{
    public class DSTwitterGet: BaseDataSql
    {
        SqlQuery SqlQuery = new SqlQuery();
        public DSTwitterGet(Logger Logger) : base(Logger)
        {
            SqlQuery = new SqlQuery();
        }

        /// <summary>
        /// Add data about the user for the list
        /// Checks if the user has already tweeted
        /// And what is the date of the last tweet?
        /// Or the date of joining if no tweet was made
        /// </summary>
        /// <param name="reader"> Getting details from the sql. </param>
        /// <param name="command"> sql connection</param>
        /// <param name="UserId"></param>
        /// <returns> The twitter user list details. </returns>

        public object AddTwitterUserRow(SqlDataReader reader, SqlCommand command, string UserId)
        {
            Logger.LogEvent("\n\nEnter into AddTwitterUserRow function");

            List<MATwitter> twitterData = new List<MATwitter>();
            twitterData.Clear();

            bool Flag = true;

            Logger.LogEvent("Gets all the details of the users who follow at least one campaign");

            while (Flag)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        try
                        {
                            string Answer = reader["Answer"].ToString();

                            if (Answer == null)
                            {
                                Logger.LogError("End AddTwitterUserRow function,The Answer of type of tweets is null");

                                return null;
                            }

                            switch (Answer)
                            {

                                case "No tweets and valid":

                                    try
                                    {
                                        DateTime? DateTweetsValid = DateTime.Parse(reader["MoneyDateActive"].ToString());
                                        string AnswerTweetsValid = reader["Answer"].ToString();
                                        SetTwitterDataValues(reader, twitterData, DateTweetsValid, AnswerTweetsValid);
                                    }
                                    catch (SqlException Ex)
                                    {
                                        Logger.LogException(Ex.Message, Ex);

                                        throw;
                                    }
                                    catch (Exception Ex)
                                    {
                                        Logger.LogException(Ex.Message, Ex);

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
                                    catch (SqlException Ex)
                                    {
                                        Logger.LogException(Ex.Message, Ex);

                                        throw;
                                    }
                                    catch (Exception Ex)
                                    {
                                        Logger.LogException(Ex.Message, Ex);

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
                                    catch (SqlException Ex)
                                    { 
                                        Logger.LogException(Ex.Message, Ex);

                                        throw;
                                    }
                                    catch (Exception Ex)
                                    {
                                        Logger.LogException(Ex.Message, Ex);

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
                                    catch (SqlException Ex)
                                    {
                                        Logger.LogException(Ex.Message, Ex);

                                        throw;
                                    }
                                    catch (Exception Ex)
                                    {
                                        Logger.LogException(Ex.Message, Ex);

                                        throw;
                                    }

                                    break;
                            }
                        }
                        catch (SqlException Ex)
                        {
                            Logger.LogException(Ex.Message, Ex);

                            throw;
                        }
                        catch (Exception Ex)
                        {
                            Logger.LogException(Ex.Message, Ex);

                            throw;
                        }
                    }
                }

                if (!reader.NextResult())
                {
                    Flag = false;

                    Logger.LogEvent("End AddTwitterUserRow function successfully");

                    return twitterData;

                }
            }

            Logger.LogEvent("End AddTwitterUserRow function, return null");

            return null;
        }

        /// <summary>
        /// Add data about the user for the list
        /// </summary>
        /// <param name="reader"> Getting details from the sql. </param>
        /// <param name="twitterData"> A list containing the details. </param>
        /// <param name="date"> The date of the tweet. </param>
        /// <param name="answer"> Information about the tweet. </param>
        public void SetTwitterDataValues(SqlDataReader reader,List<MATwitter> twitterData , DateTime? date,string answer)
        {
            Logger.LogEvent("\n\nEnter into SetTwitterDataValues function");

            Logger.LogEvent("Gets all the details about activists posts that are shared with each other");

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
                        Date = date
                    });

                    Logger.LogEvent("End SetTwitterDataValues function successfully");

                }
                catch (SqlException Ex)
                {
                    Logger.LogException(Ex.Message, Ex);

                    throw;
                }
                catch (Exception Ex)
                {
                    Logger.LogException(Ex.Message, Ex);

                    throw;
                }
            }
        }
        public void SetValues(SqlCommand command, string key, string value, string key2, string value2)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return;
        }

        /// <summary>
        /// sql procedure name - Receiving all the details of the users who follow at least one campaign.
        /// </summary>
        string insertGetData = "AllUserDetails";


        /// <summary>   Gets all the details of the users who follow at least one campaign </summary>
        /// <returns>   The twitter user list details. </returns>
        public List<MATwitter> GetTwitterUserRow()
        {
            Logger.LogEvent("Enter into GetTwitterUserRow function");

            List<MATwitter> newData = null;

            try
            {
                object listNewData = SqlQuery.RunCommand(insertGetData, AddTwitterUserRow, SetValues, null, null, null, null);

                if (listNewData!= null && listNewData is List<MATwitter>)
                {
                    newData = (List<MATwitter>)listNewData;

                    Logger.LogEvent("End GetTwitterUserRow function successfully");

                    return newData;
                }

                Logger.LogEvent("End GetTwitterUserRow function, return null");

                return newData;

            }
            catch (Exception Ex)
            {
                Logger.LogException(Ex.Message, Ex);

                throw;
            }
        }
    }
}
