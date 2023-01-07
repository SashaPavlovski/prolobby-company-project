import { useContext, useState, useEffect } from "react";

import { useAuth0 } from "@auth0/auth0-react";

import { GetUserDataAsync } from "../../services/services.js";
import { UserContext } from "../../context/userData.context.js";

export const Ifexist = () => {
  const [userDataRow, setUserDataRow] = useState(null);
  let { role1 } = useContext(UserContext);
  const { user } = useAuth0();
  const aaa = async () => {
    let userRow = await GetUserDataAsync(role1[0].name, user.sub);
    setUserDataRow(userRow[0]);
  };
  useEffect(() => {
    aaa();
    console.log("enter");
  }, []);

  return { userDataRow, user };
};
