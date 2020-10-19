using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Models
{
    public class TipoQueja
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
    }
}
