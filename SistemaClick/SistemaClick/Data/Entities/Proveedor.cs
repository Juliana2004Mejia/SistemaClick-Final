using System.ComponentModel.DataAnnotations;
namespace SistemaClick.Data.Entities
{
    public class Proveedor
    {
        [Key]
        public int ProveedorId { get; set; }


        [Required(ErrorMessage = "Por favor ingresa el nombre"), MaxLength(30)]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Por favor ingresa el apellido"), MaxLength(30)]
        public string Apellido { get; set; }

        [Display(Name = "Tipo persona", AutoGenerateFilter = false)]
        public string Tipo_persona { get; set; }


        [Required(ErrorMessage = "Por favor ingresa la direcciòn")]
        public string Direccion { get; set; }


        [Required(ErrorMessage = "Por favor ingresa el email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Por favor ingresa el telefono")]
        [DataType(DataType.PhoneNumber)]
        public double Telefono { get; set; }

        [Display(Name = "Nombre del producto", AutoGenerateFilter = false)]
        public string Nombre_producto { get; set; }

        /*Llaves Foraneas*/
       
    }
}
