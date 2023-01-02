import React from "react";

export const LoginSocialActivists = () => {
  return (
    <form className="row g-3 needs-validation">
      <div className="col-md-4">
        <label for="validationCustom01" className="form-label">
          First name
        </label>
        <input type="text" className="form-control" id="validationCustom01" />
        <div className="valid-feedback">Looks good!</div>
      </div>
      <div className="col-md-4">
        <label for="validationCustom02" className="form-label">
          Last name
        </label>
        <input type="text" className="form-control" id="validationCustom02" />
        <div className="valid-feedback">Looks good!</div>
      </div>
      <div className="col-md-6">
        <label for="inputEmail4" className="form-label">
          Email
        </label>
        <input type="email" className="form-control" id="inputEmail4" />
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
          />
          <div className="invalid-feedback">Please choose a username.</div>
        </div>
      </div>
      <div className="col-md-6">
        <label for="validationCustom03" className="form-label">
          Address
        </label>
        <input type="text" className="form-control" id="validationCustom03" />
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
          pattern="[0-9]{3}-[0-9]{2}-[0-9]{3}"
          className="form-control"
          id="validationCustom01"
        />
        <div className="valid-feedback">Looks good!</div>
      </div>

      <button className="btn btn-primary" type="submit">
        Submit form
      </button>
    </form>
  );
};
