import React from "react";

import { useNavigate } from "react-router-dom";
import { UseValueLoginActivists } from "./../../../components/use-components/use-activists/use-value-login-activists/use-value-login-activists";
import { UsePostLoginActivists } from "./../../../components/use-components/use-activists/use-post-login-activists/use-post-login-activists";

export const LoginSocialActivists = ({ userDetails }) => {
  let navigate = useNavigate();
  let { defaultVariables, UseStatsVariables } = UseValueLoginActivists({
    userDetails,
  });
  let {
    userFirstName,
    userTwitterUser,
    userAddress,
    userLastName,
    userEmail,
    userPhoneNumber,
  } = defaultVariables;

  let {
    twitterUserV: { twitterUser, setTwitterUser },
    addressV: { address, setAddress },
    firstNameV: { firstName, setFirstName },
    lastNameV: { lastName, setLastName },
    emailV: { email, setEmail },
    phoneNumberV: { phoneNumber, setPhoneNumber },
  } = UseStatsVariables;

  console.log(firstName, lastName, email, twitterUser, address, phoneNumber);
  let { handleUserData } = UsePostLoginActivists({ UseStatsVariables });

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
        <label for="validationCustomUsername" className="form-label">
          Twitter user
        </label>
        <div className="input-group has-validation">
          <span className="input-group-text" id="inputGroupPrepend">
            @
          </span>
          <input
            type="text"
            className="form-control"
            id="validationCustomUsername"
            aria-describedby="inputGroupPrepend"
            defaultValue={userTwitterUser}
            onChange={(e) => setTwitterUser(e.target.value)}
          />
          <div className="invalid-feedback">Please choose a username.</div>
        </div>
      </div>
      <div className="col-md-6">
        <label for="validationCustom03" className="form-label">
          Address
        </label>
        <input
          type="text"
          className="form-control"
          id="validationCustom03"
          defaultValue={userAddress}
          onChange={(e) => setAddress(e.target.value)}
        />
        <div className="invalid-feedback">Please provide a valid city.</div>
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
