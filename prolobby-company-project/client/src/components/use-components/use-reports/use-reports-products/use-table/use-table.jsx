import React from "react";

import { UseRowsReportsProducts } from "../use-rows/use-rows";

//Displaying the data of the product reports in a table
export const UseTableReportsProducts = ({ arrOfSortingProducts }) => {
  return (
    <div className="table-responsive">
      <table className="table align-middle">
        <thead>
          <tr>
            <th>Organization Name</th>
            <th>Campaigns Name</th>
            <th>Company Name</th>
            <th>Product Name</th>
            <th>Product status</th>
            <th>Price of the product</th>
            <th>Date of the donation</th>
          </tr>
        </thead>
        <tbody>
          {arrOfSortingProducts && arrOfSortingProducts.length > 0 ? (
            arrOfSortingProducts.map((p) => (
              <UseRowsReportsProducts
                NonProfitOrganizationName={p.NonProfitOrganizationName}
                Campaigns_Name={p.Campaigns_Name}
                CompanyName={p.CompanyName}
                Product_Name={p.Product_Name}
                Status_Product={p.Status_Product}
                Price={p.Price}
                Date={p.Date}
              />
            ))
          ) : (
            <></>
          )}
        </tbody>
      </table>
    </div>
  );
};
