using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlbergoNigro.Models
{
    public class Prenotazione
    {
        [Display(Name = "N° Prenotazione")]
        public int ID { get; set; }



        [Display(Name = "Data Prenotazione")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataPrenotazione { get; set; }



        [Display(Name = "Data Inizio Soggiorno")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataInizioSoggiorno { get; set; }



        [Display(Name = "Data Fine Soggiorno")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataFineSoggiorno { get; set; }



        [Display(Name = "Anno")]
        public string Anno { get; set; }



        [Display(Name = "Acconto")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        public double Acconto { get; set; }



        [Display(Name = "Prezzo")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        public double Prezzo { get; set; }



        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [ForeignKey("Cliente")]
        public int IDCliente { get; set; }

        // Proprietà di navigazione per il cliente
        public Clienti? Cliente { get; set; }

        // ID della camera associata alla prenotazione
        [Display(Name = "Camera")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [ForeignKey("Camera")]
        public int IDCamera { get; set; }

        // Proprietà di navigazione per la camera
        public Camere? Camera { get; set; }

        // ID della pensione associata alla prenotazione
        [Display(Name = "Pensione")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [ForeignKey("Pensione")]
        public int IDPensione { get; set; }

        // Proprietà di navigazione per la pensione
        public Pensione? Pensione { get; set; }


    }
}
