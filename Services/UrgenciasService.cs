using Microsoft.Extensions.Configuration;
using Modulo_5.Models;
using Modulo_5.Services.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Services
{
    public class UrgenciasService : IUrgencia
    {
        private List<UrgenciaModel> _urgenciasItems;
        DbController conexion;
        private readonly IConfiguration _confi;
        public UrgenciasService(IConfiguration conf)
        {
            _confi = conf;
            _urgenciasItems = new List<UrgenciaModel>();
            conexion = new DbController();
            conexion.conectionString = _confi.GetValue<string>("ConnectionStrings:Default");
        }

        public UrgenciaModel AddUrgencia(UrgenciaModel urgenciaItem)
        {
            MySqlConnection conn = conexion.conectar();
            string sqlInsert = "INSERT INTO urgencias(Id,nombre,fecha_nac,email,idArea,telefono,telefonoF,nss,descripcion) VALUES(null,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sqlInsert;
            m.Parameters.AddWithValue("@p1", urgenciaItem.Nombre);
            m.Parameters.AddWithValue("@p2", urgenciaItem.FechaNac);
            m.Parameters.AddWithValue("@p3", urgenciaItem.Email);
            m.Parameters.AddWithValue("@p4", urgenciaItem.IdArea);
            m.Parameters.AddWithValue("@p5", urgenciaItem.Telefono);
            m.Parameters.AddWithValue("@p6", urgenciaItem.TelefonoF);
            m.Parameters.AddWithValue("@p7", urgenciaItem.Nss);
            m.Parameters.AddWithValue("@p8", urgenciaItem.Descripcion);
            m.ExecuteNonQuery();
            conn.Close();
            return urgenciaItem;
        }

        public UrgenciaModel DeleteUrgencia(int id)
        {
            throw new NotImplementedException();
        }

        public UrgenciaModel FindUrgencia(int id)
        {
            MySqlConnection conn = conexion.conectar();
            string sql = "SELECT * FROM URGENCIAS WHERE id=@p1";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sql;
            m.Parameters.AddWithValue("@p1", id);
            MySqlDataReader result = m.ExecuteReader();
            UrgenciaModel urgencia = new UrgenciaModel();
            while (result.Read())
            {
                urgencia.Id = Convert.ToInt32(result[0].ToString());
                urgencia.Nombre = result[1].ToString();
                urgencia.FechaNac = Convert.ToDateTime(result[2]);
                urgencia.Email = result[3].ToString();
                urgencia.IdArea = Convert.ToInt32(result[4].ToString());
                urgencia.Telefono = Convert.ToInt32(result[5].ToString());
                urgencia.TelefonoF = Convert.ToInt32(result[6].ToString());
                urgencia.Nss = Convert.ToInt32(result[7].ToString());
                urgencia.Descripcion = result[8].ToString();
                urgencia.Estado = Convert.ToInt32(result[9].ToString());
            }
            return urgencia;
        }

        public List<UrgenciaModel> GetUrgencias()
        {
            MySqlConnection conn = conexion.conectar();
            string sql = "SELECT * FROM URGENCIAS WHERE estado=0";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sql;
            MySqlDataReader result = m.ExecuteReader();
            while (result.Read())
            {
                UrgenciaModel urgencia = new UrgenciaModel();
                urgencia.Id = Convert.ToInt32(result[0].ToString());
                urgencia.Nombre = result[1].ToString();
                urgencia.FechaNac = Convert.ToDateTime(result[2]);
                urgencia.Email = result[3].ToString();
                urgencia.IdArea = Convert.ToInt32(result[4].ToString());
                urgencia.Telefono = Convert.ToInt32(result[5].ToString());
                urgencia.TelefonoF = Convert.ToInt32(result[6].ToString());
                urgencia.Nss = Convert.ToInt32(result[7].ToString());
                urgencia.Descripcion = result[8].ToString();
                urgencia.Estado = Convert.ToInt32(result[9].ToString());
                this._urgenciasItems.Add(urgencia);
            }
            return _urgenciasItems;
        }

        public UrgenciaModel UpdateUrgencia(string id, UrgenciaModel urgenciaItem)
        {
            throw new NotImplementedException();
        }
    }
}
