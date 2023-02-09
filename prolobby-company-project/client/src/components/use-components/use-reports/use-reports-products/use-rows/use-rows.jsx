import React from "react";

//A dynamic row of the product's reports
export const UseRowsReportsProducts = ({
  NonProfitOrganizationName,
  Campaigns_Name,
  CompanyName,
  Product_Name,
  Status_Product,
  Price,
  Date,
}) => {
  return (
    <tr>
      <td>{NonProfitOrganizationName}</td>
      <td>{Campaigns_Name}</td>
      <td>{CompanyName}</td>
      <td>{Product_Name}</td>
      <td>{Status_Product}</td>
      <td>{Price}</td>
      <td>{Date}</td>
    </tr>
  );
};
