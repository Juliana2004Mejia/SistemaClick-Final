using System.ComponentModel.DataAnnotations;
namespace SistemaClick.Data.Entities
{
    public class Plan
    {
        [Key]
        public int PlanId { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el Nombre")]
        public string Nombre { get; set; }
    }
}
