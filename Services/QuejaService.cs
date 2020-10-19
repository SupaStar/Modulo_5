using Microsoft.Extensions.Configuration;
using Modulo_5.Controllers;
using Modulo_5.Models;
using Modulo_5.Services.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Modulo_5.Services
{
    public class QuejaService : IQueja
    {
        private List<UrgenciaModel> _urgenciasItems;
        private List<TipoQueja> _tiposQuejas;
        DbController conexion;
        private readonly IConfiguration _confi;

        public QuejaService(IConfiguration conf)
        {
            _confi = conf;
            _urgenciasItems = new List<UrgenciaModel>();
            _tiposQuejas = new List<TipoQueja>();
            conexion = new DbController();
            conexion.conectionString = _confi.GetValue<string>("ConnectionStrings:Default");
        }
        public List<TipoQueja> cargarTipos()
        {
            MySqlConnection conn = conexion.conectar();
            string sql = "SELECT * FROM tipo_queja WHERE estado=1";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sql;
            MySqlDataReader result = m.ExecuteReader();
            while (result.Read())
            {
                TipoQueja tipo = new TipoQueja();
                tipo.Id = Convert.ToInt32(result[0].ToString());
                tipo.Nombre = result[1].ToString();
                tipo.Estado = Convert.ToInt32(result[2].ToString());
                _tiposQuejas.Add(tipo);
            }
            return _tiposQuejas;
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
