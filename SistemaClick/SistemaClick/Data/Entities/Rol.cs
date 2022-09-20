using System.ComponentModel.DataAnnotations;
namespace SistemaClick.Data.Entities
{
    public class Rol
    {
        [Key]
        public int RolId { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el Nombre del rol")]
        public string Nombre { get; set; }

    }
}
