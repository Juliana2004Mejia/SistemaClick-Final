using System.ComponentModel.DataAnnotations;

namespace SistemaClick.Data.Entities
{
    public class CCF
    {
        [Key]
        public int CCFId { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el Nombre")]
        public string Nombre { get; set; }
    }
}
