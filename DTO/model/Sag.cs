using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.model
{
    public class Sag
    {
        public int Id { get; set; }
        public string Overskrift { get; set; }
        public string Beskrivelse { get; set; }
        public Sag() { }

        public Sag(int id, string overskrift, string beskrivelse)
        {
            Id = id;
            Overskrift = overskrift;
            Beskrivelse = beskrivelse;
        }
    }
}
