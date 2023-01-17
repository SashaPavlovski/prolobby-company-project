import React from "react";

import { UseCardProduct } from "../../../components/use-components/use-product/use-get-product/use-card-product";
import { UseValueProduct } from "../../../components/use-components/use-product/use-value-product/use-value-product";

//A generic function to display products for each campaign
export const ProductsList = () => {
  let { product, buy, donation, backToCampaign } = UseValueProduct({});
  if (product !== null && product.length > 0)
    return product.map((p) => (
      <UseCardProduct
        Product_Name={p.Product_Name}
        Price={p.Price}
        buy={buy}
        donation={donation}
        backToCampaign={backToCampaign}
        DonatedProducts_Id={p.DonatedProducts_Id}
      />
    ));
};
