import { NavBarOwner } from "./../../navBar-users/navBar.Owner/navBar.Owner";
import { Routes, Route } from "react-router-dom";
import { HomeOrganization } from "../../../pages/home/home-organization/home-organization";
import { AboutCampaign } from "../../../pages/organization/about-campaign/about-campaign";
import { ProductsList } from "../../../pages/products/products-list/products-list";
import { ProLobbyOwnerHP } from "../../home-pages-components";
import { LoginProLobbyOwner } from "../../../pages/login-components";

export const RoutesProLobbyOwner = () => {
  return (
    <>
      <NavBarOwner />
      <Routes>
        <Route
          path="/"
          element={<ProLobbyOwnerHP components={HomeOrganization} />}
        />
        <Route path="/profile" element={<LoginProLobbyOwner />} />
        <Route
          path="/about-campaign"
          element={<ProLobbyOwnerHP components={AboutCampaign} />}
        />
        <Route
          path="/products"
          element={<ProLobbyOwnerHP components={ProductsList} />}
        />
      </Routes>
    </>
  );
};
