using System.ComponentModel.DataAnnotations;
using System;

namespace EsameFabio1.DB.Entities
{
    public class PrenotazioneModel
    {
        [Key]
        public Guid IdPrenotazioneAttivita { get; set; }
        public string IdUtente { get; set; }
        public Guid IdAttivita { get; set; }
        public User idUserNavigation { get; set; }
    }
}
