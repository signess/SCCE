using Newtonsoft.Json;

namespace SCCE.Models
{
    public class UserDetailCredentials
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
