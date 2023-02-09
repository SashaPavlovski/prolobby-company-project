//options of Products Reports
export const UseSelectValueReportsProducts = () => {
  const options = [
    {
      label: "Open this select table",
      value: 0,
    },
    {
      label: "By date",
      value: 1,
    },
    {
      label: "By shipping status",
      value: 2,
    },
    {
      label: "By price",
      value: 3,
    },
    {
      label: "By amount products",
      value: 4,
    },
  ];
  return { options };
};
