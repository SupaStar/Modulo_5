using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modulo_5.Models
{
    public class OperacionModel
    {
        [Key]
        public int id { get; set; }
        
        [Display(Name = "Fecha de entrada")]
        public string fecha_entrada { get; set; }
        [Display(Name = "Fecha de salida estimada")]
        public string fecha_salida { get; set; }
        public int id_estancia { get; set; }
        [ForeignKey("id_estancia")]
        public EstanciaModel estancia { get; set; }
    }
}
