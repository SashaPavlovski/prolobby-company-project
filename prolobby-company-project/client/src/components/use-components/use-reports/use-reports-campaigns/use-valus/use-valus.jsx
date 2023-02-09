import { useState, useEffect } from "react";

import { GetDataAsync } from "../../../../../services/services";

//The functions related to the reports of the campaigns
//Sending the value of the column to cs
export const UseValusReportsCampaigns = () => {
  const [valueOption, setValueOption] = useState("");
  const [arrOfSortingCampaigns, setArrOfSortingCampaigns] = useState("");

  const handleValue = () => {
    setValueOption(document.getElementById("CampaignsSelect").value);
  };

  let getSortingCampaigns = async () => {
    if (valueOption && valueOption != "" && valueOption != 0) {
      let campaignsArr = await GetDataAsync(
        "Reports",
        "byCampaign",
        valueOption
      );
      setArrOfSortingCampaigns(campaignsArr);
    }
  };
  useEffect(() => {
    getSortingCampaigns();
  }, [valueOption]);
  return { valueOption, handleValue, arrOfSortingCampaigns };
};
