using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modulo_5.Models
{
    public class ObservacionModel
    {
        [Key]
        public int id { get; set; }
        public int id_estancia { get; set; }
        [Required(ErrorMessage = "Debes colocar un diagnostico.")]
        public string diagnostico { get; set; }
        public string observaciones { get; set; }
        [Required(ErrorMessage = "¿Que receta administraste?.")]
        public string receta { get; set; }

    }
}
