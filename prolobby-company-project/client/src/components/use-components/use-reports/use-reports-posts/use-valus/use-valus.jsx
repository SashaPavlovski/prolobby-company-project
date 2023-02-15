import { useState, useEffect } from "react";

import { GetDataAsync } from "../../../../../services/services.get.data.js";

//The functions of the options of Posts
//Sending the value of the option to the cs
export const UseValusReportsPosts = () => {
  const [valueOption, setValueOption] = useState("");
  const [arrOfSortingPosts, setArrOfSortingPosts] = useState("");

  const handleValue = () => {
    setValueOption(document.getElementById("CampaignsSelect").value);
  };

  let getSortingPosts = async () => {
    if (valueOption && valueOption != "" && valueOption != 0) {
      let campaignsArr = await GetDataAsync("Reports", "byPosts", valueOption);
      setArrOfSortingPosts(campaignsArr);
    }
  };
  useEffect(() => {
    getSortingPosts();
  }, [valueOption]);

  return { valueOption, handleValue, arrOfSortingPosts };
};
