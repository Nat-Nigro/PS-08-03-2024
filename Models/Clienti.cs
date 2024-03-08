using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AlbergoNigro.Models
{
    public class Clienti
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Il campo Nome è obbligatorio")]
        public string Nome { get; set; }


        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Il campo Cognome è obbligatorio")]
        public string Cognome { get; set; }


        [Display(Name = "Codice Fiscale")]
        [Required(ErrorMessage = "Il campo Codice Fiscale è obbligatorio")]
        public string CodiceFiscale { get; set; }


        [Display(Name = "Città")]
        [Required(ErrorMessage = "Il campo Città è obbligatorio")]
        public string Citta { get; set; }


        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "Il campo Provincia è obbligatorio")]
        public string Provincia { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Il campo Email è obbligatorio")]
        [Remote("EmailValidator", "Home", ErrorMessage = "L'Email non e' valida")]
        public string Email { get; set; }


        [Display(Name = "Telefono")]
        public string? Telefono { get; set; }


        [Display(Name = "Cellulare")]
        [Required(ErrorMessage = "Il campo Cellulare è obbligatorio")]
        public string Cellulare { get; set; }
    }
}
