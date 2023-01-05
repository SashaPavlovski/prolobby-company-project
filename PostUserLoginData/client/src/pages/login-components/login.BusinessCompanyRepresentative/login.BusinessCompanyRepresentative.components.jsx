import React from "react";

import { useNavigate } from "react-router-dom";
import { UseValueLoginCompany } from "./../../../components/use-components/use-company/use-value-login-company/use-value-login-company";
import { UsePostLoginCompany } from "./../../../components/use-components/use-company/use-post-login-company/use-post-login-company";

export const LoginBusinessCompanyRepresentative = ({ userDetails }) => {
  let { defaultVariables, UseStatsVariables } = UseValueLoginCompany({
    userDetails,
  });
  let {
    userFirstName,
    userCompanyName,
    userUrl,
    userLastName,
    userEmail,
    userPhoneNumber,
  } = defaultVariables;

  let {
    companyNameV: { companyName, setCompanyName },
    urlV: { url, setUrl },
    firstNameV: { firstName, setFirstName },
    lastNameV: { lastName, setLastName },
    emailV: { email, setEmail },
    phoneNumberV: { phoneNumber, setPhoneNumber },
  } = UseStatsVariables;

  console.log(firstName, lastName, companyName, url, email, phoneNumber);
  let { handleUserData } = UsePostLoginCompany({ UseStatsVariables });

  let sendingData1 = () => {
    handleUserData();
  };
  return (
    <>
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
      <div className="col-md-4">
        <label for="validationCustom01" className="form-label">
          Company name
        </label>
        <input
          type="text"
          className="form-control"
          id="validationCustom01"
          defaultValue={userCompanyName}
          onChange={(e) => setCompanyName(e.target.value)}
        />
        <div className="valid-feedback">Looks good!</div>
      </div>
      <div class="input-group mb-3">
        <input
          type="text"
          class="form-control"
          placeholder="Recipient's username"
          aria-label="Recipient's username"
          aria-describedby="basic-addon2"
          defaultValue={userUrl}
          onChange={(e) => setUrl(e.target.value)}
        />
        <span class="input-group-text" id="basic-addon2">
          @example.com
        </span>
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
          className="form-control"
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
// <form className="row g-3 needs-validation">

// type="submit"
//</form>
//
