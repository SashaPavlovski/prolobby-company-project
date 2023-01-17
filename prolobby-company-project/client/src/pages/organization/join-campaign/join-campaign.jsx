import { addUserDataAsync } from "./../../../services/services";

//Sends the ID of activist and the campaign ID
//in order to join the campaign
export const JoinCampaign = ({ Campaigns_Id, userDataRow }) => {
  let userId = userDataRow.SocialActivists_Id;
  const addToMoneyTracking = async () => {
    await addUserDataAsync("MoneyTracking", "addTrack", {
      SocialActivists_Id: userId,
      Campaigns_Id: Campaigns_Id,
    });
  };

  return { addToMoneyTracking };
};
