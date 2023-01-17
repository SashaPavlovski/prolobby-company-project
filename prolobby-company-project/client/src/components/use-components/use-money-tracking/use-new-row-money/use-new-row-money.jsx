import React from "react";

//dynamic row in the financial tracking
export const UseNewRowMoney = ({
  NonProfitOrganizationName,
  Campaigns_Name,
  Hashtag,
  Accumulated_money,
  Active,
}) => {
  if (Active)
    return (
      <tr>
        <td>{NonProfitOrganizationName}</td>
        <td>{Campaigns_Name}</td>
        <td>{Hashtag}</td>
        <td>{Accumulated_money}</td>
        <td>is active</td>
      </tr>
    );
  else
    return (
      <tr>
        <td>{NonProfitOrganizationName}</td>
        <td>{Campaigns_Name}</td>
        <td>{Hashtag}</td>
        <td>{Accumulated_money}</td>
        <td>The campaign has been deleted</td>
      </tr>
    );
};
