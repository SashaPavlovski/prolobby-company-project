import { addUserDataAsync } from "../../../../services/services.add.data.js";

//The function of sends the data of Create Campaign to cs
//Additionally sends a message to the user
//If the hashtag or its name of the campaign already exists
export const UsePostCreateCampaign = ({ UseStatsVariables, userId }) => {
  let {
    Campaigns_NameV: { Campaigns_Name },
    DescreptionV: { Descreption },
    HashtagV: { Hashtag },
    IfExistV: { setIfExist },
  } = UseStatsVariables;

  const addNewCampaign = async () => {
    return await addUserDataAsync("Campaigns", "addData", {
      Campaigns_Name: Campaigns_Name,
      Descreption: Descreption,
      Hashtag: Hashtag,
      User_Id: userId,
    });
  };

  const sendData = async () => {
    let answer = await addNewCampaign();
    console.log("answer : " + answer);

    if (answer.includes("Exists")) {
      setIfExist("showIfNameExist");
    } else {
      setIfExist("showIfNotExist");
    }
    return answer;
  };

  return { sendData };
};
