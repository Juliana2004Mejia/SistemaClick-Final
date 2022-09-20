using System.ComponentModel.DataAnnotations;
namespace SistemaClick.Data.Entities
{
    public class Cargo
    {
        [Key]
        public int CargoId { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el Nombre")]
        public string Nombre { get; set; }
    }
}
