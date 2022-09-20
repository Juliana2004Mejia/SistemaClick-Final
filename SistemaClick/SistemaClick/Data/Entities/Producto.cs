using System.ComponentModel.DataAnnotations;
namespace SistemaClick.Data.Entities
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el nombre"), MaxLength(30)]
        public string Nombre { get; set; }

        public string? Marca { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el precio por unidad")]
        [Display(Name = "Precio por unidad", AutoGenerateFilter = false)]
        public double Precio_unidad { get; set; }

        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Por favor ingresa el nombre del proveedor")]
        public string NombreProveedor { get; set; }


        /*LLAVES FORANEAS*/
        [Display(Name = "Categoria", AutoGenerateFilter = false)]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        [Display(Name = "Unidad de medida", AutoGenerateFilter = false)]
        public int UnidadMedidaId { get; set; }
        public UnidadMedida? UnidadMedida { get; set; }

        [Display(Name = "Inventario", AutoGenerateFilter = false)]
        public int InventarioId { get; set; }
        public Inventario? Inventario { get; set; }

        [Display(Name = "Proveedor", AutoGenerateFilter = false)]
        public int ProveedorId { get; set; }
        public Proveedor? Proveedor { get; set; }
    }
}
