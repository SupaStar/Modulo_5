using Modulo_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Services
{
    public class EstanciaService
    {
        MensajeModel mensaje = new MensajeModel();
        PacienteService _paciente = new PacienteService();
        public EstanciaModel addEstancia(EstanciaModel estancia)
        {
            using (var context = new DbEntityContext())
            {
                context.estancias.Add(estancia);
                context.SaveChanges();
            }
            return estancia;
        }
        public EstanciaModel findEstancia(int id_estancia)
        {
            EstanciaModel estancia;
            using (var context = new DbEntityContext())
            {
                estancia = context.estancias.Where(estancia => estancia.id == id_estancia).Single();
                estancia.paciente = _paciente.findPaciente(estancia.id_paciente);
            }
            return estancia;
        }
        public EstanciaModel updateEstancia(EstanciaModel estanciaE)
        {
            EstanciaModel estancia;
            using (var context = new DbEntityContext())
            {
                estancia = context.estancias.Where(estancia => estancia.id == estancia.id).Single();
                estancia.piso = estanciaE.piso;
                estancia.cama = estanciaE.cama;
                context.SaveChanges();
            }
            return estancia;
        }
        public List<EstanciaModel> getEstancias()
        {
            List<EstanciaModel> estancias;
            using (var context = new DbEntityContext())
            {
                estancias = context.estancias.ToList();
                foreach(EstanciaModel estancia in estancias)
                {
                    estancia.paciente = _paciente.findPaciente(estancia.id_paciente);
                }
            }
            return estancias;
        }
        public List<OperacionModel> getOperaciones(int id_estanciaE)
        {
            List<OperacionModel> operaciones;
            using (var context = new DbEntityContext())
            {
                operaciones = context.operaciones.Where(operacion => operacion.id_estancia == id_estanciaE).ToList();
            }
            return operaciones;
        }
        public List<UsuariosPacienteModel> getUsuarios(int id_estanciaE)
        {
            List<UsuariosPacienteModel> usuarios;
            using (var context = new DbEntityContext())
            {
                usuarios = context.usuarios_paciente.Where(usuario => usuario.id_estancia == id_estanciaE).ToList();
                //var query = from e in context.estancias
                //            join es in context.usuarios_paciente on e.id equals es.id_estancia
                //            select new
                //            {
                //                idE = e.id,
                //                piso = e.piso,
                //                cama = e.cama,
                //                usuario = es.usuario,
                //                password = es.password
                //            };
                //return new { estado = true, detalle = query.ToList() };
            }
            return usuarios;
        }
        public List<ObservacionModel> getObservaciones(int id_estanciaE)
        {
            List<ObservacionModel> observaciones;
            using (var context = new DbEntityContext())
            {
                observaciones = context.observaciones.Where(observacion => observacion.id_estancia == id_estanciaE).ToList();
            }
            return observaciones;
        }
    }
}
