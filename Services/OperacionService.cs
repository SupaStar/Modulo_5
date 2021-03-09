using Modulo_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Services
{
    public class OperacionService
    {
        MensajeModel mensaje = new MensajeModel();
        public MensajeModel addOperacion(c operacion)
        {
            using (var context = new DbEntityContext())
            {
                context.operaciones.Add(operacion);
                context.SaveChanges();
            }
            mensaje.Estado = true;
            return mensaje;
        }
        public OperacionModel findOperacion(int id_ops)
        {
            OperacionModel operacion;
            using (var context = new DbEntityContext())
            {
                operacion = context.operaciones.Where(operacionb => operacionb.id == id_ops).Single();
            }
            return operacion;
        }
        public OperacionModel updateOperacion(OperacionModel operacionE)
        {
            OperacionModel operacion;
            using (var context = new DbEntityContext())
            {
                operacion = context.operaciones.Where(operaciobb => operaciobb.id == operacionE.id).Single();
                operacion.fecha_salida = operacion.fecha_salida;
                context.SaveChanges();
            }
            return operacion;
        }
        public List<OperacionModel> getOperaciones()
        {
            List<OperacionModel> operaciones;
            using (var context = new DbEntityContext())
            {
                operaciones = context.operaciones.ToList();
            }
            return operaciones;
        }
    }
}
