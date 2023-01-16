import React from "react";

import { UseTableReportsPosts } from "./../../../components/use-components/use-reports/use-reports-posts/use-table-reports-posts/use-table-reports-posts";
import { UseValusReportsPosts } from "./../../../components/use-components/use-reports/use-reports-posts/use-valus-reports-posts/use-valus-reports-posts";
import { UseSelectFormReports } from "./../../../components/use-components/use-reports/use-select-form-reports/use-select-form-reports";
import { UseSelectValueReportsPosts } from "./../../../components/use-components/use-reports/use-reports-posts/use-select-reports-posts/use-select-value-reports-posts/use-select-value-reports-posts";

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
