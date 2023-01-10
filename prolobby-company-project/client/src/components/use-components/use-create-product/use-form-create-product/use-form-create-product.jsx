import React from "react";

export const UseFormCreateProduct = ({
  setProduct_Name,
  setPrice,
  setPicture,
  sendingData,
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
      <div className="input-group">
        <label for="validationCustom01" className="form-label">
          What is the price
        </label>
        <input
          type="text"
          className="form-control"
          aria-label="Dollar amount (with dot and two decimal places)"
          onChange={(e) => setPrice(e.target.value)}
        />
        <span className="input-group-text">$</span>
        <span className="input-group-text">0.00</span>
      </div>
      <div>
        <label for="formFileLg" className="form-label">
          Picture of the donation
        </label>
        <input
          className="form-control form-control-lg"
          id="formFileLg"
          type="file"
          accept=".jpg, .png"
          onChange={(e) => setPicture(e.target.files[0])}
        />
      </div>
      <button
        className="btn btn-primary"
        //type="submit"
        onClick={sendingData}
      >
        Save
      </button>
    </div>
  );
};
