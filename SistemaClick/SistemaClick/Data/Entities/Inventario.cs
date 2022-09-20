using System.ComponentModel.DataAnnotations;
namespace SistemaClick.Data.Entities
{
    public class Inventario
    {
        [Key]
        public int InventarioId { get; set; }

        [Required(ErrorMessage = "Por favor ingresar el precio")]
        public double Nombre { get; set; }


        [Required(ErrorMessage = "Por favor ingresar el precio")]
        [Display(Name = "Precio por unidad", AutoGenerateFilter = false)]
        public double Precio_unidad { get; set; }

        [Required(ErrorMessage = "Por favor ingresar la entrada del producto")]
        public double Entrada { get; set; }

        [Required(ErrorMessage = "Por favor ingresar la fecha de entrada del producto")]
        [Display(Name = "Fecha de entrada del producto", AutoGenerateFilter = false)]
        public DateTime Fecha_Entrada { get; set; }

        [Required(ErrorMessage = "Por favor ingresar el stock de unidad del producto")]
        public double Stock { get; set; }

        [Required(ErrorMessage = "Por favor ingresar la salida del producto")]

        public double Salida { get; set; }

        [Required(ErrorMessage = "Por favor ingresar la fecha de salida del producto")]
        [Display(Name = "Fecha de salida del producto", AutoGenerateFilter = false)]
        public DateTime Fecha_Salida { get; set; }

        [Required(ErrorMessage = "Por favor ingresar el costo total de bodega")]
        [Display(Name = "Costo total de productos en bodega", AutoGenerateFilter = false)]
        public double Costo_total { get; set; }

        /*Llave foranea*/
        [Display(Name = "Empleado", AutoGenerateFilter = false)]
        public int EmpleadoId { get; set; }
        public Empleado? Empleado { get; set; }

        


    }
}
