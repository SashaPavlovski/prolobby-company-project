import { useState } from "react";

export const UseValueCreateProduct = () => {
  const [product_Name, setProduct_Name] = useState("");
  const [price, setPrice] = useState("");
  const [picture, setPicture] = useState("");
  console.log(product_Name, price);

  return {
    UseStatsVariables: {
      Product_NameV: { product_Name, setProduct_Name },
      PriceV: { price, setPrice },
      PictureV: { picture, setPicture },
    },
  };
};
