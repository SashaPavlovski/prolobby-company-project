import React from "react";

import { UseSelectFormReports } from "../../../components/use-components/use-reports/use-select-form-reports/use-select-form-reports";
import { UseValusReportsCampaigns } from "../../../components/use-components/use-reports/use-reports-campaigns/use-valus/use-valus";
import { UseTableReportsCampaigns } from "../../../components/use-components/use-reports/use-reports-campaigns/use-table/use-table";
import { UseSelectValueReports } from "./../../../components/use-components/use-reports/use-reports-campaigns/use-select/use-select";

//Reports Campaigns page
export const ReportsCampaigns = () => {
  let { valueOption, handleValue, arrOfSortingCampaigns } =
    UseValusReportsCampaigns({});
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
