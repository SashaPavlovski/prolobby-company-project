import React from "react";

//the view of an organization's login
export const ValueFormOrganization = ({
  userOrganizationName,
  setOrganizationName,
  userUrl,
  setUrl,
  userDecreption,
  setDecreption,
  userFirstName,
  setFirstName,
  userLastName,
  setLastName,
  userEmail,
  setEmail,
  userPhoneNumber,
  setPhoneNumber,
  sendingData,
  organizationName,
  url,
  decreption,
  firstName,
  lastName,
  email,
  phoneNumber,
}) => {
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
      {organizationName !== "" &&
      url !== "" &&
      decreption !== "" &&
      firstName !== "" &&
      lastName !== "" &&
      email !== "" &&
      phoneNumber !== "" ? (
        <button className="btn btn-primary" onClick={sendingData}>
          Send
        </button>
      ) : (
        <></>
      )}
    </>
  );
};
