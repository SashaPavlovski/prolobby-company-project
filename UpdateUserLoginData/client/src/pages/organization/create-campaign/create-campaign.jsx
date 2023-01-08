import React, { useState } from "react";

import { UseValueCreateCampaign } from "../../../components/use-components/use-create-campaign/use-value-create-campaign/use-value-create-campaign";
import { UsePostCreateCampaign } from "../../../components/use-components/use-create-campaign/use-post-create-campaign/use-post-create-campaign";

import "./create-campaign.css";

export const CreateCampaign = () => {
  let { UseStatsVariables } = UseValueCreateCampaign({});
  let {
    Campaigns_NameV: { Campaigns_Name, setCampaigns_Name },
    DescreptionV: { setDescreption },
    HashtagV: { setHashtag },
    TstV: { tst, setTst },
  } = UseStatsVariables;

  const [ifExist, setIfExist] = useState("showIfNameExist");

  let { sendData } = UsePostCreateCampaign({
    UseStatsVariables,
  });

  const sendingData = async () => {
    setTst(Campaigns_Name);
    let req = await sendData();
    if (req === null) {
      console.log("if false");
      setIfExist("showIfNameExist");
    } else {
      setIfExist("showIfNotExist");
    }
    console.log(`req : ${req}`);
  };

  return (
    <div className="createCampaign">
      <div className="col-md-4">
        <div className={ifExist}>show</div>
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
          placeholder="Recipient's username"
          aria-label="Recipient's username"
          aria-describedby="basic-addon2"
          onChange={(e) => setHashtag(e.target.value)}
        />
        <span className="input-group-text" id="basic-addon2">
          #hashtag
        </span>
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
