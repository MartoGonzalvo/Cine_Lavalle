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
            BaseTp cartelera = new BaseTp();
            var listaImg = (from ca in cartelera.Carteleras
                            join pe in cartelera.Peliculas on ca.IdPelicula equals pe.IdPelicula
                            join ge in cartelera.Generos on pe.IdGenero equals ge.IdGenero
                            join cal in cartelera.Calificaciones on pe.IdCalificacion equals cal.IdCalificacion
                            where ca.FechaInicio<= DateTime.Now && ca.FechaFin>= DateTime.Now 
                            select pe);

            return View(listaImg);




        }
        [HttpPost]
        public ActionResult Index(Peliculas p)
        {

            return RedirectToAction("ReservaPrevia", "Reserva", p);


        }

    }
}
