using System.ComponentModel.DataAnnotations;

namespace AlbergoNigro.Models
{
    public class LogIn
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Password { get; set; }
    }
}
