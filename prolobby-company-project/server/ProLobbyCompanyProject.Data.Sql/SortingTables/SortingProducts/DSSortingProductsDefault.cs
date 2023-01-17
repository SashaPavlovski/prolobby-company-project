using ProLobbyCompanyProject.Dal;
using ProLobbyCompanyProject.Model.SortingTables.SortingPosts;
using ProLobbyCompanyProject.Model.SortingTables.SortingProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLobbyCompanyProject.Data.Sql.SortingTables.SortingProducts
{
    public class DSSortingProductsDefault
    {
        //Sort by date, price, shipment status and quantity of products
        public DSSortingProductsDefault() { }
        public object AddSortingProducts(System.Data.SqlClient.SqlDataReader reader, System.Data.SqlClient.SqlCommand command, string campaignName)
        {
            List<TBSortingProducts> sortingProducts = new List<TBSortingProducts>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    sortingProducts.Add(new TBSortingProducts() { Campaigns_Name = reader["Campaigns_Name"].ToString(), NonProfitOrganizationName = reader["NonProfitOrganizationName"].ToString(),Product_Name = reader["Product_Name"].ToString(),CompanyName = reader["CompanyName"].ToString(),Price = double.Parse(reader["Price"].ToString()),Status_Product = reader["Status_Product"].ToString(),Date = DateTime.Parse(reader["Date"].ToString()) });

                }
                return sortingProducts;
            }
            return null;
        }



        public void SetValues(System.Data.SqlClient.SqlCommand command, string key, string value, string key2, string value2)
        {
            return;
        }


        public string EnteringValueToInsert(string value)
        {

            string insert = $"select TB1.Product_Name, CONVERT(NVARCHAR(10), TB1.[Date],3) AS [Date],TB1.Price,\r\ncase when TB1.Status_Product = 1 then 'The product is available for purchase'\r\nwhen TB1.Status_Product = 2 then 'Sold but not shipped'\r\nwhen TB1.Status_Product = 3 then 'Bought and shipped'\r\nelse 'The product has been deleted' end as 'Status_Product',\r\nTB2.CompanyName,TB3.Campaigns_Name,TB4.NonProfitOrganizationName\r\nfrom [dbo].[TBDonatedProducts]  TB1 inner join [dbo].[TBBusinessCompanyRepresentatives] TB2\r\non  TB1.BusinessCompany_Id = TB2.BusinessCompany_Id\r\ninner join [dbo].[TBCampaigns] TB3\r\non  TB1.Campaigns_Id = TB3.Campaigns_Id\r\ninner join [dbo].[TBNonProfitOrganizations] TB4\r\non  TB3.NonProfitOrganization_Id = TB4.NonProfitOrganization_Id  \r\nORDER BY  {value}";
            return insert;
        }

        public List<TBSortingProducts> GetSortingProductsDefault(string insert)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            List<TBSortingProducts> sortingProducts = null;

            object listSortingProducts = sqlQuery1.RunCommand(insert, AddSortingProducts, SetValues, null, null, null, null);
            if (listSortingProducts != null)
            {

                if (listSortingProducts is List<TBSortingProducts>)
                {
                    sortingProducts = (List<TBSortingProducts>)listSortingProducts;
                }
            }
            return sortingProducts;
        }
        public List<TBSortingProducts> GetByDate()
        {
            return GetSortingProductsDefault(EnteringValueToInsert("TB1.Date desc"));
        }
        public List<TBSortingProducts> GetByStatus()
        {
            return GetSortingProductsDefault(EnteringValueToInsert("TB1.Status_Product"));
        }
        public List<TBSortingProducts> GetByPrice()
        {
            return GetSortingProductsDefault(EnteringValueToInsert("TB1.Price desc"));
        }
        public List<TBSortingProducts> GetByProducts()
        {
            return GetSortingProductsDefault(EnteringValueToInsert("TB3.Campaigns_Name"));
        }
    }
}
