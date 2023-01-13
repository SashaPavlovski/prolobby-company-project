import React from "react";
import { UseValueDeliveryProduct } from "../../components/use-components/use-delivery-product/use-value-delivery-product/use-value-delivery-product";
import { UseFormDeliveryProduct } from "./../../components/use-components/use-delivery-product/use-form-delivery-product/use-form-delivery-product";

export const DeliveryProductList = () => {
  console.log(`DeliveryProductList : end :`);
  let { deliveryList, SendingProduct } = UseValueDeliveryProduct({});

  return (
    <UseFormDeliveryProduct
      deliveryList={deliveryList}
      SendingProduct={SendingProduct}
    />
  );
};
