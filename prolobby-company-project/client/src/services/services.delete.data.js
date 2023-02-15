import axios from "axios";

//Receiving data according to an identity value for Delet
export const DeleteAsync = async (userAccess, action, id) => {
  console.log(`DeleteAsync : ${(userAccess, action, id)}`);
  try {
    const res = await axios.delete(
      `http://localhost:7251/api/${userAccess}/${action}/${id}`
    );
    if (res.status === 200) {
      return res.data;
    } else {
      alert(res.data);
      return {};
    }
  } catch (error) {
    alert("We encountered a problem, please contact the system administrator");
  }
};
