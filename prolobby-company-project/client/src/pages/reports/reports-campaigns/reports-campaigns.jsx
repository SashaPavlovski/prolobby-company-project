import React from "react";

import { UseTableReportsCampaigns } from "./../../../components/use-components/use-reports/use-reports-campaigns/use-table-reports-campaigns/use-table-reports-campaigns";
import { UseSelectFormReports } from "../../../components/use-components/use-reports/use-select-form-reports/use-select-form-reports";
import { UseValusReportsCampaigns } from "./../../../components/use-components/use-reports/use-reports-campaigns/use-valus-reports-campaigns/use-valus-reports-campaigns";
import { UseSelectValueReports } from "./../../../components/use-components/use-reports/use-reports-campaigns/use-select/use-select";

export const ReportsCampaigns = () => {
  let { valueOption, handleValue, arrOfSortingCampaigns } =
    UseValusReportsCampaigns({});
  console.log("==============================");
  console.log(valueOption);
  console.log("==============================");
  return (
    <>
      <br />
      <UseSelectFormReports
        handleValue={handleValue}
        UseSelectValueReports={UseSelectValueReports}
      />
      <br />
      <br />
      <UseTableReportsCampaigns
        valueOption={valueOption}
        arrOfSortingCampaigns={arrOfSortingCampaigns}
      />
    </>
  );
};
