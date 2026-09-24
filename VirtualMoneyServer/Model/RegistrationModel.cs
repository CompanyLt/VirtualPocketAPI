using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VirtualPocket.Model
{
    public class RegistrationModel
    {
        [Required(ErrorMessage ="Neivedete vardo")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Neivedete pavardes")]
       public string? Surname { get; set; }
        [Required(ErrorMessage ="Neivestas emailas")]
        [EmailAddress(ErrorMessage ="Neteisingas emailas")]
         public string? Email { get; set; }
        public string? Username { get; set; }
     
        [Required(ErrorMessage = "Neivestas slaptazodis")]
        public string? Password { get; set; }
    

        public bool isParent {  get; set; }

        [JsonIgnore]
        public int uniqueId { get; set; }


    }
}
