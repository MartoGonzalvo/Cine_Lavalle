using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peliculas.Controllers
{
    public class AdministracionController : Controller
    {
        // GET: Administracion
        public ActionResult Administracion()
        {
            return View("Login");
        }
    }
}