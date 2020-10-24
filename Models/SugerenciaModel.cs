using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Models
{
    public class SugerenciaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El correo electronico es requerido.")]
        [EmailAddress(ErrorMessage = "Correo electrónico incorrecto.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida.")]
        [Display(Name = "Describe tu sugerencia:")]
        [MinLength(25, ErrorMessage = "La longitud minima de la sugerencia es de 25 caracteres.")]
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public string Token { get; set; }
    }
}
