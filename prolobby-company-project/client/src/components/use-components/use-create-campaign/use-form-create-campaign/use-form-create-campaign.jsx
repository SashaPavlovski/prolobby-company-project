import React from "react";

//The campaign creation view
export const UseFormCreateCampaign = ({
  ifExist,
  setCampaigns_Name,
  setDescreption,
  setHashtag,
  Campaigns_Name,
  Descreption,
  Hashtag,
  sendingData,
}) => {
  return (
    <div className="createCampaign">
      <div className="col-md-4">
        <div className={ifExist}>
          The name of the campaign or the hashtag already exists
        </div>
        <label for="validationCustom01" className="form-label">
          Name of campaign
        </label>
        <input
          type="text"
          className="form-control"
          id="validationCustom01"
          onChange={(e) => setCampaigns_Name(e.target.value)}
        />
        <div className="valid-feedback">Looks good!</div>
      </div>
      <div className="form-floating">
        <textarea
          className="form-control"
          placeholder="Leave a comment here"
          id="floatingTextarea2"
          onChange={(e) => setDescreption(e.target.value)}
        ></textarea>
        <label for="floatingTextarea2">Decreption of the campaign </label>
      </div>
      <div className="input-group mb-3">
        <input
          type="text"
          className="form-control"
          id="input3"
          placeholder="Recipient's username"
          aria-label="Recipient's username"
          aria-describedby="basic-addon2"
          onChange={(e) => setHashtag(e.target.value)}
        />
        <span className="input-group-text" id="basic-addon2">
          #hashtag
        </span>
      </div>
      {Campaigns_Name !== "" && Descreption !== "" && Hashtag !== "" ? (
        <button className="btn btn-primary" onClick={sendingData}>
          Save
        </button>
      ) : (
        <></>
      )}
    </div>
  );
};
