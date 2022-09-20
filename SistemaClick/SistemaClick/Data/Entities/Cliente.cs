using System.ComponentModel.DataAnnotations;
namespace SistemaClick.Data.Entities
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Por favor ingresa el usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el nombre"), MaxLength(30)]
        public string Nombre { get; set; }


        [Display(Name = "Fecha de Recoleccion", AutoGenerateFilter = false)]
        public DateTime Fecha_Recoleccion { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el apellido"), MaxLength(30)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el numero de documento")]
        [Display(Name = "Numero de documento", AutoGenerateFilter = false)]
        public int Numero_documento { get; set; }

        [Required(ErrorMessage = "Por favor ingresa la direcciòn")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el telefono")]
        [DataType(DataType.PhoneNumber)]
        public double Telefono { get; set; }

        [Display(Name = "Fecha de Inscripcion", AutoGenerateFilter = false)]
        [Required(ErrorMessage = "Por favor ingresa la fecha de inscripciòn")]
        public DateTime Fecha_Inscripcion { get; set; }


        /* llAVE FORANEAS */
        [Display(Name = "Tipo de documento", AutoGenerateFilter = false)]
        public int TipoDocumentoId { get; set; }
        public TipoDocumento? TipoDocumento { get; set; }


        [Display(Name = "Tipo de vivienda", AutoGenerateFilter = false)]
        public int TipoViviendaId { get; set; }
        public TipoVivienda? TipoVivienda { get; set; }

        [Display(Name = "Localidad", AutoGenerateFilter = false)]
        public int LocalidadId { get; set; }
        public Localidad? Localidad { get; set; }

        [Display(Name = "Plan", AutoGenerateFilter = false)]
        public int PlanId { get; set; }
        public Plan? Plan { get; set; }

        [Display(Name = "Beneficio", AutoGenerateFilter = false)]
        public int BeneficioId { get; set; }
        public Beneficio? Beneficio { get; set; }
    }
}
