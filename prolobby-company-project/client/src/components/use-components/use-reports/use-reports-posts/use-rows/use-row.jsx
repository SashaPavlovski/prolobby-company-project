import React from "react";

//A dynamic row of the reports of posts
export const UseRowsReportsPosts = ({
  Twitter_user,
  Date,
  Amount_publications,
  Campaigns_Name,
  NonProfitOrganizationName,
  Active,
  Tweets_Message,
  Retweets_Count,
  valueOption,
}) => {
  return (
    <tr>
      {valueOption != null && valueOption == 2 ? (
        <>
          <td>{Twitter_user}</td>
          <td>{Amount_publications}</td>
        </>
      ) : (
        <>
          <td>{NonProfitOrganizationName}</td>
          <td>{Campaigns_Name}</td>
          <td>{Twitter_user}</td>
          <td>{Active}</td>
          <td>{Date}</td>
          <td>{Tweets_Message}</td>
          <td>{Retweets_Count}</td>
        </>
      )}
    </tr>
  );
};
