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


        //metodo para cargar la lista de genero y mostrarlo como partial view una lista en el formulario de carga de peliculas

        public ActionResult listarClasificacion()
        {
            var cal = new BaseTp();
            return PartialView(cal.Calificaciones.ToList());
        }

        public ActionResult listarGenero()
        {
            var gen = new BaseTp();
            return PartialView(gen.Generos.ToList());
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
