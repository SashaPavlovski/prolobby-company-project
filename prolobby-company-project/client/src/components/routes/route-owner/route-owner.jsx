import { NavBarOwner } from "./../../navBar-users/navBar.Owner/navBar.Owner";
import { Routes, Route } from "react-router-dom";
import { HomeAllCampaigns } from "../../../pages/home/home-home-all-campaigns/home-all-campaigns";
import { AboutCampaign } from "../../../pages/organization/about-campaign/about-campaign";
import { ProductsList } from "../../../pages/products/products-list/products-list";
import { ProLobbyOwnerHP } from "../../home-pages-components";
import { LoginProLobbyOwner } from "../../../pages/login-components";
import { SendCampaignsMoney } from "./../../../pages/send-campaigns-money/send-campaigns-money";
import { ReportsCampaigns } from './../../../pages/reports/reports-campaigns/reports-campaigns';
import { ReportsPosts } from './../../../pages/reports/reports-posts/reports-posts';
import { ReportsUsers } from './../../../pages/reports/reports-users/reports-users';
import { ReportsProducts } from './../../../pages/reports/reports-products/reports-products';

export const RoutesProLobbyOwner = () => {
  return (
    <>
      <NavBarOwner />
      <Routes>
        <Route
          path="/"
          element={<ProLobbyOwnerHP components={HomeAllCampaigns} />}
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
        <Route
          path="/send-active-money"
          element={<ProLobbyOwnerHP components={SendCampaignsMoney} />}
        />
        <Route
          path="/reports/campaigns"
          element={<ProLobbyOwnerHP components={ReportsCampaigns} />}
        />
        <Route
          path="/reports/posts"
          element={<ProLobbyOwnerHP components={ReportsPosts} />}
        />
        <Route
          path="/reports/users"
          element={<ProLobbyOwnerHP components={ReportsUsers} />}
        />
        <Route
          path="/reports/products"
          element={<ProLobbyOwnerHP components={ReportsProducts} />}
        />
      </Routes>
    </>
  );
};
