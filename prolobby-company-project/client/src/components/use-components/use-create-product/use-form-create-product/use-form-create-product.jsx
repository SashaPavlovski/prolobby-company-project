import React from "react";

//The product creation view
//The button is displayed after all columns are filled
export const UseFormCreateProduct = ({
  setProduct_Name,
  setPrice,
  setCount,
  sendingData,
  product_Name,
  price,
  count,
}) => {
  return (
    <div className="createCampaign">
      <div className="col-md-4">
        <label for="validationCustom01" className="form-label">
          What would you like to donate
        </label>
        <input
          type="text"
          className="form-control"
          id="validationCustom01"
          onChange={(e) => setProduct_Name(e.target.value)}
        />
        <div className="valid-feedback">Looks good!</div>
      </div>
      <div>
        <label for="validationCustom01" className="form-label">
          What is the price
        </label>
        <div className="input-group">
          <input
            type="number"
            className="form-control"
            id="validationCustom01"
            onChange={(e) => setPrice(e.target.value)}
          />
          <span className="input-group-text">$</span>
          <span className="input-group-text">0.00</span>
        </div>
      </div>
      <div className="col-md-4">
        <label for="validationCustom01" className="form-label">
          Amount :
        </label>
        <input
          type="number"
          className="form-control"
          id="validationCustom01"
          onChange={(e) => setCount(e.target.value)}
        />
        <div className="valid-feedback">Looks good!</div>
      </div>
      {product_Name !== "" && price !== "" && count !== "" ? (
        <button className="btn btn-primary" onClick={sendingData}>
          Save
        </button>
      ) : (
        <></>
      )}
    </div>
  );
};
