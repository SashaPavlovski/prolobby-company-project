import React from "react";

import { UseRowDeliveryProduct } from "../use-row-delivery-product/use-row-delivery-product";

//The display of the product shipment table
export const UseFormDeliveryProduct = ({ deliveryList, SendingProduct }) => {
  return (
    <table class="table">
      <thead>
        <tr>
          <th scope="col"></th>
          <th scope="col">Product name</th>
          <th scope="col">Customer's name</th>
          <th scope="col">Phone number</th>
          <th scope="col">Email</th>
          <th scope="col">Address</th>
          <th scope="col">Shipping</th>
        </tr>
      </thead>
      <tbody>
        {deliveryList && deliveryList.length > 0 ? (
          deliveryList.map((d) => (
            <UseRowDeliveryProduct
              FullName={d.FullName}
              Product_Name={d.Product_Name}
              Phone_number={d.Phone_number}
              Address={d.Address}
              Email={d.Email}
              Sent={d.Sent}
              Shippers_Id={d.Shippers_Id}
              SendingProduct={SendingProduct}
            />
          ))
        ) : (
          <></>
        )}
      </tbody>
    </table>
  );
};
