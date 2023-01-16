import React, { useState } from "react";

import { CampaignCard } from "../../../components/organization-components/campaign-card/campaign-card";
import { UseGetCampaign } from "../../../components/use-components/use-campaigns/use-get-campaign/use-get-campaign";

export const HomeAllCampaigns = () => {
  const [arrCampaign, setArrCampaign] = useState([]);
  let getCampaign = {
    type: "Campaigns",
    action: "getData",
    sortValue: null,
    setfunc: setArrCampaign,
  };
  UseGetCampaign(getCampaign);

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
