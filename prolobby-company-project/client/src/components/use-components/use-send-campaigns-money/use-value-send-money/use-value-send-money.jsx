import { GetDataAsync } from "../../../../services/services.get.data.js";

//A component that performs the link to the cs
//to perform the Twitter scan
export const UseValueSendMoney = () => {
  const sendMoney = async () => {
    await GetDataAsync("Twitter", "getTweet", null);
    alert("Done successfully");
  };

  return { sendMoney };
};
