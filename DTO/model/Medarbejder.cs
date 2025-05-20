using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.model
{
    public class Medarbejder
    {
        public int Id { get; set; }
        public string Initialer { get; set; }
        public string CPRNummer { get; set; }
        public string Navn { get; set; }
        public Afdeling Afdeling { get; set; }
        public List<Tidsregistrering> Tidsregistreringer { get; set; } = new List<Tidsregistrering>();

        public Medarbejder() { }
        public Medarbejder(string initialer, string cPRNummer, string navn, Afdeling afdeling)
        {
            
            Initialer = initialer;
            CPRNummer = cPRNummer;
            Navn = navn;
            Afdeling = afdeling;

        }
    }
}
