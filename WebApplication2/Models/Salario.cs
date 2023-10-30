using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Salario
    {
        [Key]
        public int idSalario { get; set; }
        public string salario { get; set; }
        public string FechaInicio { get; set; }
    }
}