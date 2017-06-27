using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peliculas.Models;
using System.Data.Entity.Validation;

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
                var log = login.Usuarios.Where(model => model.NombreUsuario.Equals(u.NombreUsuario) && model.Password.Equals(u.Password)).FirstOrDefault();

                if (log != null)
                {
                    Session["NombreUsuario"] = log.NombreUsuario.ToString();
                    return RedirectToAction("Inicio");
                }
                else
                {
                    ViewBag.msj = true;
                }
            }
            return View("Login");
        }

        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("../Home/Index");
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
            return View("GestionPeliculas", listaPeliculas);
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
           
                string archivo = Path.GetFileNameWithoutExtension(p.ArchivoImagen.FileName);
                string extension = Path.GetExtension(p.ArchivoImagen.FileName);
                archivo = archivo + extension;
                p.Imagen = "/Content/img/" + archivo;
                archivo = Path.Combine(Server.MapPath("/Content/img/"), archivo);
                p.ArchivoImagen.SaveAs(archivo);

                BaseTp agregar = new BaseTp();
                agregar.Peliculas.Add(p);
                agregar.SaveChanges();
            
            return Redirect("GestionPeliculas");
            

        }

        public ActionResult EditarPelicula(int id)
        {
            BaseTp pelicula = new BaseTp();
            Peliculas pel = pelicula.Peliculas.Where(p => p.IdPelicula == id).FirstOrDefault();
            return View(pel);
        }

        [HttpPost]
        public ActionResult EditarPelicula(Peliculas pe)
        {
              BaseTp pelicula = new BaseTp();
                Peliculas pel = pelicula.Peliculas.Where(p => p.IdPelicula == pe.IdPelicula).FirstOrDefault();

                string archivo = Path.GetFileNameWithoutExtension(pe.ArchivoImagen.FileName);
                string extension = Path.GetExtension(pe.ArchivoImagen.FileName);
                archivo = archivo + extension;
                pe.Imagen = "/Content/img/" + archivo;
                archivo = Path.Combine(Server.MapPath("/Content/img/"), archivo);
                pe.ArchivoImagen.SaveAs(archivo);



                pel.Nombre = pe.Nombre;
                pel.Descripcion = pe.Descripcion;
                pel.IdCalificacion = pe.IdCalificacion;
                pel.Imagen = pe.Imagen;
                pel.IdGenero = pe.IdGenero;
                pel.Duracion = pe.Duracion;
                pel.FechaCarga = pe.FechaCarga;
                pelicula.SaveChanges();
                return Redirect("GestionPeliculas");

        }

        // Gestion de sedes
        public ActionResult GestionSede()
        {
            BaseTp sedes = new BaseTp();
            List<Sedes> listaSede = sedes.Sedes.ToList();
            return View("GestionSede", listaSede);

        }

        public ActionResult AgregarSede()
        {
            return View("AgregarSede");
        }

        [HttpPost]
        public ActionResult AgregarSede(Sedes s)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var agregar = new BaseTp();
                agregar.Sedes.Add(s);
                agregar.SaveChanges();
                return Redirect("GestionSede");
            }

        }

        public ActionResult EditarSede(int id)
        {
            BaseTp sedes = new BaseTp();
            Sedes sede = sedes.Sedes.Where(s => s.IdSede == id).FirstOrDefault();
            return View(sede);
        }

        [HttpPost]
        public ActionResult EditarSede(Sedes se)
        {
            BaseTp sed = new BaseTp();
            Sedes sede = sed.Sedes.Where(s => s.IdSede == se.IdSede).FirstOrDefault();

            sede.Nombre = se.Nombre;
            sede.Direccion = se.Direccion;
            sede.PrecioGeneral = se.PrecioGeneral;
            sed.SaveChanges();
            return RedirectToAction("GestionSede");
        }

        public ActionResult EliminarSede(int id)
        {
            BaseTp eliminar = new BaseTp();
            Sedes se = eliminar.Sedes.Find(id);
            eliminar.Sedes.Remove(se);
            eliminar.SaveChanges();
            return RedirectToAction("GestionSede");
        }


        public ActionResult GestionCarteleras()
        {
            BaseTp cartelera = new BaseTp();
            var listaCartelera = (from ca in cartelera.Carteleras
                                  join se in cartelera.Sedes on ca.IdSede equals se.IdSede
                                  join pe in cartelera.Peliculas on ca.IdPelicula equals pe.IdPelicula
                                  join ve in cartelera.Versiones on ca.IdVersion equals ve.IdVersion
                                  select ca); 


            return View(listaCartelera);
            
        }



        public ActionResult AgregarCartelera()
        {

            return View("AgregarCartelera");

        }



        [HttpPost]
        public ActionResult AgregarCartelera(Carteleras c)
        {
                BaseTp cartelera = new BaseTp();
                var carteleraVerificacion = cartelera.Carteleras.Where(ca => ca.IdSede == c.IdSede).ToList();

               foreach(var car in carteleraVerificacion)
                {
                    if (c.IdSede == car.IdSede && c.NumeroSala == car.NumeroSala && ((c.FechaInicio >= car.FechaInicio && c.FechaInicio <= car.FechaFin) || (c.FechaFin >= car.FechaInicio && c.FechaFin <= car.FechaFin)))
                    {
                        ViewBag.msjError = true;
                        
                    }else
                    {
                        var agregar = new BaseTp();
                        agregar.Carteleras.Add(c);
                        agregar.SaveChanges();
                        return Redirect("GestionCarteleras");
                    }
                }
            return View("AgregarCartelera");
        }
                 
                
                
            

        


            



        public ActionResult EditarCartelera(int id)
        {
            var cartelera = new BaseTp();
            var listaCartelera = (from ca in cartelera.Carteleras
                                            join se in cartelera.Sedes on ca.IdSede equals se.IdSede
                                            join pe in cartelera.Peliculas on ca.IdPelicula equals pe.IdPelicula
                                            join ve in cartelera.Versiones on ca.IdVersion equals ve.IdVersion
                                            where ca.IdCartelera == id
                                            select ca).FirstOrDefault(); 
           
            return View(listaCartelera);
        }

        [HttpPost]
        public ActionResult EditarCartelera(Carteleras c)
        {

            var editar = new BaseTp();
            Carteleras editarCartelera = editar.Carteleras.Where(car => car.IdCartelera == c.IdCartelera).FirstOrDefault();
            

            editarCartelera.IdSede = c.IdSede;
            editarCartelera.IdPelicula = c.IdPelicula;
            editarCartelera.HoraInicio = c.HoraInicio;
            editarCartelera.FechaInicio = c.FechaInicio;
            editarCartelera.FechaFin = c.FechaFin;
            editarCartelera.NumeroSala = c.NumeroSala;
            editarCartelera.IdVersion = c.IdVersion;
            editarCartelera.Lunes = c.Lunes;
            editarCartelera.Martes = c.Martes;
            editarCartelera.Miercoles = c.Miercoles;
            editarCartelera.Jueves = c.Jueves;
            editarCartelera.Viernes = c.Viernes;
            editarCartelera.Sabado = c.Sabado;
            editarCartelera.Domingo = c.Domingo;
            editarCartelera.FechaCarga = c.FechaCarga;
            
            editar.SaveChanges();
           

            return RedirectToAction("GestionCarteleras");
        }
        
        public ActionResult EliminarCartelera(int id)
        {
            BaseTp eliminar = new BaseTp();
            Carteleras ca = eliminar.Carteleras.Find(id);
            eliminar.Carteleras.Remove(ca);
            eliminar.SaveChanges();
            return RedirectToAction("GestionCarteleras");
        }


        public ActionResult listarSede()
        {
            var sede = new BaseTp();
            return PartialView(sede.Sedes.ToList());
        }

        public ActionResult listarPelicula()
        {
            var pelicula = new BaseTp();
            return PartialView(pelicula.Peliculas.ToList());
        }


        public ActionResult listarVersion()
        {
            var version = new BaseTp();
            return PartialView(version.Versiones.ToList());
        }

        public ActionResult listarSala()
        {

            return PartialView("listarSala");
        }
    }
}
