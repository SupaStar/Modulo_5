using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modulo_5.Models
{
    public class EstanciaModel
    {
        [Key]
        public int id { get; set; }
        public int id_paciente { get; set; }
        [Required(ErrorMessage = "Debes seleccionar el piso de estancia.")]
        public int piso { get; set; }
        [Required(ErrorMessage = "Debes seleccionar la cama de estancia.")]
        public int cama { get; set; }
        [ForeignKey("id_paciente")]
        public PacienteModel paciente { get; set; }
    }
}
