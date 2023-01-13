import React, { useState } from "react";

import { UseFormMoneyShow } from "./../use-form-money-show/use-form-money-show";
import { UseGetCampaign } from "./../../use-campaigns/use-get-campaign/use-get-campaign";
import { useNavigate, useLocation } from "react-router-dom";

export const UseMoneyTrackingShow = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const { activistId } = location.state;

  const [arrMoneyData, setArrMoneyData] = useState([]);

  if (activistId != null) {
    let getMonetData = {
      type: "MoneyTracking",
      action: "getDataMoney",
      sortValue: activistId,
      setfunc: setArrMoneyData,
    };
    UseGetCampaign(getMonetData);
  }

  return <UseFormMoneyShow arrMoneyData={arrMoneyData} />;
};
