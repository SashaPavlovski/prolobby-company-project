import { useState } from "react";

//The useState functions of creating the contribution of a product
export const UseValueCreateProduct = () => {
  const [product_Name, setProduct_Name] = useState("");
  const [price, setPrice] = useState("");
  const [count, setCount] = useState("");
  console.log(product_Name, price);

  return {
    UseStatsVariables: {
      Product_NameV: { product_Name, setProduct_Name },
      PriceV: { price, setPrice },
      CountV: { count, setCount },
    },
  };
};
