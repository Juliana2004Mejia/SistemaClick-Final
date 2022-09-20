
using System.ComponentModel.DataAnnotations;

namespace SistemaClick.Data.Entities
{
    public class EPS
    {
        [Key]
        public int EPSId { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el Nombre")]
        public string Nombre { get; set; }
    }
}
