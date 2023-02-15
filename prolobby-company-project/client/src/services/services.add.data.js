import axios from "axios";

//Sending Json and identity value
export const addUserDataAsync = async (userAccess, action, userData) => {
  let result;
  try {
    result = await axios.post(
      `http://localhost:7251/api/${userAccess}/${action}`,
      userData
    );
    if (result.status === 200) {
      console.log(`seccsed : ${result.data}`);
      return result.data;
    } else {
      alert(result.data);
      return {};
    }
  } catch (error) {
    alert("We encountered a problem, please contact the system administrator");
  }
};
