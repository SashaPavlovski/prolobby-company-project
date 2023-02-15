using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProLobbyCompanyProject.Model.Tables
{
    public class TBKeys
    {
        [Key]
        public int Key_Id { get; set; }
        public string ApiKey { get; set; }
        public string ApiKeySecret { get; set; }
        public string BearerToken { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }
        public string BearerTokenAuth0 { get; set; }

    }
}
        

