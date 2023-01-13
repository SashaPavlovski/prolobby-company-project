import React, { useContext } from "react";
import { UserContext } from "../../../../context/userData.context.js";

export const UseCardProduct = ({
  Product_Name,
  Price,
  buy,
  donation,
  backToCampaign,
  DonatedProducts_Id,
}) => {
  let { role1 } = useContext(UserContext);
  console.log(Product_Name, Price);

  return (
    <div className="card">
      <div className="card-body">
        <h5 className="card-title">{Product_Name}</h5>
        <p className="card-text">price of the product: {Price} $</p>
        {role1[0].name === "SocialActivists" ? (
          <>
            <a
              className="btn btn-success"
              onClick={() => buy(DonatedProducts_Id)}
            >
              To buy
            </a>
            <a
              className="btn btn-primary"
              onClick={() => donation(DonatedProducts_Id)}
            >
              For donation
            </a>
          </>
        ) : (
          <></>
        )}
        <a className="btn btn-primary" onClick={backToCampaign}>
          Back to campaign
        </a>
      </div>
    </div>
  );
};
