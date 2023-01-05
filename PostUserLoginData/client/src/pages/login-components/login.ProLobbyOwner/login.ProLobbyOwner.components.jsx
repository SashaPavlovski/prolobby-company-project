import React from "react";

import { useNavigate } from "react-router-dom";
import { UseValueLoginOwner } from "./../../../components/use-components/use-owner/use-value-login-owner/use-value-login-owner";
import { UsePostLoginOwner } from "./../../../components/use-components/use-owner/use-post-login-owner/use-post-login-owner";

export const LoginProLobbyOwner = ({ userDetails }) => {
  let navigate = useNavigate();
  let { defaultVariables, UseStatsVariables } = UseValueLoginOwner({
    userDetails,
  });
  let { userFirstName, userLastName, userEmail, userPhoneNumber } =
    defaultVariables;

  let {
    firstNameV: { firstName, setFirstName },
    lastNameV: { lastName, setLastName },
    emailV: { email, setEmail },
    phoneNumberV: { phoneNumber, setPhoneNumber },
  } = UseStatsVariables;

  console.log(firstName, lastName, email, phoneNumber);
  let { handleUserData } = UsePostLoginOwner({ UseStatsVariables });

  let sendingData1 = () => {
    navigate("/");
    handleUserData();
  };
  return (
    <>
      <div className="col-md-4">
        <label for="validationCustom01" className="form-label">
          First name
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
          Last name
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
          placeholder="052-538-1648"
          defaultValue={userPhoneNumber}
          onChange={(e) => setPhoneNumber(e.target.value)}
        />
        <div className="valid-feedback">Looks good!</div>
      </div>

      <button className="btn btn-primary" onClick={sendingData1}>
        Submit form
      </button>
    </>
  );
};
