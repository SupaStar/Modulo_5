using Modulo_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Services.Interfaces
{
    interface IUrgencia
    {
        public List<UrgenciaModel> GetUrgencias();

        public UrgenciaModel AddUrgencia(UrgenciaModel urgenciaItem);

        public UrgenciaModel UpdateUrgencia(int id, UrgenciaModel urgenciaItem);

        public Boolean DeleteUrgencia(int id);

        public UrgenciaModel FindUrgencia(int id);
        public UrgenciaModel validateUrgencia(int idU, int idE);
    }
}
