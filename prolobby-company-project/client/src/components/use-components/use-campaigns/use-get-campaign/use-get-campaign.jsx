import React, { useEffect } from "react";

import { GetDataAsync } from "../../../../services/services.js";

export const UseGetCampaign = ({ type, action, sortValue, setfunc }) => {
  console.log("enter UseGetCampaign");
  console.log(type, action, sortValue);
  let getCampaigns = async () => {
    let campaignsArr = await GetDataAsync(type, action, sortValue);
    //let arrPro = Object.values(campaignsArr);

    setfunc(campaignsArr);
  };

  useEffect(() => {
    getCampaigns();
  }, []);
  return;
};
