using MySql.Data.MySqlClient;

namespace Modulo_5.Controllers
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
