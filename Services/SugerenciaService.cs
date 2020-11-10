using Microsoft.Extensions.Configuration;
using Modulo_5.Controllers;
using Modulo_5.Models;
using Modulo_5.Services.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Modulo_5.Services
{
    public class SugerenciaService : ISugerencia
    {
        private readonly List<SugerenciaModel> _sugerenciasItems;
        readonly DbController conexion;
        readonly Encriptador enc = new Encriptador();
        public SugerenciaService(IConfiguration conf)
        {
            _sugerenciasItems = new List<SugerenciaModel>();
            conexion = new DbController();
            conexion.ConectionString = conf.GetValue<string>("ConnectionStrings:Default");
        }

        public SugerenciaModel AddSugerencia(SugerenciaModel sugerenciaItem)
        {
            string paramHash = sugerenciaItem.Email + sugerenciaItem.Descripcion;
            sugerenciaItem.Token = enc.Hashing(paramHash);
            MySqlConnection conn = conexion.conectar();
            string sqlInsert = "INSERT INTO sugerencia VALUES(null,@p1,@p2,@p3,1)";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sqlInsert;
            m.Parameters.AddWithValue("@p1", sugerenciaItem.Email);
            m.Parameters.AddWithValue("@p2", sugerenciaItem.Descripcion);
            m.Parameters.AddWithValue("@p3", sugerenciaItem.Token);
            m.ExecuteNonQuery();
            conn.Close();
            return sugerenciaItem;
        }

        public bool DeleteSugerencia(int id)
        {
            MySqlConnection conn = conexion.conectar();
            string sql = "UPDATE SUGERENCIA SET estado=0 WHERE id=@p1";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sql;
            m.Parameters.AddWithValue("@p1", id);
            m.ExecuteNonQuery();
            Boolean estado = true;
            return estado;
        }

        public SugerenciaModel FindSugerencia(int id)
        {
            MySqlConnection conn = conexion.conectar();
            string sql = "SELECT * FROM SUGERENCIA WHERE id=@p1";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sql;
            m.Parameters.AddWithValue("@p1", id);
            MySqlDataReader result = m.ExecuteReader();
            SugerenciaModel sugerencia = new SugerenciaModel();
            while (result.Read())
            {
                sugerencia.Id = Convert.ToInt32(result[0].ToString());
                sugerencia.Email = result[1].ToString();
                sugerencia.Descripcion = result[2].ToString();
                sugerencia.Token = result[3].ToString();
                sugerencia.Estado = Convert.ToInt32(result[4].ToString());
            }
            return sugerencia;
        }

        public List<SugerenciaModel> GetSugerencias()
        {
            MySqlConnection conn = conexion.conectar();
            string sql = "SELECT * FROM SUGERENCIA WHERE estado=1";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sql;
            MySqlDataReader result = m.ExecuteReader();
            while (result.Read())
            {
                SugerenciaModel sugerencia = new SugerenciaModel();
                sugerencia.Id = Convert.ToInt32(result[0].ToString());
                sugerencia.Email = result[1].ToString();
                sugerencia.Descripcion = result[2].ToString();
                sugerencia.Token = result[3].ToString();
                sugerencia.Estado = Convert.ToInt32(result[4].ToString());
                this._sugerenciasItems.Add(sugerencia);
            }
            return _sugerenciasItems;
        }

        public SugerenciaModel UpdateSugerencia(int id, SugerenciaModel sugerenciaItem)
        {
            MySqlConnection conn = conexion.conectar();
            string sqlInsert = "UPDATE SUGERENCIA SET email=@p1,descripcion=@p2,estado=@p3 where id=@p4";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sqlInsert;
            m.Parameters.AddWithValue("@p1", sugerenciaItem.Email);
            m.Parameters.AddWithValue("@p2", sugerenciaItem.Descripcion);
            m.Parameters.AddWithValue("@p3", sugerenciaItem.Estado);
            m.Parameters.AddWithValue("@p4", id);
            m.ExecuteNonQuery();
            conn.Close();
            return sugerenciaItem;
        }

        public SugerenciaModel FindSugerenciaByToken(string token)
        {
            MySqlConnection conn = conexion.conectar();
            string sql = "SELECT * FROM sugerencia WHERE token=@p1";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sql;
            m.Parameters.AddWithValue("@p1", token);
            MySqlDataReader result = m.ExecuteReader();
            SugerenciaModel sugerencia = new SugerenciaModel();
            while (result.Read())
            {
                sugerencia.Id = Convert.ToInt32(result[0].ToString());
                sugerencia.Email = result[1].ToString();
                sugerencia.Descripcion = result[2].ToString();
                sugerencia.Token = result[3].ToString();
                sugerencia.Estado = Convert.ToInt32(result[4].ToString());
            }
            return sugerencia;
        }

        public SugerenciaModel validateSugerencia(int idS, int idE)
        {
            MySqlConnection conn = conexion.conectar();
            string sql = "INSERT INTO sugerencia_empleado VALUES(null,@p1,@p2)";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sql;
            m.Parameters.AddWithValue("@p1", idS);
            m.Parameters.AddWithValue("@p2", idE);
            m.ExecuteNonQuery();
            this.DeleteSugerencia(idS);
            SugerenciaModel sugerencia = this.FindSugerencia(idS);
            return sugerencia;
        }
    }
}
