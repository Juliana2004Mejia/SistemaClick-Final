using System.ComponentModel.DataAnnotations;

namespace SistemaClick.Data.Entities
{
    public class AFP
    {
        [Key]
        public int AFPId { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el Nombre")]
        public string Nombre { get; set; }
    }
}
