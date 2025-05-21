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
        // GET: Home
        public ActionResult Index()
        {
            var model = new RegistreringViewModel();

            model.Afdelinger = AfdelingBLL.GetAfdelinger()
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Navn
                }).ToList();

            


            return View(model);
        }
    }
}