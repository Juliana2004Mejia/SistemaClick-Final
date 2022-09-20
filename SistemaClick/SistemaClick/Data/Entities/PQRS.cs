using System.ComponentModel.DataAnnotations;
namespace SistemaClick.Data.Entities
{
    public class PQRS
    {
        [Key]
        public int PQRSId { get; set; }

        [Required(ErrorMessage = "Por favor ingresa la descripcion")]
        public string Descripcion { get; set; }

        /* llAVE FORRANEAS */
        [Display(Name = "Cliente", AutoGenerateFilter = false)]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
