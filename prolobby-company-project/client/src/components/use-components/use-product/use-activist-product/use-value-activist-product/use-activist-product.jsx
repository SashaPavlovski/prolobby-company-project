import { useState } from "react";

import { UseGetCampaign } from "./../../../use-campaigns/use-get-campaign/use-get-campaign";

export const UseValueActivistProduct = ({ activistId }) => {
  const [product, setProduct] = useState([]);

  if (activistId !== null) {
    console.log(`enter : UseValueActivistProduct : ${activistId}`);
    let getProducts = {
      type: "Shippers",
      action: "getProductById",
      sortValue: activistId,
      setfunc: setProduct,
    };
    UseGetCampaign(getProducts);
  }
  return { product };
};
