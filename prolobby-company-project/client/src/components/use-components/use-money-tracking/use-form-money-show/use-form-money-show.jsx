import React from "react";

import { UseNewRowMoney } from "./../use-new-row-money/use-new-row-money";

//social activist
//display
//Showing the amount of money he has from each campaign
//Whether the campaign is active or not
export const UseFormMoneyShow = ({ arrMoneyData }) => {
  return (
    <table class="table caption-top">
      <caption>Account Balance </caption>
      <thead>
        <tr>
          <th scope="col">Organization name</th>
          <th scope="col">Campaign name</th>
          <th scope="col">Hashtag</th>
          <th scope="col">Money sum </th>
          <th scope="col">activity</th>
        </tr>
      </thead>
      <tbody>
        {arrMoneyData !== null && arrMoneyData.length !== 0 ? (
          arrMoneyData.map((m) => (
            <UseNewRowMoney
              NonProfitOrganizationName={m.NonProfitOrganizationName}
              Campaigns_Name={m.Campaigns_Name}
              Hashtag={m.Hashtag}
              Accumulated_money={m.Accumulated_money}
              Active={m.Active}
            />
          ))
        ) : (
          <></>
        )}
      </tbody>
    </table>
  );
};
