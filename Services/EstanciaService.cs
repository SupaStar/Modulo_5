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
        public MensajeModel addEstancia(EstanciaModel estancia)
        {
            using (var context = new DbEntityContext())
            {
                context.estancias.Add(estancia);
                context.SaveChanges();
            }
            mensaje.Estado = true;
            return mensaje;
        }
        public EstanciaModel findEstancia(int id_estancia)
        {
            EstanciaModel estancia;
            using (var context = new DbEntityContext())
            {
                estancia = context.estancias.Where(estancia => estancia.id == id_estancia).Single();
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
        public List<EstanciaModel> getEstancia()
        {
            List<EstanciaModel> estancias;
            using (var context = new DbEntityContext())
            {
                estancias = context.estancias.ToList();
            }
            return estancias;
        }
    }
}
