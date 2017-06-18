using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peliculas.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            BaseTp img = new BaseTp();
            List<Peliculas> listaImg = img.Peliculas.ToList();
            return View(listaImg);
            
        }

        
    }
}
