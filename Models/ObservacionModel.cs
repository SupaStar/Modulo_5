using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modulo_5.Models
{
    public class ObservacionModel
    {
        [Key]
        public int id { get; set; }
        
        [Display(Name = "Diagnostico")]
        [Required(ErrorMessage = "Debes colocar un diagnostico.")]
        public string diagnostico { get; set; }
        [Display(Name = "Observaciones")]
        public string observaciones { get; set; }
        [Display(Name = "Receta")]
        [Required(ErrorMessage = "¿Que receta administraste?.")]
        public string receta { get; set; }
        [Display(Name = "Id Estancia.")]
        public int id_estancia { get; set; }
        [ForeignKey("id_estancia")]
        public EstanciaModel estancia { get; set; }
    }
}
