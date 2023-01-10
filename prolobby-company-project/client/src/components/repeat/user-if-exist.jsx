import { useContext, useState, useEffect } from "react";

import { useAuth0 } from "@auth0/auth0-react";

import { GetDataAsync } from "../../services/services.js";
import { UserContext } from "../../context/userData.context.js";

export const Ifexist = () => {
  const [userDataRow, setUserDataRow] = useState(null);
  let { role1 } = useContext(UserContext);
  const { user } = useAuth0();
  const Checking = async () => {
    let userRow = await GetDataAsync(role1[0].name, "userData", user.sub);
    if (userRow != null) {
      setUserDataRow(userRow[0]);
    }
  };
  useEffect(() => {
    Checking();
    console.log("enter");
  }, []);

  return { userDataRow, user };
};
