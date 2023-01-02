import React from "react";

export const LoginProLobbyOwner = () => {
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
