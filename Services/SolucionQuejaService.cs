using Modulo_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Services
{
    public class SolucionQuejaService
    {
        MensajeModel mensaje = new MensajeModel();
        public MensajeModel addSolucion(SolucionQuejaModel solucion)
        {
            using (var context = new DbEntityContext())
            {
                context.soluciones.Add(solucion);
                context.SaveChanges();
            }
            mensaje.Estado = true;
            return mensaje;
        }
        public SolucionQuejaModel findSolucion(int id_solucion)
        {
            SolucionQuejaModel solucion;
            using (var context = new DbEntityContext())
            {
                solucion = context.soluciones.Where(solucion => solucion.id == id_solucion).Single();
            }
            return solucion;
        }
        public SolucionQuejaModel updateSolucion(SolucionQuejaModel solucionE)
        {
            SolucionQuejaModel solucion;
            using (var context = new DbEntityContext())
            {
                solucion = context.soluciones.Where(solucion => solucion.id == solucionE.id).Single();
                solucion.solucion = solucionE.solucion;
                context.SaveChanges();
            }
            return solucion;
        }
        public List<SolucionQuejaModel> getSolucion()
        {
            List<SolucionQuejaModel> soluciones;
            using (var context = new DbEntityContext())
            {
                soluciones = context.soluciones.ToList();
            }
            return soluciones;
        }
    }
}
