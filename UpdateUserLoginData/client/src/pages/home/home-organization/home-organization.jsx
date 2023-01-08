import React, { useEffect, useState } from "react";

import { CampaignCard } from "./../../../components/organization-components/campaign-card/campaign-card";
import { GetAllDataAsync } from "../../../services/services.js";

export const HomeOrganization = () => {
  const [arrCampaign, setArrCampaign] = useState([]);

  let getCampaigns = async () => {
    let campaignsArr = await GetAllDataAsync("Campaigns", "getData");
    // let arrPro = Object.values(campaignsArr);
    setArrCampaign(campaignsArr);
  };

  useEffect(() => {
    getCampaigns();
  }, []);

  return (
    <>
      {arrCampaign.length > 0
        ? arrCampaign.map((c) => {
            return (
              <>
                <CampaignCard campaignObject={c} />
              </>
            );
          })
        : "loading"}
    </>
  );
};
