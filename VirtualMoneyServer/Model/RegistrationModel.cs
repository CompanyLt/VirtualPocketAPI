using System.ComponentModel.DataAnnotations;

namespace VirtualPocket.Model
{
    public class RegistrationModel
    {
        [Required(ErrorMessage ="Neivedete vardo")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Neivedete pavardes")]
       public string? SurName { get; set; }
        [Required(ErrorMessage ="Neivestas emailas")]
        [EmailAddress(ErrorMessage ="Neteisingas emailas")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Neivestas slaptazodis")]
        public string? Password { get; set; }

        
        public int uniqueId { get; set; }


    }
}
