import { useState, useEffect } from "react";

import { GetDataAsync } from "../../../../services/services.get.data.js";

//Receiving all Buy Product
//that are needed for sending
export const UseValueDeliveryProduct = () => {
  const [deliveryList, setDeliveryList] = useState("");
  const [rendering, setRendering] = useState("");

  const setProducts = async () => {
    let res = await GetDataAsync("Shippers", "getDeliveryList", null);
    setDeliveryList(res);
  };

  const SendingProduct = async (Shippers_Id) => {
    setRendering(Shippers_Id);
    await GetDataAsync("Shippers", "sendProduct", Shippers_Id);
  };
  useEffect(() => {
    setProducts();
  }, [rendering]);
  return { deliveryList, SendingProduct };
};
