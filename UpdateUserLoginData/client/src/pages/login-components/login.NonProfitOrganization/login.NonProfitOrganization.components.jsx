import React, { useEffect } from "react";

import { UseValueLoginOrganization } from "../../../components/use-components/use-organization/use-value-login-organization/use-value-login-organization";
import { UseUpdateLoginOrganization } from "../../../components/use-components/use-organization/use-update-login-organization/use-update-login-organization";
import { UsePostLoginOrganization } from "../../../components/use-components/use-organization/use-post-login-organization/use-post-login-organization";
import { useNavigate } from "react-router-dom";

export const LoginNonProfitOrganization = () => {
  console.log("hh");
  let navigate = useNavigate();

  let { defaultVariables, UseStatsVariables, UserDataRowV } =
    UseValueLoginOrganization({});
  let {
    userFirstName,
    userOrganizationName,
    userUrl,
    userDecreption,
    userLastName,
    userEmail,
    userPhoneNumber,
  } = defaultVariables;
  let {
    organizationNameV: { organizationName, setOrganizationName },
    urlV: { url, setUrl },
    decreptionV: { decreption, setDecreption },
    firstNameV: { firstName, setFirstName },
    lastNameV: { lastName, setLastName },
    emailV: { email, setEmail },
    phoneNumberV: { phoneNumber, setPhoneNumber },
    pictureV: { picture, setPicture },
  } = UseStatsVariables;
  let { userDataRow } = UserDataRowV;
  if (userDataRow != null) {
    console.log(
      `else : sendingData : ${userDataRow.NonProfitOrganization_Id} `
    );
  }

  useEffect(() => {
    setOrganizationName(userOrganizationName);
    setUrl(userUrl);
    setDecreption(userDecreption);
    setFirstName(userFirstName);
    setLastName(userLastName);
    setEmail(userEmail);
    setPhoneNumber(userPhoneNumber);
  }, [userOrganizationName]);

  console.log(
    firstName,
    lastName,
    organizationName,
    url,
    decreption,
    email,
    phoneNumber,
    picture
  );
  let { handleUserData } = UsePostLoginOrganization({ UseStatsVariables });
  let { handleOrganizationUserData } = UseUpdateLoginOrganization({
    UseStatsVariables,
    userDataRow,
  });
  let sendingData = () => {
    if (userDataRow === null) {
      console.log(`else : sendingData : ${userDataRow} `);
      handleUserData();
      navigate("/");
    } else {
      console.log(
        `else : sendingData : ${userDataRow.NonProfitOrganization_Id} `
      );
      handleOrganizationUserData();
    }
  };
  return (
    <>
      <div className="col-md-4">
        <label for="validationCustom01" className="form-label">
          Non profit organization name
        </label>
        <input
          type="text"
          className="form-control"
          id="validationCustom01"
          defaultValue={userOrganizationName}
          onChange={(e) => setOrganizationName(e.target.value)}
        />
        <div className="valid-feedback">Looks good!</div>
      </div>
      <div className="input-group mb-3">
        <input
          type="text"
          className="form-control"
          placeholder="Recipient's username"
          aria-label="Recipient's username"
          aria-describedby="basic-addon2"
          defaultValue={userUrl}
          onChange={(e) => setUrl(e.target.value)}
        />
        <span className="input-group-text" id="basic-addon2">
          @example.com
        </span>
      </div>
      <div className="form-floating">
        <textarea
          className="form-control"
          placeholder="Leave a comment here"
          id="floatingTextarea2"
          defaultValue={userDecreption}
          onChange={(e) => setDecreption(e.target.value)}
        ></textarea>
        <label for="floatingTextarea2">Decreption</label>
      </div>
      <div className="col-md-4">
        <label for="validationCustom01" className="form-label">
          Representative first name
        </label>
        <input
          type="text"
          className="form-control"
          id="validationCustom01"
          defaultValue={userFirstName}
          onChange={(e) => setFirstName(e.target.value)}
        />
        <div className="valid-feedback">Looks good!</div>
      </div>
      <div className="col-md-4">
        <label for="validationCustom02" className="form-label">
          Representative last name
        </label>
        <input
          type="text"
          className="form-control"
          id="validationCustom02"
          defaultValue={userLastName}
          onChange={(e) => setLastName(e.target.value)}
        />
        <div className="valid-feedback">Looks good!</div>
      </div>
      <div className="col-md-6">
        <label for="inputEmail4" className="form-label">
          Email
        </label>
        <input
          type="email"
          className="form-control"
          id="inputEmail4"
          defaultValue={userEmail}
          onChange={(e) => setEmail(e.target.value)}
        />
      </div>
      <div className="col-md-4">
        <label for="validationCustom01" className="form-label">
          Phone number
        </label>
        <input
          type="tel"
          name="phone"
          className="form-control"
          id="validationCustom01"
          defaultValue={userPhoneNumber}
          onChange={(e) => setPhoneNumber(e.target.value)}
        />
        <div className="valid-feedback">Looks good!</div>
      </div>
      <div>
        <label for="formFileLg" className="form-label">
          Large file input example
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
        Submit form
      </button>
    </>
  );
};
