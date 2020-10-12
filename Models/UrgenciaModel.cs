using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Models
{
    public class UrgenciaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida.")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNac { get; set; }

        [Required(ErrorMessage = "El email es requerido.")]
        [StringLength(100, ErrorMessage = "Logitud máxima 100.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email error.")]
        [EmailAddress(ErrorMessage = "Correo electrónico incorrecto.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El area es requerida.")]
        [Display(Name = "Area")]
        public int IdArea { get; set; }

        [Required(ErrorMessage = "El telefono es requerido.")]
        [Display(Name = "Telefono de contacto")]
        public int Telefono { get; set; }

        [Display(Name = "Telefono familiar (opcional):")]
        public int TelefonoF { get; set; }

        [Required(ErrorMessage = "El numero de seguridad social es requerido.")]
        public int Nss { get; set; }

        [Required(ErrorMessage = "La descripcion de los malestares es requerida.")]
        [Display(Name = "Descripcion de los malestares:")]
        public string Descripcion { get; set; }
        public int Estado { get; set; }
    }
}
