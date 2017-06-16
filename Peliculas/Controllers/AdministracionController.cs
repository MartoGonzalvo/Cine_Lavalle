using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peliculas.Controllers
{
    public class AdministracionController : Controller
    {
        
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(Usuarios u)
        {
            if (ModelState.IsValid)
            {
                BaseTp login = new BaseTp();
                var log = login.Usuarios.Where(model=>model.NombreUsuario.Equals(u.NombreUsuario) && model.Password.Equals(u.Password)).FirstOrDefault();

                if(log != null)
                {
                    Session["NombreUsuario"] = log.NombreUsuario.ToString();
                    return RedirectToAction("Inicio");
                }else
                {
                    ViewBag.msj = true;
                }
            }
            return View("Login");
        }

        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult Inicio()
        {
            return View("Inicio");
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
            /*if (!ModelState.IsValid)
            {
                return View();
            }else
            {*/
                string archivo = Path.GetFileNameWithoutExtension(p.ArchivoImagen.FileName);
                string extension = Path.GetExtension(p.ArchivoImagen.FileName);
                archivo = archivo + extension;
                p.Imagen = "/Content/img" + archivo;
                archivo = Path.Combine(Server.MapPath("/Content/img/"),archivo);
                p.ArchivoImagen.SaveAs(archivo);
               /* var path = ConfigurationManager.AppSettings["pathImagen"];

                var nombre = p.Nombre + "1";
                Request.Files[0].SaveAs(@"C:\sitio\content\img\" + nombre);

                p.Imagen = nombre;*/
                BaseTp agregar = new BaseTp();
                agregar.Peliculas.Add(p);
                agregar.SaveChanges();
                return Redirect("GestionPeliculas");
           //}
            
        }
        
    }
}
