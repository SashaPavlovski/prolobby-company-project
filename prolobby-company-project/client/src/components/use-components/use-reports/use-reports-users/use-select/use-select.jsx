//User report options
export const UseSelectValueReportsUsers = () => {
  const options = [
    {
      label: "Open this select table",
      value: 0,
    },
    {
      label: "By date and NonProfitOrganization",
      value: 1,
    },
    {
      label: "By date and BusinessCompanyRepresentative",
      value: 2,
    },
    {
      label: "By date and ProLobbyOwner",
      value: 3,
    },
    {
      label: "By date and SocialActivists",
      value: 4,
    },
  ];
  return { options };
};
