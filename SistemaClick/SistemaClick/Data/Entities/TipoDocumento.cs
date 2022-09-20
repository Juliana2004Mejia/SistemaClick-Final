using System.ComponentModel.DataAnnotations;
namespace SistemaClick.Data.Entities
{
    public class TipoDocumento
    {
        [Key]
        public int TipoDocumentoId { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el Nombre")]
        public string Nombre { get; set; }
    }
}
