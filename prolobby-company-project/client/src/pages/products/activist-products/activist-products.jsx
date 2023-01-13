import React from "react";
import { useNavigate, useLocation } from "react-router-dom";

import { UseCardActivistProduct } from "../../../components/use-components/use-product/use-activist-product/use-card-activist-product/use-card-activist-product";
import { UseValueActivistProduct } from "../../../components/use-components/use-product/use-activist-product/use-value-activist-product/use-activist-product";

export const ActivistProducts = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const { activistId } = location.state;

  let { product } = UseValueActivistProduct({ activistId });
  if (product !== null && product.length > 0)
    return product.map((p) => (
      <UseCardActivistProduct
        Product_Name={p.Product_Name}
        Price={p.Price}
        IfSent={
          product.Active
            ? "The product has been shipped"
            : "Product awaiting shipment"
        }
      />
    ));
};
