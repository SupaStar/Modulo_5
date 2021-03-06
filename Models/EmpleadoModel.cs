﻿using System.ComponentModel.DataAnnotations;

namespace Modulo_5.Models
{
    public class EmpleadoModel
    {
        [Key]
        [Display(Name = "Medico a cargo")]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ap_paterno { get; set; }
        public string Ap_materno { get; set; }
        public string Correo { get; set; }
        public string Num_cel { get; set; }
        public string Num_cuenta { get; set; }
        public string Direccion { get; set; }
    }
}
