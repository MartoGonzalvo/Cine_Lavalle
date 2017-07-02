using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Peliculas.Models
{
    public class SedesVersiones
    {
        public int IdPelicula { get; set; }   
        public int IdSede { get; set; }
        public string SedeNombre { get; set; }
        public int IdVersion { get; set; }
        public string VersionNombre { get; set; }
        public string Dia { get; set; }
        public int Hora { get; set; }
        public bool lunes { get; set; }
        public bool martes { get; set; }
        public bool miercoles { get; set; }
        public bool jueves { get; set; }
        public bool viernes { get; set; }
        public bool sabado { get; set; }
        public bool domingo { get; set; }


    }
}