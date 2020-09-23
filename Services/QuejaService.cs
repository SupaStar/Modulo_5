using Microsoft.Extensions.Configuration;
using Modulo_5.Models;
using Modulo_5.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Services
{
    public class QuejaService : IQueja
    {
        private List<UrgenciaModel> _urgenciasItems;
        DbController conexion;
        private readonly IConfiguration _confi;

        public QuejaService(IConfiguration conf)
        {
            _confi = conf;
            _urgenciasItems = new List<UrgenciaModel>();
            conexion = new DbController();
            conexion.conectionString = _confi.GetValue<string>("ConnectionStrings:Default");
        }

        public QuejaModel AddQueja(QuejaModel quejaItem)
        {
            throw new NotImplementedException();
        }

        public bool DeleteQueja(int id)
        {
            throw new NotImplementedException();
        }

        public QuejaModel FindQueja(int id)
        {
            throw new NotImplementedException();
        }

        public List<QuejaModel> GetQuejas()
        {
            throw new NotImplementedException();
        }

        public QuejaModel UpdateQueja(int id, QuejaModel quejaItem)
        {
            throw new NotImplementedException();
        }
    }
}
