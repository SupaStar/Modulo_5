using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo es requerido.")]
        [Display(Name = "Correo o nombre de usuario.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo es requerido.")]
        [Display(Name = "Contraseña.")]
        public string Password { get; set; }

        public string SessionK_Name = "_Nombre";
    }
}
