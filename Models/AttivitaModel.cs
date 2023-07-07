using System;

namespace EsameFabio1.Models
{
    public class AttivitaModel
    {
        
        public Guid IdAttivita { get; set; }
        public string NomeAttivita { get; set; }
        public string DescrizioneAttivita { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public int NumeroPosti { get; set; }
        public decimal PrezzoAttivita { get; set; }
        public string ImgAtt { get; set; }

    }
}
