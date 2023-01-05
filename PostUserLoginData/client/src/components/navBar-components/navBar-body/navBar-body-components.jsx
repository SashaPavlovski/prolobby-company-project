import React from "react";

import { LogoutButton } from "../../auth/buttons/logOut.buttons.auth0.components";
import { Profile } from "../../auth/profile/profile.auth0.components";
import { NavBarLink } from "../navBar-Link-components/navBar-Link-components";

import "../../navBar-users/navBar.components.css";

export const NavBar = ({ pathArr }) => {
  //מערך אוביקטים הראשון נתיב והשני שם
  return (
    <>
      <nav className="navbar navbar-expand-lg bg-light myNavBar">
        <ul
          className="nav nav-pills mb-3 myNavbar"
          id="pills-tab"
          role="tablist"
        >
          {pathArr.map((p) => {
            return <NavBarLink path={p.path} pathName={p.pathName} />;
          })}
          <li className="nav-item" role="presentation">
            <LogoutButton />
          </li>
        </ul>
        <div className="Profile">
          <Profile />
        </div>
      </nav>
    </>
  );
};
