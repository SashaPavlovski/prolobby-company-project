import React, { useEffect } from "react";

import { addUserDataAsync } from "./../../../services/services";

export const JoinCampaign = ({ Campaigns_Id, userDataRow }) => {
  console.log("enter JoinCampaign");
  console.log(`Campaigns_Id : ${Campaigns_Id}`);

  let userId = userDataRow.SocialActivists_Id;
  console.log(`userId : ${userId}`);
  const addToMoneyTracking = async () => {
    console.log(`addToMoneyTracking : enter`);

    await addUserDataAsync("MoneyTracking", "addTrack", {
      SocialActivists_Id: userId,
      Campaigns_Id: Campaigns_Id,
    });
  };

  console.log(`JoinCampaign : enter`);
  return { addToMoneyTracking };
};
