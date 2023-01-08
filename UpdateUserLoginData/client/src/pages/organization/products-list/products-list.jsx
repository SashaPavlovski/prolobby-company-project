import React, { useContext } from "react";

import { UserContext } from "../../../context/userData.context.js";
import { useLocation, useNavigate } from "react-router-dom";

export const ProductsList = () => {
  let { role1 } = useContext(UserContext);
  const navigate = useNavigate();
  const location = useLocation();
  const { Campaigns_Id } = location.state;
  const buy = () => {};
  const donation = () => {};
  return (
    <div className="card">
      <div className="card-body">
        <h5 className="card-title">{}</h5>
        <p className="card-text">price of the product: {}</p>
        {role1 === "SocialActivists" ? (
          <>
            <a className="btn btn-success" onClick={buy}>
              To buy
            </a>
            <a className="btn btn-primary" onClick={donation}>
              For donation
            </a>
          </>
        ) : (
          <></>
        )}
      </div>
    </div>
  );
};
