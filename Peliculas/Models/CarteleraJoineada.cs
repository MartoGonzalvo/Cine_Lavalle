using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Peliculas.Models
{
    public class CarteleraJoineada
    {
        
        public int IdCartelera { get; set; }
        [Required]
        public string SedeNombre { get; set; }
        [Required]
        public string PeliculaNombre { get; set; }
        [Required]
        public int CarteleraHI { get; set; }
        [Required]
        public System.DateTime CarteleraFI { get; set; }
        [Required]
        public System.DateTime CarteleraFF { get; set; }
        [Required]
        public int CarteleraNS { get; set; }
        [Required]
        public string versionesNombre { get; set; }
        public bool lunes { get; set; }
        public bool martes { get; set; }
        public bool miercoles { get; set; }
        public bool jueves { get; set; }
        public bool viernes { get; set; }
        public bool sabado { get; set; }
        public bool domingo { get; set; }
        public System.DateTime FechaCarga { get; set; }

    }
}