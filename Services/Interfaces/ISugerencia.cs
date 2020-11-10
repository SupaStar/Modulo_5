using Modulo_5.Models;
using System;
using System.Collections.Generic;

namespace Modulo_5.Services.Interfaces
{
    interface ISugerencia
    {
        public List<SugerenciaModel> GetSugerencias();
        public SugerenciaModel AddSugerencia(SugerenciaModel sugerenciaItem);
        public SugerenciaModel UpdateSugerencia(int id, SugerenciaModel sugerenciaItem);
        public Boolean DeleteSugerencia(int id);
        public SugerenciaModel validateSugerencia(int idS, int idE);
        public SugerenciaModel FindSugerencia(int id);
        public SugerenciaModel FindSugerenciaByToken(string token);
    }
}
