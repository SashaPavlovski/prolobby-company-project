import React from "react";
import {
  UseRowsReportsCampaignsAllColumns,
  UseRowsReportsCampaignsByActivists,
  UseRowsReportsCampaignsByProducts,
} from "../use-rows/use-rows";

//The display of the Campaigns report table
//according to the choice of the options
export const UseTableReportsCampaigns = ({
  valueOption,
  arrOfSortingCampaigns,
}) => {
  return (
    <div className="table-responsive">
      <table className="table align-middle">
        {valueOption == 2 || valueOption == 4 || valueOption == 5 ? (
          <>
            <thead>
              <tr>
                <th>Organization Name</th>
                <th>Campaigns Name</th>
                <th>The donated money</th>
                <th>Campaign creation date</th>
                <th>activity</th>
              </tr>
            </thead>
            <tbody>
              {arrOfSortingCampaigns && arrOfSortingCampaigns.length > 0 ? (
                arrOfSortingCampaigns.map((c) => (
                  <UseRowsReportsCampaignsAllColumns
                    NonProfitOrganizationName={c.NonProfitOrganizationName}
                    Campaigns_Name={c.Campaigns_Name}
                    MoneyDonations={c.MoneyDonations}
                    Date={c.Date}
                    Active={c.Active}
                  />
                ))
              ) : (
                <></>
              )}
            </tbody>
          </>
        ) : valueOption == 1 ? (
          <>
            <thead>
              <tr>
                <th>Campaigns Name</th>
                <th> Amount Of Activists</th>
              </tr>
            </thead>
            <tbody>
              {arrOfSortingCampaigns && arrOfSortingCampaigns.length > 0 ? (
                arrOfSortingCampaigns.map((c) => (
                  <UseRowsReportsCampaignsByActivists
                    Campaigns_Name={c.Campaigns_Name}
                    ActivistAmount={c.ActivistAmount}
                  />
                ))
              ) : (
                <></>
              )}
            </tbody>
          </>
        ) : valueOption == 3 ? (
          <>
            <thead>
              <tr>
                <th>Campaigns Name</th>
                <th>The donated products</th>
              </tr>
            </thead>
            <tbody>
              {arrOfSortingCampaigns && arrOfSortingCampaigns.length > 0 ? (
                arrOfSortingCampaigns.map((c) => (
                  <UseRowsReportsCampaignsByProducts
                    Campaigns_Name={c.Campaigns_Name}
                    ProductAmount={c.ProductAmount}
                  />
                ))
              ) : (
                <></>
              )}
            </tbody>
          </>
        ) : (
          <></>
        )}
      </table>
    </div>
  );
};
