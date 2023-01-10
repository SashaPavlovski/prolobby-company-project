import React, { useState } from "react";

import { useLocation, useNavigate } from "react-router-dom";
import { UseCardProduct } from "../../../components/use-components/use-product/use-get-product/use-card-product";
import { UseGetCampaign } from "../../../components/use-components/use-campaigns/use-get-campaign/use-get-campaign";

export const ProductsList = () => {
  const [product, setProduct] = useState([]);
  const navigate = useNavigate();
  const location = useLocation();
  const { Campaigns_Id } = location.state;
  let getProducts = {
    type: "DonatedProducts",
    action: "getData",
    sortValue: Campaigns_Id,
    setfunc: setProduct,
  };
  UseGetCampaign(getProducts);

  const buy = () => {};
  const donation = () => {};
  const backToCampaign = () => {
    navigate("/about-campaign", {
      state: {
        Campaigns_Id,
      },
    });
  };
  if (product.length > 0)
    return product.map((p) => (
      <UseCardProduct
        Product_Name={p.Product_Name}
        Price={p.Price}
        buy={buy}
        donation1={donation}
        backToCampaign={backToCampaign}
      />
    ));
};
