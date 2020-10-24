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
        private List<QuejaModel> _quejasItems;
        private List<TipoQueja> _tiposQuejas;
        DbController conexion;
        Encriptador enc = new Encriptador();
        private readonly IConfiguration _confi;
        private SugerenciaService _sugS;
        private MensajeModel mensaje = new MensajeModel();
        public QuejaService(IConfiguration conf)
        {
            _confi = conf;
            _quejasItems = new List<QuejaModel>();
            _tiposQuejas = new List<TipoQueja>();
            conexion = new DbController();
            _sugS = new SugerenciaService(this._confi);
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
        public MensajeModel AddQueja(QuejaModel quejaItem)
        {
            SugerenciaModel sugN = _sugS.FindSugerencia(quejaItem.Id_urgencia);
            if (sugN.Id != 0)
            {
                string paramHash = quejaItem.Email + quejaItem.Descripcion;
                quejaItem.Token = enc.Hashing(paramHash);
                MySqlConnection conn = conexion.conectar();
                string sqlInsert = "INSERT INTO queja VALUES(null,@p1,@p2,@p3,@p4,@p5,1)";
                MySqlCommand m = conn.CreateCommand();
                m.CommandText = sqlInsert;
                m.Parameters.AddWithValue("@p1", quejaItem.Id_urgencia);
                m.Parameters.AddWithValue("@p2", quejaItem.Email);
                m.Parameters.AddWithValue("@p3", quejaItem.Id_tipo_queja);
                m.Parameters.AddWithValue("@p4", quejaItem.Descripcion);
                m.Parameters.AddWithValue("@p5", quejaItem.Token);
                m.ExecuteNonQuery();
                conn.Close();
                mensaje.Estado = true;
            }
            else
            {
                mensaje.Estado = false;
                mensaje.Detalle = "La urgencia no existe";
            }
            return mensaje;
        }

        public bool DeleteQueja(int id)
        {
            MySqlConnection conn = conexion.conectar();
            string sql = "UPDATE queja SET estado=0 WHERE id=@p1";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sql;
            m.Parameters.AddWithValue("@p1", id);
            m.ExecuteNonQuery();
            Boolean estado = true;
            return estado;
        }

        public QuejaModel FindQueja(int id)
        {
            MySqlConnection conn = conexion.conectar();
            string sql = "SELECT * FROM queja WHERE id=@p1";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sql;
            m.Parameters.AddWithValue("@p1", id);
            MySqlDataReader result = m.ExecuteReader();
            QuejaModel queja = new QuejaModel();
            while (result.Read())
            {
                queja.Id = Convert.ToInt32(result[0].ToString());
                queja.Id_urgencia = Convert.ToInt32(result[1].ToString());
                queja.Email = result[2].ToString();
                queja.Id_tipo_queja = Convert.ToInt32(result[3].ToString());
                queja.Descripcion = result[4].ToString();
                queja.Token = result[5].ToString();
                queja.Estado = Convert.ToInt32(result[6].ToString());
            }
            return queja;
        }

        public List<QuejaModel> GetQuejas()
        {
            MySqlConnection conn = conexion.conectar();
            string sql = "SELECT * FROM Queja WHERE estado=1";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sql;
            MySqlDataReader result = m.ExecuteReader();
            while (result.Read())
            {
                QuejaModel queja = new QuejaModel();
                queja.Id = Convert.ToInt32(result[0].ToString());
                queja.Id_urgencia = Convert.ToInt32(result[1].ToString());
                queja.Email = result[2].ToString();
                queja.Id_tipo_queja = Convert.ToInt32(result[3].ToString());
                queja.Descripcion = result[4].ToString();
                queja.Token = result[5].ToString();
                queja.Estado = Convert.ToInt32(result[6].ToString());
                this._quejasItems.Add(queja);
            }
            return _quejasItems;
        }

        public QuejaModel UpdateQueja(int id, QuejaModel quejaItem)
        {
            throw new NotImplementedException();
        }

        public QuejaModel FindQuejaByToken(string token)
        {
            MySqlConnection conn = conexion.conectar();
            string sql = "SELECT * FROM queja WHERE token=@p1";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sql;
            m.Parameters.AddWithValue("@p1", token);
            MySqlDataReader result = m.ExecuteReader();
            QuejaModel queja = new QuejaModel();
            while (result.Read())
            {
                queja.Id = Convert.ToInt32(result[0].ToString());
                queja.Id_urgencia = Convert.ToInt32(result[1].ToString());
                queja.Email = result[2].ToString();
                queja.Id_tipo_queja = Convert.ToInt32(result[3].ToString());
                queja.Descripcion = result[4].ToString();
                queja.Token = result[5].ToString();
                queja.Estado = Convert.ToInt32(result[6].ToString());
            }
            return queja;
        }
        public bool validateQueja(int idQ, int idE)
        {
            MySqlConnection conn = conexion.conectar();
            string sql = "INSERT INTO queja_empleado VALUES(null,@p1,@p2)";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sql;
            m.Parameters.AddWithValue("@p1", idQ);
            m.Parameters.AddWithValue("@p2", idE);
            m.ExecuteNonQuery();
            Boolean estado = true;
            this.DeleteQueja(idQ);
            return estado;
        }
    }
}
