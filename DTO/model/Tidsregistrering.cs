using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.model
{
    public class Tidsregistrering
    {
        public DateTime StartTidspunkt { get; set; }
        public DateTime SlutTidspunkt { get; set; }

        public int? SagsId { get; set; }

        public Tidsregistrering() { }

        public Tidsregistrering(DateTime startTidspunkt, DateTime slutTidspunkt, int? sagsId)
        {
            StartTidspunkt = startTidspunkt;
            SlutTidspunkt = slutTidspunkt;
            SagsId = sagsId;
        }
    }
}
