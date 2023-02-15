import { useEffect } from "react";

import { GetDataAsync } from "../../../../services/services.get.data.js";

//Generic function to send a value
//at url
//Sending to cs
export const UseGetCampaign = ({ type, action, sortValue, setfunc }) => {
  let getCampaigns = async () => {
    let campaignsArr = await GetDataAsync(type, action, sortValue);
    setfunc(campaignsArr);
  };

  useEffect(() => {
    getCampaigns();
  }, []);
  return;
};
