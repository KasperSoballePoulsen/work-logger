using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.model
{
    public class Sag
    {
        public int Id { get; set; }
        public string Overskrift { get; set; }
        public string Beskrivelse { get; set; }
        public Sag() { }

        public Sag(string overskrift, string beskrivelse)
        {
            
            Overskrift = overskrift;
            Beskrivelse = beskrivelse;
        }
    }
}
