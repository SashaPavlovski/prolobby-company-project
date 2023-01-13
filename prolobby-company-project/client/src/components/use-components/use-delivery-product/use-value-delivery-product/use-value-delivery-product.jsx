import { useState, useEffect } from "react";

import { GetDataAsync } from "../../../../services/services.js";

export const UseValueDeliveryProduct = () => {
  const [deliveryList, setDeliveryList] = useState("");
  const [rendering, setRendering] = useState("");

  const setProducts = async () => {
    let res = await GetDataAsync("Shippers", "getDeliveryList", null);
    setDeliveryList(res);
  };
  useEffect(() => {
    setProducts();
  }, [rendering]);

  const SendingProduct = async (Shippers_Id) => {
    console.log(`Shippers_Id : ${Shippers_Id}`);
    setRendering(Shippers_Id);
    await GetDataAsync("Shippers", "sendProduct", Shippers_Id);
  };
  return { deliveryList, SendingProduct };
};
