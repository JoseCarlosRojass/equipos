using Npgsql.Replication;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Seguro
    {
        [Key]
        public string? idSeguro { get; set; }
        public string? Tipo { get; set;}
        public string? Importe { get; set; }
        public DateTime? FechaImporte { get; set; }
    }
}
