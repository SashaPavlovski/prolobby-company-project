import React, { useState, useEffect } from "react";

import { CampaignCard } from "../../../components/organization-components/campaign-card/campaign-card";
import { Ifexist } from "../../../components/repeat/user-if-exist";
import { GetDataAsync } from "../../../services/services.get.data.js";

//The campaign view of a specific association
//Sending the association's id to receive its campaigns
export const AllCampaignsByIdOrganization = () => {
  const [arrCampaign, setArrCampaign] = useState([]);
  let { userDataRow } = Ifexist({});

  const func = async () => {
    if (userDataRow) {
      console.log(
        `AllCampaignsByIdOrganization : userDataRow : ${userDataRow.NonProfitOrganization_Id}`
      );
      let campaignsArr = await GetDataAsync(
        "Campaigns",
        "getDataById",
        userDataRow.NonProfitOrganization_Id
      );
      setArrCampaign(campaignsArr);
    }
  };
  useEffect(() => {
    func();
  }, [userDataRow]);

  return (
    <>
      {arrCampaign !== null && arrCampaign.length > 0
        ? arrCampaign.map((c) => {
            return <CampaignCard campaignObject={c} />;
          })
        : "loading"}
    </>
  );
};
