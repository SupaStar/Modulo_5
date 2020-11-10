using System.ComponentModel.DataAnnotations;

namespace Modulo_5.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo es requerido.")]
        [Display(Name = "Correo o nombre de usuario:")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo es requerido.")]
        [Display(Name = "Contraseña:")]
        public string Password { get; set; }
        public string SessionK_Name { get; set; } = "_Id";
    }
}
