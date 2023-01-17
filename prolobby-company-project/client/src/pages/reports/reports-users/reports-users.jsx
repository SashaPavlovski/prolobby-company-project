import React from "react";

import { UseSelectFormReports } from "./../../../components/use-components/use-reports/use-select-form-reports/use-select-form-reports";
import { UseSelectValueReportsUsers } from "../../../components/use-components/use-reports/use-reports-users/use-select/use-select";
import { UseTableReportsUsers } from "../../../components/use-components/use-reports/use-reports-users/use-table/use-table";
import { UseValusReportsUsers } from "../../../components/use-components/use-reports/use-reports-users/use-valus/use-valus";

//Reports Users page
export const ReportsUsers = () => {
  let { valueOption, handleValue, arrOfSortingUsers } = UseValusReportsUsers(
    {}
  );
  return (
    <>
      <br />
      <UseSelectFormReports
        handleValue={handleValue}
        UseSelectValueReports={UseSelectValueReportsUsers}
      />
      <br />
      <br />
      <UseTableReportsUsers
        arrOfSortingUsers={arrOfSortingUsers}
        valueOption={valueOption}
      />
    </>
  );
};
