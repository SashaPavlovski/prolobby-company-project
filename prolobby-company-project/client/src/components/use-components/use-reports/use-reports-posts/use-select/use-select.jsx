//options of posts reports
export const UseSelectValueReportsPosts = () => {
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
      label: "By number of responses",
      value: 2,
    },
    {
      label: "By amount of shares",
      value: 3,
    },
  ];
  return { options };
};
