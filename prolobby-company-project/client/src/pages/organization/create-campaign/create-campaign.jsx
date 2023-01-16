import React, { useContext } from "react";

import { UseValueCreateCampaign } from "../../../components/use-components/use-create-campaign/use-value-create-campaign/use-value-create-campaign";
import { UsePostCreateCampaign } from "../../../components/use-components/use-create-campaign/use-post-create-campaign/use-post-create-campaign";
import { UserContext } from "../../../context/userData.context.js";

import "./create-campaign.css";
import { UseFormCreateCampaign } from "../../../components/use-components/use-create-campaign/use-form-create-campaign/use-form-create-campaign";

export const CreateCampaign = () => {
  const { userId } = useContext(UserContext);
  let { UseStatsVariables } = UseValueCreateCampaign({});
  let {
    Campaigns_NameV: { Campaigns_Name, setCampaigns_Name },
    DescreptionV: { Descreption, setDescreption },
    HashtagV: { Hashtag, setHashtag },
    IfExistV: { ifExist },
  } = UseStatsVariables;

  const sendingData = () => {
    let { sendData } = UsePostCreateCampaign({
      UseStatsVariables,
      userId,
    });
    sendData();
  };

  return (
    <UseFormCreateCampaign
      ifExist={ifExist}
      setCampaigns_Name={setCampaigns_Name}
      setDescreption={setDescreption}
      setHashtag={setHashtag}
      Campaigns_Name={Campaigns_Name}
      Descreption={Descreption}
      Hashtag={Hashtag}
      sendingData={sendingData}
    />
  );
};
