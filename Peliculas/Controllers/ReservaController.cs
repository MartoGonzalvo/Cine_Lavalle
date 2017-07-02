using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peliculas.Models;

namespace Peliculas.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Reserva
        

   

        public ActionResult listarVersion(Carteleras cartelera)
        {
            var car = new BaseTp();
            var ListaVersiones = (from c in car.Carteleras
                                 join v in car.Versiones on c.IdVersion equals v.IdVersion
                                 where c.IdPelicula == cartelera.IdPelicula
                                 select new SedesVersiones
                                 {
                                     IdVersion = v.IdVersion,
                                     VersionNombre = v.Nombre

                                 }).ToList();

            return PartialView(ListaVersiones);
        }
        public ActionResult listarDoc()
        {
            var cal = new BaseTp();
            return PartialView(cal.TiposDocumentos.ToList());
        }

    
        public ActionResult ReservaPrevia(Peliculas p)
        {
            TempData["IdPelicula"] = p.IdPelicula;
            return View();
        }

        [HttpPost]
        public ActionResult ReservaPrevia(Carteleras ca)
        {
             
             TempData["IdVersion"] = ca.IdVersion;
            TempData["IdPelicula"] = ca.IdPelicula;
            
            return RedirectToAction("ReservaPaso2");
           
        }

        public ActionResult ReservaPaso2()
        {
            BaseTp car = new BaseTp();
            var Version = (int)TempData["IdVersion"];
            var pelicula = (int)TempData["IdPelicula"];
            // var listarSedes= car.Carteleras.Where(model => model.IdVersion.Equals(ca.IdVersion)).ToList();
            var listarSedes = (from c in car.Carteleras
                               join s in car.Sedes on c.IdSede equals s.IdSede
                               join v in car.Versiones on c.IdVersion equals v.IdVersion
                               where c.IdVersion == Version
                               where c.IdPelicula == pelicula
                               select c).ToList();

            return View(listarSedes);
        }

        [HttpPost]
        public ActionResult ReservaPaso2( Carteleras sv)
        {
            TempData["IdVersion"] = sv.IdVersion;
            TempData["IdPelicula"] = sv.IdPelicula;
            TempData["IdSede"] = sv.IdSede;

            return RedirectToAction("ReservaPaso3");


        }

        public ActionResult ReservaPaso3()
        {
            var Version = (int)TempData["IdVersion"];
            var pelicula = (int)TempData["IdPelicula"];
            var sede = (int)TempData["IdSede"];
            BaseTp car = new BaseTp();
            // var listarSedes= car.Carteleras.Where(model => model.IdVersion.Equals(ca.IdVersion)).ToList();
            var listarHD = (from c in car.Carteleras
                            join s in car.Sedes on c.IdSede equals s.IdSede
                            join v in car.Versiones on c.IdVersion equals v.IdVersion
                            where c.IdVersion == Version
                            where c.IdPelicula == pelicula
                            where c.IdSede == sede
                            select c).ToList();
            
            return View(listarHD);

    }

        [HttpPost]
        public ActionResult ReservaPaso3(Carteleras sv)
        {

            BaseTp cartelera = new BaseTp();
            var listaReservaF = (from pe in cartelera.Peliculas
                                 join ge in cartelera.Generos on pe.IdGenero equals ge.IdGenero
                                 join ca in cartelera.Calificaciones on pe.IdCalificacion equals ca.IdCalificacion
                                 join car in cartelera.Carteleras on pe.IdPelicula equals car.IdPelicula
                                 join se in cartelera.Sedes on car.IdSede equals se.IdSede
                                 join ve in cartelera.Versiones on car.IdVersion equals ve.IdVersion
                                 where pe.IdPelicula == sv.IdPelicula
                                 select car).ToList();
                          
            TempData["ReservaFin"] = listaReservaF;

            return RedirectToAction("ReservaFinal");
           
        }


        public ActionResult ReservaFinal()
        {
            //List<ReservaFinal> lst = (List<ReservaFinal>)TempData["ReservaFin"];
            //ViewBag.ReservaF = lst;
            return View();

        }
        [HttpPost]
        public ActionResult ReservaFinal(Reservas r)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                BaseTp agregar = new BaseTp();
                agregar.Reservas.Add(r);
                agregar.SaveChanges();
            }

            return Redirect("MensajeReserva");

        }
        public ActionResult MensajeReserva()
        {
            BaseTp cartelera = new BaseTp();
            var listaMensaje = (from pe in cartelera.Peliculas
                                 join re in cartelera.Reservas on pe.IdPelicula equals re.IdPelicula
                                 join car in cartelera.Carteleras on pe.IdPelicula equals car.IdPelicula
                                 join se in cartelera.Sedes on car.IdSede equals se.IdSede
                                  orderby re.IdReserva descending
                                  select re).Take(1);
            

            return View(listaMensaje);
        }
    }
    }