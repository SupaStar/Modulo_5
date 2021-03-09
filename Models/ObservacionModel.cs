using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Models
{
    public class ObservacionModel
    {
        public int id { get; set; }
        public int id_estancia { get; set; }
        public string diagnostico { get; set; }
        public string observaciones { get; set; }
        public string receta { get; set; }

    }
}
