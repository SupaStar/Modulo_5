using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Models
{
    public class EstanciaModel
    {
        public int id { get; set; }
        public int id_paciente { get; set; }
        public int piso { get; set; }
        public int cama { get; set; }
    }
}
