import { useState } from "react";
import { useNavigate, useLocation } from "react-router-dom";
import { UseGetCampaign } from "./../../use-campaigns/use-get-campaign/use-get-campaign";
import { Ifexist } from "./../../../repeat/user-if-exist";
import { UseBuyProduct } from "../use-buy-product/use-buy-product";

export const UseValueProduct = () => {
  const [product, setProduct] = useState([]);
  const navigate = useNavigate();
  const location = useLocation();
  const { Campaigns_Id } = location.state;
  let getProducts = {
    type: "DonatedProducts",
    action: "getData",
    sortValue: Campaigns_Id,
    setfunc: setProduct,
  };
  UseGetCampaign(getProducts);
  let { userDataRow } = Ifexist();
  const buy = async (DonatedProducts_Id) => {
    let action = "buyProduct";
    let answer = await UseBuyProduct({
      DonatedProducts_Id,
      userDataRow,
      action,
    });
    alert(answer);
    navigate("/about-campaign", {
      state: {
        Campaigns_Id,
      },
    });
    console.log(`answer end : ${answer}`);
    return answer;
  };
  const donation = async (DonatedProducts_Id) => {
    let action = "donationProduct";
    let answer = await UseBuyProduct({
      DonatedProducts_Id,
      userDataRow,
      action,
    });
    alert(answer);
    navigate("/about-campaign", {
      state: {
        Campaigns_Id,
      },
    });
    console.log(`answer end : ${answer}`);
    return answer;
  };
  const backToCampaign = () => {
    navigate("/about-campaign", {
      state: {
        Campaigns_Id,
      },
    });
  };
  return { product, buy, donation, backToCampaign };
};
