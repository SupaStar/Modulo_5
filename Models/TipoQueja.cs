using System.ComponentModel.DataAnnotations;

namespace Modulo_5.Models
{
    public class TipoQueja
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
    }
}
