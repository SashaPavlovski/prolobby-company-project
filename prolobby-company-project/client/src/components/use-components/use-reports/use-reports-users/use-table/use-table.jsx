import React from "react";
import { UseRowsReportsUsers } from "../use-rows/use-rows";

//Displaying the report table of the system users
//Certain rows are conditional on the report
export const UseTableReportsUsers = ({ arrOfSortingUsers, valueOption }) => {
  return (
    <div className="table-responsive">
      <table className="table align-middle">
        <thead>
          <tr>
            {valueOption == 1 ? (
              <th>Organization Name</th>
            ) : valueOption == 2 ? (
              <th>Company Name</th>
            ) : (
              <></>
            )}
            <th>User Name</th>
            <th>Email</th>
            <th>Phone Number</th>
            <th>Date of joining</th>
          </tr>
        </thead>
        <tbody>
          {arrOfSortingUsers && arrOfSortingUsers.length > 0 ? (
            arrOfSortingUsers.map((u) =>
              valueOption == 1 ? (
                <UseRowsReportsUsers
                  FullName={u.FullName}
                  Email={u.Email}
                  Phone_number={u.Phone_number}
                  Date={u.Date}
                  valueOption={valueOption}
                  NonProfitOrganizationName={u.NonProfitOrganizationName}
                  CompanyName={null}
                />
              ) : valueOption == 2 ? (
                <UseRowsReportsUsers
                  FullName={u.FullName}
                  Email={u.Email}
                  Phone_number={u.Phone_number}
                  Date={u.Date}
                  valueOption={valueOption}
                  NonProfitOrganizationName={null}
                  CompanyName={u.CompanyName}
                />
              ) : (
                <UseRowsReportsUsers
                  FullName={u.FullName}
                  Email={u.Email}
                  Phone_number={u.Phone_number}
                  Date={u.Date}
                  valueOption={valueOption}
                  NonProfitOrganizationName={null}
                  CompanyName={null}
                />
              )
            )
          ) : (
            <></>
          )}
        </tbody>
      </table>
    </div>
  );
};
