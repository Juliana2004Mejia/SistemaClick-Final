using System.ComponentModel.DataAnnotations;
namespace SistemaClick.Data.Entities
{
    public class Recoleccion
    {
        [Key]
        public int RecoleccionId { get; set; }

        [Required(ErrorMessage = "Por favor ingresa la direcciòn")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Por favor ingresa la direcciòn")]
        [Display(Name = "Destino de la recolecciòn", AutoGenerateFilter = false)]
        public string Direccion_cliente { get; set; }

        [Required(ErrorMessage = "Por favor ingresa la direcciòn"), MaxLength(10000)]
        public string Objetivo { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el nombre"), MaxLength(30)]
        [Display(Name = "Nombre del cliente encargado", AutoGenerateFilter = false)]
        public string Nombre_cliente { get; set; }

        [Required(ErrorMessage = "Por favor ingresa la hora en que llego"), MaxLength(30)]
        [Display(Name = "Hora de llegada", AutoGenerateFilter = false)]
        public DateTime Hora_llegada { get; set; }


        /*Llaves Foraneas*/

        [Display(Name = "Empleado", AutoGenerateFilter = false)]
        public int EmpleadoId { get; set; }
        public Empleado? Empleado { get; set; }

        [Display(Name = "Localidad", AutoGenerateFilter = false)]
        public int LocalidadId { get; set; }
        public Localidad? Localidad { get; set; }


    }
}
