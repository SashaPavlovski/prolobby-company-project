import React from "react";

//A dynamic row of the reports of posts
export const UseRowsReportsPosts = ({
  Twitter_user,
  Date,
  Amount_publications,
  Campaigns_Name,
  NonProfitOrganizationName,
  Active,
}) => {
  return (
    <tr>
      <td>{NonProfitOrganizationName}</td>
      <td>{Campaigns_Name}</td>
      <td>{Twitter_user}</td>
      <td>{Amount_publications}</td>
      <td>{Active}</td>
      <td>{Date}</td>
    </tr>
  );
};
