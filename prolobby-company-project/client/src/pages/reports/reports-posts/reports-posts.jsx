import React from "react";

import { UseTableReportsPosts } from "../../../components/use-components/use-reports/use-reports-posts/use-table/use-table";
import { UseValusReportsPosts } from "../../../components/use-components/use-reports/use-reports-posts/use-valus/use-valus";
import { UseSelectFormReports } from "./../../../components/use-components/use-reports/use-select-form-reports/use-select-form-reports";
import { UseSelectValueReportsPosts } from "../../../components/use-components/use-reports/use-reports-posts/use-select/use-select";

//Reports Posts page
export const ReportsPosts = () => {
  let { handleValue, arrOfSortingPosts } = UseValusReportsPosts({});
  return (
    <>
      <br />
      <UseSelectFormReports
        handleValue={handleValue}
        UseSelectValueReports={UseSelectValueReportsPosts}
      />
      <br />
      <br />
      <UseTableReportsPosts arrOfSortingPosts={arrOfSortingPosts} />
    </>
  );
};
