import React from "react";

import "./use-button-send-money.css";

//Send button to scan Twitter by previous day
export const UseButtonSendMoney = ({ sendMoney }) => {
  return (
    <button type="button" className="btn btn-outline-info" onClick={sendMoney}>
      send
    </button>
  );
};
