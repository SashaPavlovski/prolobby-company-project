import React from "react";

import { UseSelectFormReports } from "./../../../components/use-components/use-reports/use-select-form-reports/use-select-form-reports";
import { UseValusReportsProducts } from "./../../../components/use-components/use-reports/use-reports-products/use-valus-reports-products/use-valus-reports-products";
import { UseTableReportsProducts } from "./../../../components/use-components/use-reports/use-reports-products/use-table-reports-products/use-table-reports-products";
import { UseSelectValueReportsProducts } from "../../../components/use-components/use-reports/use-reports-products/use-select-reports-products/use-select-value-reports-products/use-select-value-reports-products";

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
