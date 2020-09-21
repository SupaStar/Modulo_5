using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Models
{
    public class UrgenciaModel : DbContext
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNac { get; set; }
        public string Email { get; set; }
        public int IdArea { get; set; }
        public int Telefono { get; set; }
        public int TelefonoF { get; set; }
        public int Nss { get; set; }
        public string Descripcion { get; set; }
    }
}
