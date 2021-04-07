using Modulo_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Services
{
    public class UsuarioPacienteService
    {
        readonly Encriptador enc = new Encriptador();
        public UsuariosPacienteModel addUsuario(int idE)
        {
            UsuariosPacienteModel usuario = new UsuariosPacienteModel();
            usuario.id_estancia = idE;
            usuario.usuario = "UsuarioPaciente" + idE;
            usuario.password = enc.Hashing("12345" + idE);
            using (var context = new DbEntityContext())
            {
                context.usuarios_paciente.Add(usuario);
                context.SaveChanges();
            }
            return usuario;
        }
        public UsuariosPacienteModel login(UsuariosPacienteModel usuario)
        {
            UsuariosPacienteModel respuesta = new UsuariosPacienteModel();
            using (var context = new DbEntityContext())
            {
                respuesta = context.usuarios_paciente.Where(usuariobd => usuariobd.usuario == usuario.usuario).SingleOrDefault();
                if (respuesta != null)
                {
                    respuesta = context.usuarios_paciente.Where(usuariobd => usuariobd.password == usuario.password).SingleOrDefault();
                }
            }
            return respuesta;
        }
    }
}
