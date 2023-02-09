import React from "react";

//Displaying all columns of the campaign
export const UseRowsReportsCampaignsAllColumns = ({
  NonProfitOrganizationName,
  Campaigns_Name,
  MoneyDonations,
  Date,
  Active,
}) => {
  return (
    <tr>
      <td>{NonProfitOrganizationName}</td>
      <td>{Campaigns_Name}</td>
      <td>{MoneyDonations}</td>
      <td>{Date}</td>
      <td>{Active}</td>
    </tr>
  );
};

//Displaying columns related to the amount of actives users
export const UseRowsReportsCampaignsByActivists = ({
  Campaigns_Name,
  ActivistAmount,
}) => {
  return (
    <tr>
      <td>{Campaigns_Name}</td>
      <td>{ActivistAmount}</td>
    </tr>
  );
};

//Showing columns related to the amount of products of each campaign
export const UseRowsReportsCampaignsByProducts = ({
  Campaigns_Name,
  ProductAmount,
}) => {
  return (
    <tr>
      <td>{Campaigns_Name}</td>
      <td>{ProductAmount}</td>
    </tr>
  );
};
