import React from "react";

//Display of a product bought by a social activist
export const UseCardActivistProduct = ({ Product_Name, Price, IfSent }) => {
  return (
    <div className="card">
      <div className="card-body">
        <h5 className="card-title">{Product_Name}</h5>
        <p className="card-text">price of the product: {Price} $</p>
        {IfSent}
      </div>
    </div>
  );
};
