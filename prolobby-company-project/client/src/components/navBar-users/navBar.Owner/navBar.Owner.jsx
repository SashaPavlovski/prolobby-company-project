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
    path: "/send-active-money",
    pathName: "send active money",
  },
  {
    path: "/reports/campaigns",
    pathName: "campaigns reports",
  },
  {
    path: "/reports/posts",
    pathName: "posts reports",
  },
  {
    path: "/reports/users",
    pathName: "users reports",
  },
  {
    path: "/reports/products",
    pathName: "products reports",
  },
];

export const NavBarOwner = () => {
  return <NavBar pathArr={navBarArr} />;
};
