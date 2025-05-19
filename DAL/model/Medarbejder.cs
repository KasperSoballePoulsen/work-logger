using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.model
{
    public class Medarbejder
    {
        public int Id { get; set; }
        public string Initialer { get; set; }
        public string CPRNummer { get; set; }
        public string Navn { get; set; }
        public virtual Afdeling Afdeling { get; set; }
        public virtual Tidsregistrering Tidsregistrering { get; set;}

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
