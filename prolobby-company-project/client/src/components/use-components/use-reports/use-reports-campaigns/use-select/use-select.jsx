//options of the campaign reports
export const UseSelectValueReports = () => {
  const options = [
    {
      label: "Open this select table",
      value: 0,
    },
    {
      label: "By number of activistse in the campaign",
      value: 1,
    },
    {
      label: "By date",
      value: 2,
    },
    {
      label: "By amount of products donated",
      value: 3,
    },
    {
      label: "By name of the association",
      value: 4,
    },
    {
      label: "By activity",
      value: 5,
    },
  ];
  return { options };
};
