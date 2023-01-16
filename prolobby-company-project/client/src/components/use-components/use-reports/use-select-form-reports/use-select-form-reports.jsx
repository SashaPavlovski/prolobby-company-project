import React from "react";

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
