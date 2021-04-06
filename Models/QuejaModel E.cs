using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Modulo_5.Models
{
    public class QuejaModelE
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "N° de la urgencia es requerido")]
        [Display(Name = "N° de la urgencia")]
        public int Id_urgencia { get; set; }

        [Required(ErrorMessage = "El email es requerido.")]
        [EmailAddress(ErrorMessage = "Correo electrónico incorrecto.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El tipo de la queja es requerido.")]
        [Display(Name = "Tipo queja")]
        public int Id_tipo_queja { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida.")]
        [MinLength(25, ErrorMessage = "La longitud minima de la queja es de 25 caracteres.")]
        public string Descripcion { get; set; }
        public string Token { get; set; }
        public int Estado { get; set; }
        public List<TipoQueja> tipos { get; set; }
        public SolucionQuejaModel solucion { get; set; }
    }
}
