using Modulo_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Services
{
    public class ObservacionesService
    {
        MensajeModel mensaje = new MensajeModel();
        public MensajeModel addObservacion(ObservacionModel observacion)
        {
            using (var context = new DbEntityContext())
            {
                context.observaciones.Add(observacion);
                context.SaveChanges();
            }
            mensaje.Estado = true;
            return mensaje;
        }
        public ObservacionModel findObservacion(int id_obs)
        {
            ObservacionModel observacion;
            using (var context = new DbEntityContext())
            {
                observacion = context.observaciones.Where(observacionB => observacionB.id == id_obs).Single();
            }
            return observacion;
        }
        public ObservacionModel updateObservacion(ObservacionModel observacionE)
        {
            ObservacionModel observacion;
            using (var context = new DbEntityContext())
            {
                observacion = context.observaciones.Where(observacionb => observacionb.id == observacionE.id).Single();
                observacion.observaciones = observacionE.observaciones;
                observacion.diagnostico = observacionE.diagnostico;
                observacion.receta = observacionE.receta;
                context.SaveChanges();
            }
            return observacion;
        }
        public List<ObservacionModel> getObservaciones()
        {
            List<ObservacionModel> observaciones;
            using (var context = new DbEntityContext())
            {
                observaciones = context.observaciones.ToList();
            }
            return observaciones;
        }
    }
}
