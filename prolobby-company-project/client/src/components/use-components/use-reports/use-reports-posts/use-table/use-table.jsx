import React from "react";

import { UseRowsReportsPosts } from "../use-rows/use-row";

//The view of the report table of the posts
export const UseTableReportsPosts = ({ valueOption, arrOfSortingPosts }) => {
  return (
    <div className="table-responsive">
      <table className="table align-middle">
        <thead>
          <tr>
            {valueOption !== null && valueOption == 2 ? (
              <>
                <th>User Twitter</th>
                <th>Amount Publications</th>
              </>
            ) : (
              <>
                <th>Organization Name</th>
                <th>Campaigns Name</th>
                <th>User Twitter</th>
                <th>Activity</th>
                <th>Date Posted Tweets</th>
                <th>Tweet</th>
                <th>Amount of shares</th>
              </>
            )}
          </tr>
        </thead>
        <tbody>
          {arrOfSortingPosts && arrOfSortingPosts.length > 0 ? (
            arrOfSortingPosts.map((p) => (
              <UseRowsReportsPosts
                Twitter_user={p.Twitter_user}
                Date={p.Date}
                Amount_publications={p.Amount_publications}
                Campaigns_Name={p.Campaigns_Name}
                NonProfitOrganizationName={p.NonProfitOrganizationName}
                Active={p.Active}
                Tweets_Message={p.Tweets_Message}
                Retweets_Count={p.Retweets_Count}
                valueOption={valueOption}
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
