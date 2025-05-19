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
        public Tidsregistrering Tidsregistrering { get; set; }

        public Medarbejder() { }
        public Medarbejder(int id, string initialer, string cPRNummer, string navn, Afdeling afdeling)
        {
            Id = id;
            Initialer = initialer;
            CPRNummer = cPRNummer;
            Navn = navn;
            Afdeling = afdeling;

        }
    }
}
