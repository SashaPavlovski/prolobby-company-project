import React from "react";

import { UseSelectFormReports } from "./../../../components/use-components/use-reports/use-select-form-reports/use-select-form-reports";
import { UseSelectValueReportsUsers } from "./../../../components/use-components/use-reports/use-reports-users/use-select-reports-users/use-select-value-reports-users/use-select-value-reports-users";
import { UseTableReportsUsers } from "./../../../components/use-components/use-reports/use-reports-users/use-table-reports-users/use-table-reports-users";
import { UseValusReportsUsers } from "./../../../components/use-components/use-reports/use-reports-users/use-valus-reports-users/use-valus-reports-users";

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
