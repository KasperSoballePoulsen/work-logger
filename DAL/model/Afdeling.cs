using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.model
{
    public class Afdeling
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public int Nummer { get; set; }
        public virtual List<Sag> Sager { get; set; } = new List<Sag>();

        public Afdeling() { }

        public Afdeling(string navn, int nummer)
        {
            
            Navn = navn;
            Nummer = nummer;          
        }
    }
}
