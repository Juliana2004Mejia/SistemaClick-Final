using System.ComponentModel.DataAnnotations;
namespace SistemaClick.Data.Entities
{
    public class UnidadMedida
    {
        [Key]
        public int UnidadMedidaId { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el Nombre")]
        public string Nombre { get; set; }
    }
}
