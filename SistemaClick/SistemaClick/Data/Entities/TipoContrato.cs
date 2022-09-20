using System.ComponentModel.DataAnnotations;
namespace SistemaClick.Data.Entities
{
    public class TipoContrato
    {
        [Key]
        public int TipoContratoId { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el Nombre")]
        public string Nombre { get; set; }
    }
}
