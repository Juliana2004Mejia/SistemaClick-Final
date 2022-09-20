using System.ComponentModel.DataAnnotations;

namespace SistemaClick.Data.Entities
{
    public class ARL
    {
        [Key]
        public int ARLId { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el Nombre")]
        public string Nombre { get; set; }
    }
}
