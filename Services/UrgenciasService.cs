using Microsoft.Extensions.Configuration;
using Modulo_5.Controllers;
using Modulo_5.Models;
using Modulo_5.Services.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Modulo_5.Services
{
    public class UrgenciasService : IUrgencia
    {
        private readonly List<UrgenciaModel> _urgenciasItems;
        private readonly List<AreaModel> areas;
        private readonly List<EmpleadoModel> empleados;
        readonly DbController conexion;
        readonly Encriptador enc = new Encriptador();
        public UrgenciasService(IConfiguration conf)
        {
            _urgenciasItems = new List<UrgenciaModel>();
            areas = new List<AreaModel>();
            conexion = new DbController();
            empleados = new List<EmpleadoModel>();
            conexion.ConectionString = conf.GetValue<string>("ConnectionStrings:Default");
        }
        public List<AreaModel> getAreas()
        {
            MySqlConnection conn = conexion.conectar();
            string sql = "SELECT * FROM area WHERE estado=1";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sql;
            MySqlDataReader result = m.ExecuteReader();
            while (result.Read())
            {
                AreaModel area = new AreaModel();
                area.Id = Convert.ToInt32(result[0].ToString());
                area.Nombre = result[1].ToString();
                area.Estado = Convert.ToInt32(result[2].ToString());
                areas.Add(area);
            }
            return areas;
        }
        public List<EmpleadoModel> getEmpleados()
        {
            MySqlConnection conn = conexion.conectar();
            string sql = "SELECT * FROM empleado";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sql;
            MySqlDataReader result = m.ExecuteReader();
            while (result.Read())
            {
                EmpleadoModel empleado = new EmpleadoModel();
                empleado.Id = Convert.ToInt32(result[0].ToString());
                empleado.Nombre = result[1].ToString();
                empleado.Ap_paterno = result[2].ToString();
                empleado.Ap_materno = result[3].ToString();
                empleado.Correo = result[4].ToString();
                empleado.Num_cel = result[5].ToString();
                empleado.Num_cuenta = result[6].ToString();
                empleados.Add(empleado);
            }
            return empleados;
        }

        public UrgenciaModel AddUrgencia(UrgenciaModel urgenciaItem)
        {
            string paramHash = urgenciaItem.Nombre + urgenciaItem.Fecha_nac.ToString() + urgenciaItem.Descripcion;
            urgenciaItem.Token = enc.Hashing(paramHash);
            MySqlConnection conn = conexion.conectar();
            string sqlInsert = "INSERT INTO urgencia VALUES(null,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,1,1,@p11,@p12)";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sqlInsert;
            m.Parameters.AddWithValue("@p1", urgenciaItem.Nombre);
            m.Parameters.AddWithValue("@p2", urgenciaItem.Ap_paterno);
            m.Parameters.AddWithValue("@p3", urgenciaItem.Ap_materno);
            m.Parameters.AddWithValue("@p4", urgenciaItem.Telefono);
            m.Parameters.AddWithValue("@p5", urgenciaItem.TelefonoF);
            m.Parameters.AddWithValue("@p6", urgenciaItem.Email);
            m.Parameters.AddWithValue("@p7", urgenciaItem.Fecha_nac);
            m.Parameters.AddWithValue("@p8", urgenciaItem.Nss);
            m.Parameters.AddWithValue("@p9", urgenciaItem.Descripcion);
            m.Parameters.AddWithValue("@p10", urgenciaItem.Token);
            m.Parameters.AddWithValue("@p11", urgenciaItem.IdArea);
            m.Parameters.AddWithValue("@p12", urgenciaItem.FechaCita);
            m.ExecuteNonQuery();
            conn.Close();
            return urgenciaItem;
        }

        public Boolean DeleteUrgencia(int id)
        {
            MySqlConnection conn = conexion.conectar();
            string sql = "UPDATE URGENCIA SET estado=0 WHERE id=@p1";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sql;
            m.Parameters.AddWithValue("@p1", id);
            m.ExecuteNonQuery();
            Boolean estado = true;
            return estado;
        }

        public UrgenciaModel FindUrgencia(int id)
        {
            MySqlConnection conn = conexion.conectar();
            string sql = "SELECT * FROM URGENCIA WHERE id=@p1";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sql;
            m.Parameters.AddWithValue("@p1", id);
            MySqlDataReader result = m.ExecuteReader();
            UrgenciaModel urgencia = new UrgenciaModel();
            while (result.Read())
            {
                urgencia.Id = Convert.ToInt32(result[0].ToString());
                urgencia.Nombre = result[1].ToString();
                urgencia.Ap_paterno = result[2].ToString();
                urgencia.Ap_materno = result[3].ToString();
                urgencia.Telefono = result[4].ToString();
                urgencia.TelefonoF = result[5].ToString();
                urgencia.Email = result[6].ToString();
                urgencia.Fecha_nac = Convert.ToDateTime(result[7]);
                urgencia.Nss = Convert.ToInt32(result[8].ToString());
                urgencia.Descripcion = result[9].ToString();
                urgencia.Token = result[10].ToString();
                urgencia.Atendido = Convert.ToInt32(result[11].ToString());
                urgencia.Estado = Convert.ToInt32(result[12].ToString());
                urgencia.IdArea = Convert.ToInt32(result[13].ToString());
                urgencia.FechaCita = Convert.ToDateTime(result[14]);
            }
            return urgencia;
        }

        public List<UrgenciaModel> GetUrgencias()
        {
            MySqlConnection conn = conexion.conectar();
            string sql = "SELECT * FROM URGENCIA WHERE estado=1 AND atendido=1";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sql;
            MySqlDataReader result = m.ExecuteReader();
            while (result.Read())
            {
                UrgenciaModel urgencia = new UrgenciaModel();
                urgencia.Id = Convert.ToInt32(result[0].ToString());
                urgencia.Nombre = result[1].ToString();
                urgencia.Ap_paterno = result[2].ToString();
                urgencia.Ap_materno = result[3].ToString();
                urgencia.Telefono = result[4].ToString();
                urgencia.TelefonoF = result[5].ToString();
                urgencia.Email = result[6].ToString();
                urgencia.Fecha_nac = Convert.ToDateTime(result[7]);
                urgencia.Nss = Convert.ToInt32(result[8].ToString());
                urgencia.Descripcion = result[9].ToString();
                urgencia.Token = result[10].ToString();
                urgencia.Atendido = Convert.ToInt32(result[11].ToString());
                urgencia.Estado = Convert.ToInt32(result[12].ToString());
                urgencia.IdArea = Convert.ToInt32(result[13].ToString());
                urgencia.FechaCita = Convert.ToDateTime(result[14]);
                this._urgenciasItems.Add(urgencia);
            }
            return _urgenciasItems;
        }

        public UrgenciaModel UpdateUrgencia(int id, UrgenciaModel urgenciaItem)
        {
            MySqlConnection conn = conexion.conectar();
            string sqlInsert = "UPDATE urgencia SET nombre=@p1,ap_paterno=@p2,ap_materno=@p3,telefono=@p4,telefonoF=@p5," +
                "email=@p6,fecha_nac=@p7,nss=@p8,descripcion=@p9,atendido=@p10,id_area=@p11, estado=0,id_area=@p12,fechaCita=@p13 " +
                "where id=@p13";


            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sqlInsert;
            m.Parameters.AddWithValue("@p1", urgenciaItem.Nombre);
            m.Parameters.AddWithValue("@p2", urgenciaItem.Ap_paterno);
            m.Parameters.AddWithValue("@p3", urgenciaItem.Ap_materno);
            m.Parameters.AddWithValue("@p4", urgenciaItem.Telefono);
            m.Parameters.AddWithValue("@p5", urgenciaItem.TelefonoF);
            m.Parameters.AddWithValue("@p6", urgenciaItem.Email);
            m.Parameters.AddWithValue("@p7", urgenciaItem.Fecha_nac);
            m.Parameters.AddWithValue("@p8", urgenciaItem.Nss);
            m.Parameters.AddWithValue("@p9", urgenciaItem.Descripcion);
            m.Parameters.AddWithValue("@p10", urgenciaItem.Atendido);
            m.Parameters.AddWithValue("@p11", urgenciaItem.Estado);
            m.Parameters.AddWithValue("@p12", urgenciaItem.IdArea);
            m.Parameters.AddWithValue("@p13", urgenciaItem.FechaCita);
            m.Parameters.AddWithValue("@p14", id);

            m.ExecuteNonQuery();
            conn.Close();
            return urgenciaItem;
        }
        public UrgenciaModel ViewUrgencia(string token)
        {
            MySqlConnection conn = conexion.conectar();
            string sql = "SELECT * FROM URGENCIA WHERE token=@p1";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sql;
            m.Parameters.AddWithValue("@p1", token);
            MySqlDataReader result = m.ExecuteReader();
            UrgenciaModel urgencia = new UrgenciaModel();
            while (result.Read())
            {
                urgencia.Id = Convert.ToInt32(result[0].ToString());
                urgencia.Nombre = result[1].ToString();
                urgencia.Ap_paterno = result[2].ToString();
                urgencia.Ap_materno = result[3].ToString();
                urgencia.Telefono = result[4].ToString();
                urgencia.TelefonoF = result[5].ToString();
                urgencia.Email = result[6].ToString();
                urgencia.Fecha_nac = Convert.ToDateTime(result[7]);
                urgencia.Nss = Convert.ToInt32(result[8].ToString());
                urgencia.Descripcion = result[9].ToString();
                urgencia.Token = result[10].ToString();
                urgencia.Atendido = Convert.ToInt32(result[11].ToString());
                urgencia.Estado = Convert.ToInt32(result[12].ToString());
                urgencia.IdArea = Convert.ToInt32(result[13].ToString());
                urgencia.Fecha_nac = Convert.ToDateTime(result[14]);

            }
            return urgencia;
        }

        public UrgenciaModel validateUrgencia(int idU, int idE)
        {
            MySqlConnection conn = conexion.conectar();
            string sql = "INSERT INTO urgencias_empleado VALUES(null,@p1,@p2)";
            MySqlCommand m = conn.CreateCommand();
            m.CommandText = sql;
            m.Parameters.AddWithValue("@p1", idU);
            m.Parameters.AddWithValue("@p2", idE);
            m.ExecuteNonQuery();
            this.DeleteUrgencia(idU);
            UrgenciaModel urgencia = this.FindUrgencia(idU);
            return urgencia;
        }
    }
}
