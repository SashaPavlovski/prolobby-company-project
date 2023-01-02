import React from "react";

export const LoginBusinessCompanyRepresentative = () => {
  console.log("LoginBusinessCompanyRepresentative");
  return (
    <form className="row g-3 needs-validation">
      <div className="col-md-4">
        <label for="validationCustom01" className="form-label">
          Representative first name
        </label>
        <input type="text" className="form-control" id="validationCustom01" />
        <div className="valid-feedback">Looks good!</div>
      </div>
      <div className="col-md-4">
        <label for="validationCustom02" className="form-label">
          Representative last name
        </label>
        <input type="text" className="form-control" id="validationCustom02" />
        <div className="valid-feedback">Looks good!</div>
      </div>
      <div className="col-md-4">
        <label for="validationCustom01" className="form-label">
          Company name
        </label>
        <input type="text" className="form-control" id="validationCustom01" />
        <div className="valid-feedback">Looks good!</div>
      </div>
      <div class="input-group mb-3">
        <input
          type="text"
          class="form-control"
          placeholder="Recipient's username"
          aria-label="Recipient's username"
          aria-describedby="basic-addon2"
        />
        <span class="input-group-text" id="basic-addon2">
          @example.com
        </span>
      </div>
      <div className="col-md-6">
        <label for="inputEmail4" className="form-label">
          Email
        </label>
        <input type="email" className="form-control" id="inputEmail4" />
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
