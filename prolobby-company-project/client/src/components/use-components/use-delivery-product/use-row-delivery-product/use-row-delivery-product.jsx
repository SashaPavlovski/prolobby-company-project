import React from "react";

export const UseRowDeliveryProduct = ({
  FullName,
  Product_Name,
  Phone_number,
  Address,
  Email,
  Sent,
  Shippers_Id,
  SendingProduct,
}) => {
  return (
    <tr>
      <th scope="row"></th>
      <td>{Product_Name}</td>
      <td>{FullName}</td>
      <td>{Phone_number}</td>
      <td>{Email}</td>
      <td>{Address}</td>
      <ButtonSent
        SendingProduct={SendingProduct}
        Sent={Sent}
        Shippers_Id={Shippers_Id}
      />
    </tr>
  );
};

const ButtonSent = ({ SendingProduct, Sent, Shippers_Id }) => {
  return (
    <>
      {Sent ? (
        <button
          type="button"
          className="btn btn-warning"
          onClick={() => SendingProduct(Shippers_Id)}
        >
          To send
        </button>
      ) : (
        <td>
          <button className="btn btn-warning">
            The product has been shipped
          </button>
        </td>
      )}
    </>
  );
};
