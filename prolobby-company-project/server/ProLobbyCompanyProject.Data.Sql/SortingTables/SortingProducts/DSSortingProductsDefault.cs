using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model.SortingTables.SortingProducts;
using System;
using System.Collections.Generic;
using Utilities.Logger;

namespace ProLobbyCompanyProject.Data.Sql.SortingTables.SortingProducts
{
    public class DSSortingProductsDefault: BaseDataSql
    {
        SqlQuery SqlQuery;

        //Sort by date, price, shipment status and quantity of products
        public DSSortingProductsDefault(Logger Logger) : base(Logger)
        {
            Logger.LogEvent("Enter into DSSortingProductsDefault constructor and initialize SqlQuery class");

            SqlQuery = new SqlQuery();
        }

        private object AddSortingProducts(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string campaignName)
        {
            Logger.LogEvent("Enter into AddSortingProducts function");

            List<TBSortingProducts> sortingProducts = new List<TBSortingProducts>();

            if (reader.HasRows)
            {
                try
                {
                    Logger.LogEvent("Get the data of the products from the sql");

                    while (reader.Read())
                    {
                        sortingProducts.Add(new TBSortingProducts
                        {
                            Campaigns_Name = reader["Campaigns_Name"].ToString(),
                            NonProfitOrganizationName = reader["NonProfitOrganizationName"].ToString(),
                            Product_Name = reader["Product_Name"].ToString(),
                            CompanyName = reader["CompanyName"].ToString(),
                            Price = double.Parse(reader["Price"].ToString()),
                            Status_Product = reader["Status_Product"].ToString(),
                            Date = DateTime.Parse(reader["Date"].ToString())
                        });
                    }
                }
                catch (Exception EX)
                {

                    throw;
                }

                Logger.LogEvent("End AddSortingProducts function and end get the data of the products");

                return sortingProducts;
            }

            Logger.LogEvent("End AddSortingProducts function and no data was received from the sql");

            return null;
        }

        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            return;
        }

        private string EnteringValueToInsert(string value)
        {
            Logger.LogEvent("Enter into EnteringValueToInsert function");

            if (value != null)
            {
                Logger.LogEvent("Creating the correct query based on a variable");

                string insert = $"select TB1.Product_Name, CONVERT(NVARCHAR(10), TB1.[Date],3) AS [Date],TB1.Price,\r\ncase when TB1.Status_Product = 1 then 'The product is available for purchase'\r\nwhen TB1.Status_Product = 2 then 'Sold but not shipped'\r\nwhen TB1.Status_Product = 3 then 'Bought and shipped'\r\nelse 'The product has been deleted' end as 'Status_Product',\r\nTB2.CompanyName,TB3.Campaigns_Name,TB4.NonProfitOrganizationName\r\nfrom [dbo].[TBDonatedProducts]  TB1 inner join [dbo].[TBBusinessCompanyRepresentatives] TB2\r\non  TB1.BusinessCompany_Id = TB2.BusinessCompany_Id\r\ninner join [dbo].[TBCampaigns] TB3\r\non  TB1.Campaigns_Id = TB3.Campaigns_Id\r\ninner join [dbo].[TBNonProfitOrganizations] TB4\r\non  TB3.NonProfitOrganization_Id = TB4.NonProfitOrganization_Id  \r\nORDER BY {value}";

                return insert;
            }

            Logger.LogError("No variable entered into the function EnteringValueToInsert and unable to create a query");

            return null;
        }

        private List<TBSortingProducts> GetSortingProductsDefault(string insert)
        {
            Logger.LogEvent("Enter into GetSortingProductsDefault function");

            List<TBSortingProducts> sortingProducts = null;

            if (insert != null)
            {
                object listSortingProducts;

                try
                {
                    listSortingProducts = SqlQuery.RunCommand(insert, AddSortingProducts, SetValues, null, null, null, null);
                }
                catch (Exception EX)
                {

                    throw;
                }

                if (listSortingProducts != null)
                {
                    if (listSortingProducts is List<TBSortingProducts>)
                    {
                        sortingProducts = (List<TBSortingProducts>)listSortingProducts;

                        Logger.LogEvent("End GetSortingProductsDefault function and sending the sorted products");

                        return sortingProducts;

                    }
                }
            }

            Logger.LogEvent("End GetSortingProductsDefault function and no sorted products entered");

            return sortingProducts;
        }
        public List<TBSortingProducts> GetByDate()
        {
            Logger.LogEvent("Enter into GetByDate function");

            Logger.LogEvent("Sort the products by date");

            try
            {
                return GetSortingProductsDefault(EnteringValueToInsert("TB1.Date desc"));
            }
            catch (Exception EX)
            {

                throw;
            }
        }
        public List<TBSortingProducts> GetByStatus()
        {
            Logger.LogEvent("Enter into GetByStatus function");

            Logger.LogEvent("Sort the products by status");

            try
            {
                return GetSortingProductsDefault(EnteringValueToInsert("TB1.Status_Product"));
            }
            catch (Exception EX)
            {

                throw;
            }
        }
        public List<TBSortingProducts> GetByPrice()
        {
            Logger.LogEvent("Enter into GetByPrice function");

            Logger.LogEvent("Sort the products by price");

            try
            {
                return GetSortingProductsDefault(EnteringValueToInsert("TB1.Price desc"));
            }
            catch (Exception EX)
            {

                throw;
            }
        }
        public List<TBSortingProducts> GetByCampaignsName()
        {
            Logger.LogEvent("Enter into GetByCampaignsName function");

            Logger.LogEvent("Sort the products by CampaignsName");

            try
            {
                return GetSortingProductsDefault(EnteringValueToInsert("TB3.Campaigns_Name"));
            }
            catch (Exception EX)
            {

                throw;
            }
        }
    }
}
