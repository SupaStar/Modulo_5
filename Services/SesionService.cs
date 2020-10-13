using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Modulo_5.Controllers;
using Modulo_5.Models;
using Modulo_5.Services.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Modulo_5.Services
{
    public class SesionService : IUsuario
    {
        DbController conexion;

        public SesionService(IConfiguration conf)
        {
            this.conexion = new DbController();
            conexion.conectionString = conf.GetValue<string>("ConnectionStrings:Default");
        }

        public bool IniciarSesion(UsuarioModel usuario)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                MySqlConnection conn = conexion.conectar();
                string sql = "Select * from usuario where correo=@p1";
                MySqlCommand m = conn.CreateCommand();
                m.CommandText = sql;
                m.Parameters.AddWithValue("@p1", usuario.Correo);
                MySqlDataReader result = m.ExecuteReader();
                if (result.HasRows)
                {
                    var dbHash = "";
                    while (result.Read())
                    {
                        dbHash = result[2].ToString();
                    }
                    if (VerifyHash(sha256Hash, usuario.Password, dbHash))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
        }
        private static string Hashing(HashAlgorithm hashAlgorithm, string input)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            var hashOfInput = Hashing(hashAlgorithm, input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }

}
