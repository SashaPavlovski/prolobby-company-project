import React from "react";

export const UseCardActivistProduct = ({ Product_Name, Price, IfSent }) => {
  return (
    <div className="card">
      <div className="card-body">
        <h5 className="card-title">{Product_Name}</h5>
        <p className="card-text">price of the product: {Price} $</p>
        <div>{IfSent}</div>
      </div>
    </div>
  );
};
