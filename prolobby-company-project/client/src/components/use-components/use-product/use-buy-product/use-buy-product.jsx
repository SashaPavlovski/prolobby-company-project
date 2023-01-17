import { addUserDataAsync } from "./../../../../services/services";

//Sending product ID to cs
//There the product is bought
export const UseBuyProduct = async ({
  DonatedProducts_Id,
  userDataRow,
  action,
}) => {
  console.log(`enter : UseBuyProduct : ${DonatedProducts_Id}`);
  if (userDataRow !== null) {
    let answer = await addUserDataAsync("Shippers", action, {
      DonatedProducts_Id: DonatedProducts_Id,
      SocialActivists_Id: userDataRow.SocialActivists_Id,
    });
    return answer;
  }

  return "";
};
