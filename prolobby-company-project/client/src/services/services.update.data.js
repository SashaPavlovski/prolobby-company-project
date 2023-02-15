import axios from "axios";

//Sending Json and identity value
//without getting an answer
export const UpdateUserAsync = async (
  userAccess,
  action,
  updateUser,
  userId
) => {
  console.log(`updateUser : ${userId}`);
  try {
    const res = await axios.put(
      `http://localhost:7251/api/${userAccess}/${action}/${userId}`,
      updateUser
    );
    if (res.status === 200) {
      console.log(res.data);
    } else {
      alert(res.data);
    }
  } catch (error) {
    alert("We encountered a problem, please contact the system administrator");
  }
};
