using System.ComponentModel.DataAnnotations;

namespace VirtualPocket.Model
{
    public class LoginModel
    {






        [Required(ErrorMessage ="Neivestas slaptazodis")]       
        public string? Password { get; set; }
        [Required(ErrorMessage ="Neivestas vardas")]
        public string? Username { get; set; }


        public int uniqueId { get; set; }
    }
}
