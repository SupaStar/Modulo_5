using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Models
{
    public class UsuariosPacienteModel
    {
        public int id { get; set; }
        public int id_estancia { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
    }
}
