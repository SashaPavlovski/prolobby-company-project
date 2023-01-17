import React from "react";

//A generic function for displaying the options in each report
export const UseSelectFormReports = ({
  handleValue,
  UseSelectValueReports,
}) => {
  let { options } = UseSelectValueReports({});

  return (
    <div>
      <select
        id="CampaignsSelect"
        className="form-select"
        onClick={handleValue}
      >
        {options.map((option) => (
          <option value={option.value}>{option.label}</option>
        ))}
      </select>
    </div>
  );
};
