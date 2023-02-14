using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql.DonatedProducts
{
    public class DSDonatedProductsGetById: BaseDataSql
    {
        SqlQuery SqlQuery;
        public DSDonatedProductsGetById(Logger Logger) : base(Logger)
        {
            SqlQuery = new SqlQuery();
        }

        //Receiving item details
        //by the id of the social activist
        public object AddDonatedProductsByUserId(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string UserId)
        {
            Logger.LogEvent("Enter into AddDonatedProductsByUserId function");

            Logger.LogEvent("Get all the products bought by receiving an ID of the social activist");

            List<TBDonatedProducts> donatedProducts = new List<TBDonatedProducts>();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        donatedProducts.Add(new TBDonatedProducts
                        {
                            Product_Name = reader["Product_Name"].ToString(),
                            Price = double.Parse(reader["Price"].ToString()),
                            Active = bool.Parse(reader["Sent"].ToString())
                        });
                    }

                    Logger.LogEvent("End AddDonatedProductsByUserId function and raturn all products");

                    return donatedProducts;
                }
            }
            catch (SqlException Ex) { Logger.LogException(Ex.Message, Ex); throw; }
            catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }

            Logger.LogEvent("End AddDonatedProductsByUserId function and raturn null");

            return null;
        }

        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            Logger.LogEvent("Enter into SetValues function");

            if (key != null && value != null)
            {
                try
                {
                    Logger.LogEvent("Entering data into values");

                    command.Parameters.AddWithValue($"@{key}", int.Parse(value));
                }
                catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }
            }

            Logger.LogEvent("End SetValues function");

        }


        string insertProductById = "if  exists (select * from [dbo].[TBShippers] where [SocialActivists_Id] = @SocialActivists_Id )\r\nbegin\r\n     select TB1.Product_Name,TB1.Price,TB2.Sent\r\n     from [dbo].[TBDonatedProducts] TB1 inner join [dbo].[TBShippers] TB2\r\n     on TB1.DonatedProducts_Id =  TB2.DonatedProducts_Id\r\n\t where TB2.SocialActivists_Id = @SocialActivists_Id\r\nend  ";

        //Moves the products using a list
        public List<TBDonatedProducts> GetProductsByUserId(string userId)
        {
            Logger.LogEvent("\n\nEnter into GetProductsByUserId function");

            Logger.LogEvent("Get the data on the donated product");

            if (userId == null)
            {
                Logger.LogError("End GetProductsByUserId function and userId is null");

                return null;
            }

            List<TBDonatedProducts> DonatedProductsList = null;

            object listProducts;

            try
            {
                listProducts = SqlQuery.RunCommand(insertProductById, AddDonatedProductsByUserId, SetValues, "SocialActivists_Id", userId, null, null);
            }
            catch (Exception Ex) { Logger.LogException(Ex.Message, Ex); throw; }

            if (listProducts is List<TBDonatedProducts>)
            {
                DonatedProductsList = (List<TBDonatedProducts>)listProducts;

                Logger.LogEvent("End GetProductsByUserId function and returning the list of donated Products");

                return DonatedProductsList;
            }

            Logger.LogError("End GetProductsByUserId function and the invalid value was received");

            return DonatedProductsList;
        }
    }
}
