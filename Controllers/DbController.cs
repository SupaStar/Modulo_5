using MySql.Data.MySqlClient;

namespace Modulo_5.Controllers
{
    public class DbController
    {
        public string ConectionString { get; set; }
        public MySqlConnection Conn { get; set; }

        public DbController()
        {

        }
        public MySqlConnection conectar()
        {
            Conn = new MySqlConnection(ConectionString);
            Conn.Open();
            return this.Conn;
        }
        public void desconectar()
        {
            this.Conn.Close();
        }
    }
}
