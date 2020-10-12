using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Models
{
    public class QuejaModel
    {
        public int Id { get; set; }
        public int Email { get; set; }
        public int idTipoQueja { get; set; }
        public int Descripcion { get; set; }
    }
}
