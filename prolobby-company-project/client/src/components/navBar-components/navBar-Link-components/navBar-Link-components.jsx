import React from "react";
import { Link } from "react-router-dom";

//Getting details and creating a link
export const NavBarLink = ({ path, pathName }) => {
  return (
    <li className="nav-item" role="presentation">
      <button className="nav-link">
        <Link to={path}>{pathName}</Link>
      </button>
    </li>
  );
};
