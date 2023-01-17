import React from "react";

import { UseSelectFormReports } from "./../../../components/use-components/use-reports/use-select-form-reports/use-select-form-reports";
import { UseValusReportsProducts } from "../../../components/use-components/use-reports/use-reports-products/use-valus/use-valus";
import { UseTableReportsProducts } from "../../../components/use-components/use-reports/use-reports-products/use-table/use-table";
import { UseSelectValueReportsProducts } from "../../../components/use-components/use-reports/use-reports-products/use-select/use-select";

//Reports Products page
export const ReportsProducts = () => {
  let { handleValue, arrOfSortingProducts } = UseValusReportsProducts({});
  return (
    <>
      <br />
      <UseSelectFormReports
        handleValue={handleValue}
        UseSelectValueReports={UseSelectValueReportsProducts}
      />
      <br />
      <br />
      <UseTableReportsProducts arrOfSortingProducts={arrOfSortingProducts} />
    </>
  );
};
