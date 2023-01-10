import React from "react";

import { LogoutButton } from "../auth/buttons/logOut.buttons.auth0.components";
import { Profile } from "../auth/profile/profile.auth0.components";
import { Link } from "react-router-dom";

import "./navBar.components.css";

export const NavBar = () => {
  return (
    <>
      <nav className="navbar navbar-expand-lg bg-light myNavBar">
        <ul
          className="nav nav-pills mb-3 myNavbar"
          id="pills-tab"
          role="tablist"
        >
          <li className="nav-item" role="presentation">
            <button className="nav-link">
              <Link to="/">Home</Link>
            </button>
          </li>
          <li className="nav-item" role="presentation">
            <button className="nav-link">
              {/* <Link to="/contactUs">ContactUs</Link> */}
            </button>
          </li>
          <li className="nav-item" role="presentation">
            <button className="nav-link">
              {/* <Link to="/Products_2">AllProduct_2</Link> */}
            </button>
          </li>
          <li className="nav-item" role="presentation">
            <button className="nav-link">
              {/* <Link to="/Products_1">AllProduct_1</Link> */}
            </button>
          </li>
          <li className="nav-item" role="presentation">
            <button className="nav-link">
              {/* <Link to="/aboute">Aboute</Link> */}
            </button>
          </li>
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
