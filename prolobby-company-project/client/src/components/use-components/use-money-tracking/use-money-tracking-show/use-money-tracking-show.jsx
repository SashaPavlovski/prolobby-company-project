import React, { useState } from "react";

import { UseFormMoneyShow } from "./../use-form-money-show/use-form-money-show";
import { UseGetCampaign } from "./../../use-campaigns/use-get-campaign/use-get-campaign";
import { useNavigate, useLocation } from "react-router-dom";

//The functions of the table of funds
//Sending an ID of a social activist to cs
//Receiving the money tracking table data
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
