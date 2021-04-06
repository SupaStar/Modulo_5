using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Models
{
    public class SolucionQuejaModel
    {
        public int id { get; set; }
        public int id_queja { get; set; }
        [Display(Name = "Solucion a la queja")]
        public string solucion { get; set; }
    }
}
