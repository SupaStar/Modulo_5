using Modulo_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Services.Interfaces
{
    interface IQueja
    {
        public List<QuejaModel> GetQuejas();
        public MensajeModel AddQueja(QuejaModel quejaItem);
        public QuejaModel UpdateQueja(int id, QuejaModel quejaItem);
        public Boolean DeleteQueja(int id);
        public QuejaModel FindQueja(int id);
        public QuejaModel FindQuejaByToken(string token);
        public QuejaModel validateQueja(int idQ, int idE);
    }
}
