using System.ComponentModel.DataAnnotations;
namespace SistemaClick.Data.Entities
{
    public class Localidad
    {
        [Key]
        public int LocalidadId { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el Nombre")]
        public string Nombre { get; set; }
    }
}
