using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Models
{
    public class QuejaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="N° de la cita es requerido")]
        [Display(Name = "N° de la cita")]
        public int Id_cita { get; set; }

        [Required(ErrorMessage = "El email es requerido.")]
        [EmailAddress(ErrorMessage = "Correo electrónico incorrecto.")]
        public int Email { get; set; }

        [Required(ErrorMessage = "El tipo de la queja es requerido.")]
        public int Id_tipo_queja { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida.")]
        [MinLength(50,ErrorMessage ="La longitud minima de la queja es de 50 caracteres.")]
        public int Descripcion { get; set; }
        public string Token { get; set; }
        public int Estado { get; set; }
    }
}
