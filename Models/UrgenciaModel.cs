using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Modulo_5.Models
{
    public class UrgenciaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido paterno es requerido.")]
        [Display(Name = "Apellido paterno")]
        public string Ap_paterno { get; set; }
        [Required(ErrorMessage = "El apellido materno es requerido.")]
        [Display(Name = "Apellido materno")]
        public string Ap_materno { get; set; }

        [Required(ErrorMessage = "El telefono es requerido.")]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "Introduce un telefono correcto.")]
        [Display(Name = "Telefono de contacto")]
        public string Telefono { get; set; }

        [StringLength(10, MinimumLength = 8, ErrorMessage = "Introduce un telefono correcto.")]
        [Display(Name = "Telefono familiar (opcional):")]
        public string? TelefonoF { get; set; }

        [Required(ErrorMessage = "El email es requerido.")]
        [EmailAddress(ErrorMessage = "Correo electrónico incorrecto.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida.")]
        [DataType(DataType.DateTime, ErrorMessage = "La fecha de nacimiento es requerida.")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime Fecha_nac { get; set; }
        [Required(ErrorMessage = "La fecha de cita es requerida.")]
        [DataType(DataType.DateTime, ErrorMessage = "La fecha de cita es requerida.")]
        [Display(Name = "Fecha de cita")]
        public DateTime FechaCita { get; set; }

        [Required(ErrorMessage = "El numero de seguridad social es requerido.")]
        [Display(Name = "Numero de seguridad social")]
        public int Nss { get; set; }

        [Required(ErrorMessage = "La descripcion de los malestares es requerida.")]
        [Display(Name = "Descripcion de los malestares:")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El area es requerida.")]
        [Display(Name = "Area")]
        public int IdArea { get; set; }
        [Display(Name = "Medico a Cargo:")]
        public int IdMedico { get; set; }
        public int Estado { get; set; }
        public int Atendido { get; set; }
        public string Token { get; set; }
        public List<AreaModel> areas { get; set; }
    }
}
