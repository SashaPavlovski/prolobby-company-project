import axios from "axios";

//Receiving data according to an identity value
export const GetDataAsync = async (userAccess, action, userID) => {
  try {
    let result = await axios.get(
      `http://localhost:7251/api/${userAccess}/${action}/${userID}`
    );
    if (result.status === 200) {
      console.log(`seccsed : ${result.data}`);
      return result.data;
    } else {
      console.log("enter GetDataAsync else");
      alert(result.data);
      return {};
    }
  } catch (error) {
    alert("We encountered a problem, please contact the system administrator");
  }
};
