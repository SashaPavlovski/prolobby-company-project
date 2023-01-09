import React from "react";
import { NavBar } from "../../navBar-components/navBar-body/navBar-body-components";

let navBarArr = [
  {
    path: "/",
    pathName: "home",
  },
  {
    path: "/profile",
    pathName: "profile",
  },
  {
    path: "/create-campaign",
    pathName: "create-campaign",
  },
];

export const NavBarOrganization = () => {
  return <NavBar pathArr={navBarArr} />;
};
