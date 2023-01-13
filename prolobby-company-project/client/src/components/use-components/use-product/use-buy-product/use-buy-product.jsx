import React from "react";

import { addUserDataAsync } from "./../../../../services/services";

export const UseBuyProduct = async ({
  DonatedProducts_Id,
  userDataRow,
  action,
}) => {
  console.log(`enter : UseBuyProduct : ${DonatedProducts_Id}`);
  //   let { userData } = ExistRowUser();
  if (userDataRow !== null) {
    console.log(`userData : ${(userDataRow.SocialActivists_Id, action)}`);
    let answer = await addUserDataAsync("Shippers", action, {
      DonatedProducts_Id: DonatedProducts_Id,
      SocialActivists_Id: userDataRow.SocialActivists_Id,
    });
    console.log(`answer one beforw the end : ${answer}`);
    return answer;
  }

  return "";
};
