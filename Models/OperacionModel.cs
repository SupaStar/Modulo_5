using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modulo_5.Models
{
    public class OperacionModel
    {
        [Key]
        public int id { get; set; }
        public int id_estancia { get; set; }
        public string fecha_entrada { get; set; }
        public string fecha_salida { get; set; }
    }
}
