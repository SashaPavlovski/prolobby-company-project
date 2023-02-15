import { useState, useEffect } from "react";

import { GetDataAsync } from "../../../../../services/services.get.data.js";

//The functions required for user reports
//Receiving the reports from cs
//using the option value
export const UseValusReportsUsers = () => {
  const [valueOption, setValueOption] = useState("");
  const [arrOfSortingUsers, setArrOfSortingUsers] = useState("");

  const handleValue = () => {
    setValueOption(document.getElementById("CampaignsSelect").value);
  };

  let getSortingUsers = async () => {
    if (valueOption && valueOption != "" && valueOption != 0) {
      let campaignsArr = await GetDataAsync("Reports", "byUsers", valueOption);
      setArrOfSortingUsers(campaignsArr);
    }
  };
  useEffect(() => {
    getSortingUsers();
  }, [valueOption]);

  return { valueOption, handleValue, arrOfSortingUsers };
};
