using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peliculas.Controllers
{
    public class AdministracionController : Controller
    {
        public ActionResult Inicio()
        {
            return View("Inicio");
        }


        // GET: Administracion
        public ActionResult Login()
        {
            return View("Login");
        }


        //metodo que lista todos los objetos de una tabla y las guarda en una lista
        public ActionResult GestionPeliculas()
        {
            BaseTp peliculas = new BaseTp();
            List<Peliculas> listaPeliculas = peliculas.Peliculas.ToList();   
            return View("GestionPeliculas",listaPeliculas);
        }

        public ActionResult AgregarPelicula()
        {

            return View("AgregarPelicula");
        }

        [HttpPost]
        public ActionResult AgregarPelicula(Peliculas p)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }else
            {
                var agregar = new BaseTp();
                agregar.Peliculas.Add(p);
                agregar.SaveChanges();
                return Redirect("GestionPeliculas");
            }
            
        }
        
    }
}
