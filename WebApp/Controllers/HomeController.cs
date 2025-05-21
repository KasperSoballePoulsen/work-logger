using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {


            var model = new RegistreringViewModel
            {
                Afdelinger = AfdelingBLL.GetAfdelinger()
            .Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Navn
            }).ToList()
            };

            return View("VaelgAfdeling", model);
        }

        [HttpPost]
        public ActionResult HentOpretTidsregistreringView(RegistreringViewModel model)
        {
            
            model.Medarbejdere = MedarbejderBLL
                .GetMedarbejdereFraAfdeling(model.ValgtAfdelingId)
                    .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Navn })
                    .ToList();

            model.Sager = SagBLL.GetSagerByAfdelingId(model.ValgtAfdelingId)
                .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Overskrift})
                .ToList();

            model.Dato = DateTime.Today.ToString("yyyy-MM-dd");
            model.StartTidspunkt = "08:00";
            model.SlutTidspunkt = "16:00";

            return View("OpretTidsregistrering", model);
           
            
        }

        [HttpPost]
        public ActionResult GemTidsregistrering(RegistreringViewModel model)
        {
            try
            {
                DateTime dato = DateTime.Parse(model.Dato);
                TimeSpan start = TimeSpan.Parse(model.StartTidspunkt);
                TimeSpan slut = TimeSpan.Parse(model.SlutTidspunkt);

                DateTime startTidspunkt = dato.Add(start);
                DateTime slutTidspunkt = dato.Add(slut);

                

                TidsregistreringBLL.OpretTidsregistrering(startTidspunkt,slutTidspunkt, model.ValgtSagId, model.ValgtMedarbejderId);

                return View("TidsregistreringBekræftelse", model);
            }
            catch
            {
                
                return View("TidsregistreringFejlet");
            }


        }
    }
}