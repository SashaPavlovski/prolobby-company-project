import React from "react";

import { UseValueDeliveryProduct } from "../../components/use-components/use-delivery-product/use-value-delivery-product/use-value-delivery-product";
import { UseFormDeliveryProduct } from "./../../components/use-components/use-delivery-product/use-form-delivery-product/use-form-delivery-product";

//The display page of the Delivery table
export const DeliveryProductList = () => {
  let { deliveryList, SendingProduct } = UseValueDeliveryProduct({});

  return (
    <UseFormDeliveryProduct
      deliveryList={deliveryList}
      SendingProduct={SendingProduct}
    />
  );
};
