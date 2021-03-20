using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Models
{
    public class PacienteModel
    {
        [Key]
        public int id { get; set; }
        public string fecha_entrada { get; set; }
        public string fecha_salida { get; set; }
        public int id_urgencia { get; set; }

        [ForeignKey("id_urgencia")]
        public UrgenciaModelE urgencia { get; set; }
    }
}
