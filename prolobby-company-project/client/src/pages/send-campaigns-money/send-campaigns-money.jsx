import React from "react";

import { UseButtonSendMoney } from "./../../components/use-components/use-send-campaigns-money/use-button-send-money/use-button-send-money";
import { UseValueSendMoney } from "./../../components/use-components/use-send-campaigns-money/use-value-send-money/use-value-send-money";

export const SendCampaignsMoney = () => {
  let { sendMoney } = UseValueSendMoney({});
  return (
    <>
      <h2>Click to scan the comments</h2>
      <UseButtonSendMoney sendMoney={sendMoney} />
    </>
  );
};
