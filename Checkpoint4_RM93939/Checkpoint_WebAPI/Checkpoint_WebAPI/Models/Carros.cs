using System.ComponentModel.DataAnnotations;

namespace Checkpoint_WebAPI.Models
{
    public class Carros
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public string Cor { get; set; }

        [Required]
        public double Preco { get; set; }

      
    }
}
