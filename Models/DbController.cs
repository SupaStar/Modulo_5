using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Modulo_5.Models
{
    public class DbController
    {
        
        public string conectionString;
        private MySqlConnection conn;

        public DbController()
        {
            
        }

        public MySqlConnection conectar()
        {
            conn = new MySqlConnection(conectionString);
            conn.Open();
            return this.conn;
        }
        public void desconectar()
        {
            this.conn.Close();
        }
    }
}
