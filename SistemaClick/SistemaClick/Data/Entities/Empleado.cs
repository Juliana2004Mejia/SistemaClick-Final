using System.ComponentModel.DataAnnotations;

namespace SistemaClick.Data.Entities
{
    public class Empleado
    {
        [Key]
        public int EmpleadoId { get; set; }

        [Required(ErrorMessage = "Por favor ingresa tu email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor ingresar el nombre"), MaxLength(30)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el apellido"), MaxLength(30)]
        public string Apellido { get; set; }
        public int Numero_documento { get; set; }

        [Required(ErrorMessage = "Por favor ingresa telefono")]
        [DataType(DataType.PhoneNumber)]
        public double Telefono { get; set; }


        [Required(ErrorMessage = "Por favor ingresa la direcciòn"), MaxLength(30)]
        public string Direccion { get; set; }

        [Range(1000000, 10000000, ErrorMessage = "Por favor ingresa un salario entre el rango")]
        public double Salario { get; set; }

        /*LLAVES FORANEAS*/

        [Display(Name = "Cargo", AutoGenerateFilter = false)]
        public int CargoId { get; set; }
        public Cargo? Cargo { get; set; }

        [Display(Name = "Tipo de Contrato", AutoGenerateFilter = false)]
        public int TipoContratoId { get; set; }
        public TipoContrato? TipoContrato { get; set; }

        [Display(Name = "Rol", AutoGenerateFilter = false)]
        public int RolId { get; set; }
        public Rol? Rol { get; set; }

        [Display(Name = "Tipo Documento", AutoGenerateFilter = false)]
        public int TipoDocumentoId { get; set; }
        public TipoDocumento? TipoDocumento { get; set; }

        [Display(Name = "EPS", AutoGenerateFilter = false)]
        public int EPSId { get; set; }
        public EPS? EPS { get; set; }

        [Display(Name = "ARL", AutoGenerateFilter = false)]
        public int ARLId { get; set; }
        public ARL? ARL { get; set; }

        [Display(Name = "CCF", AutoGenerateFilter = false)]
        public int CCFId { get; set; }
        public CCF? CCF { get; set; }

        [Display(Name = "AFP", AutoGenerateFilter = false)]
        public int AFPId { get; set; }
        public AFP? AFP { get; set; }


    }


}
