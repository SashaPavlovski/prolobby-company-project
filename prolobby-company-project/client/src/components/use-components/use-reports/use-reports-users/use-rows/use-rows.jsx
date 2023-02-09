import React from "react";

//Dynamic row of the users report
//Condition certain columns by report
export const UseRowsReportsUsers = ({
  FullName,
  Email,
  Phone_number,
  Date,
  valueOption,
  NonProfitOrganizationName,
  CompanyName,
}) => {
  return (
    <tr>
      {valueOption == 1 ? (
        <td>{NonProfitOrganizationName}</td>
      ) : valueOption == 2 ? (
        <td>{CompanyName}</td>
      ) : (
        <></>
      )}
      <td>{FullName}</td>
      <td>{Email}</td>
      <td>{Phone_number}</td>
      <td>{Date}</td>
    </tr>
  );
};
