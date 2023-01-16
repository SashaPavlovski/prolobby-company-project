import React from "react";

import "./use-button-send-money.css";
export const UseButtonSendMoney = ({ sendMoney }) => {
  return (
    <button type="button" className="btn btn-outline-info" onClick={sendMoney}>
      send
    </button>
  );
};
