using Microsoft.EntityFrameworkCore;
using SistemaClick.Data.Entities;

namespace SistemaClick.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Beneficio> Beneficios { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<PQRS> PQRS { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Recoleccion> Recolecciones { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<TipoContrato> TipoContratos { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<TipoVivienda> TipoViviendas { get; set; }
        public DbSet<UnidadMedida> UnidadMedidas { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<EPS> EPS { get; set; }
        public DbSet<ARL> ARL { get; set; }
        public DbSet<AFP> AFP { get; set; }
        public DbSet<CCF> CCF { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Beneficio>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<Cargo>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<Categoria>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<Cliente>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<Empleado>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<Localidad>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<PQRS>().HasIndex(c => c.Descripcion).IsUnique();
            modelBuilder.Entity<Producto>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<Plan>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<Proveedor>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<Recoleccion>().HasIndex(c => c.Fecha).IsUnique();
            modelBuilder.Entity<Rol>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<TipoContrato>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<TipoDocumento>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<TipoVivienda>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<UnidadMedida>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<Inventario>().HasIndex(c => c.Entrada).IsUnique();
            modelBuilder.Entity<EPS>().HasIndex(C => C.Nombre).IsUnique();
            modelBuilder.Entity<ARL>().HasIndex(C => C.Nombre).IsUnique();
            modelBuilder.Entity<AFP>().HasIndex(C => C.Nombre).IsUnique();
            modelBuilder.Entity<CCF>().HasIndex(C => C.Nombre).IsUnique();
        }
    }
}
