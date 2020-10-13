using Modulo_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Services.Interfaces
{
    interface IUsuario
    {
        public bool IniciarSesion(UsuarioModel usuario);
    }
}
