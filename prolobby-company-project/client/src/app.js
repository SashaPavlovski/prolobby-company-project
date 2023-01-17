import { LoginButton } from "./components/auth/buttons/logIn.buttons.auth0.components";
import { useAuth0 } from "@auth0/auth0-react";

import { Main } from "./components/main/main.components";

import "./app.css";

//The login page
//checks if we have permission
//If not, it takes us to the login page
export const App = () => {
  const { isAuthenticated, isLoading } = useAuth0();
  if (!isLoading) {
    return (
      <div className="App">{isAuthenticated ? <Main /> : <LoginButton />}</div>
    );
  } else {
    return "Loading";
  }
};
