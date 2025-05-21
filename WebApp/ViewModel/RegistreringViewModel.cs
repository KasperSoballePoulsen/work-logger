using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.ViewModel
{
    public class RegistreringViewModel
    {
        public int ValgtAfdelingId { get; set; }
        public int ValgtMedarbejderId { get; set; }
        public int? ValgtSagId { get; set; }

        public string Dato { get; set; }
        public string StartTidspunkt { get; set; }
        public string SlutTidspunkt { get; set; }

        public List<SelectListItem> Afdelinger { get; set; }
        public List<SelectListItem> Medarbejdere { get; set; }
        public List<SelectListItem> Sager { get; set; }
    }
}