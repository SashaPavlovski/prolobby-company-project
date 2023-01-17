import React from "react";
import { useAuth0 } from "@auth0/auth0-react";

//A component that activates the login button
export const LoginButton = () => {
  const { loginWithRedirect } = useAuth0();

  return <button onClick={() => loginWithRedirect()}>Log In</button>;
};
