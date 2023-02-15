import { useState, useEffect } from "react";

import { GetDataAsync } from "../../../../../services/services.get.data.js";

//The functions of the products report table
//Sending value of the option to cs
export const UseValusReportsProducts = () => {
  const [valueOption, setValueOption] = useState("");
  const [arrOfSortingProducts, setArrOfSortingProducts] = useState("");

  const handleValue = () => {
    setValueOption(document.getElementById("CampaignsSelect").value);
  };

  let getSortingProducts = async () => {
    if (valueOption && valueOption != "" && valueOption != 0) {
      let campaignsArr = await GetDataAsync(
        "Reports",
        "byProducts",
        valueOption
      );
      setArrOfSortingProducts(campaignsArr);
    }
  };
  useEffect(() => {
    getSortingProducts();
  }, [valueOption]);

  return { valueOption, handleValue, arrOfSortingProducts };
};
