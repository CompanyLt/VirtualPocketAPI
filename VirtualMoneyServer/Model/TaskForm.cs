using System.ComponentModel.DataAnnotations;

namespace VirtualPocket.Model
{
    public class TaskForm
    {
        [Required(ErrorMessage ="Laukas neuzpildytas")]
        public string Title { set; get; }
        [Required(ErrorMessage = "Laukas neuzpildytas")]
        public string Description { set; get; }
        [Required(ErrorMessage = "Laukas neuzpildytas")]
        public string Category {  set; get; }
        [Required(ErrorMessage = "Laukas neuzpildytas")]
        public decimal Reward { set; get; }
        [Required(ErrorMessage = "Laukas neuzpildytas")]
        public string UniqueId { set; get; }


    }
}
