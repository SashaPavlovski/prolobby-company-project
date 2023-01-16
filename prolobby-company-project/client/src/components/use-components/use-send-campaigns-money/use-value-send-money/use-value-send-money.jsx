import { GetDataAsync } from "../../../../services/services.js";

export const UseValueSendMoney = () => {
  const sendMoney = async () => {
    await GetDataAsync("Twitter", "getTweet", null);
    alert("Done successfully");
  };

  return { sendMoney };
};
