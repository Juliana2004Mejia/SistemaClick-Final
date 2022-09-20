using System.ComponentModel.DataAnnotations;
namespace SistemaClick.Data.Entities
{
    public class TipoVivienda
    {
        [Key]
        public int TipoViviendaId { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el Nombre")]
        public string Nombre { get; set; }
    }
}
