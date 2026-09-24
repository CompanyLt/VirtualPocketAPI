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

        public string? Name { get; set; }
        public bool isParent {  get; set; }

        public string? avatar { get; set; }
    }
}
