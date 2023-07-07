using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsameFabio1.DB.Entities
{
    public class Prenotazione
    {
        [Key]
        public Guid IdPrenotazioneAttivita { get; set; }
        public string IdUtente { get; set; }
        public Guid IdAttivita { get; set; }

        //[ForeignKey(nameof(IdUtente))]
        //public User IdUserNavigation { get; set; }
      
        [ForeignKey(nameof(IdAttivita))]
        public Attivita Attivita { get; set; }


    }
}
