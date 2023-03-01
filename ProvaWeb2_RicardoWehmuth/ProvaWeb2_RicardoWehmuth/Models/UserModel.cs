using Newtonsoft.Json;

namespace ProvaWeb2_RicardoWehmuth.Models
{
    public class UserModel
    {
        [JsonIgnore]
        public int Id { get; set; }  
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}
