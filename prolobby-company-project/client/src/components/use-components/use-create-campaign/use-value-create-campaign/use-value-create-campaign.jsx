import { useState } from "react";

//The useState functions of creating the campaign
export const UseValueCreateCampaign = () => {
  const [Campaigns_Name, setCampaigns_Name] = useState("");
  const [Descreption, setDescreption] = useState("");
  const [Hashtag, setHashtag] = useState("");
  const [ifExist, setIfExist] = useState("showIfNotExist");

  return {
    UseStatsVariables: {
      Campaigns_NameV: { Campaigns_Name, setCampaigns_Name },
      DescreptionV: { Descreption, setDescreption },
      HashtagV: { Hashtag, setHashtag },
      IfExistV: { ifExist, setIfExist },
    },
  };
};
