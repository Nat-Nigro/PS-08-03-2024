using System.ComponentModel.DataAnnotations;

namespace AlbergoNigro.Models
{
    public class Pensione
    {
        public int ID { get; set; }


        [Display(Name = "Pensione")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Tipologia { get; set; }


        [Display(Name = "Prezzo")]

        public decimal? Prezzo { get; set; }
    }
}
