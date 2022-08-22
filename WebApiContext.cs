using webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace webapi
{
    public class WebApiContext : DbContext
    {
        public DbSet<Tarea> tareas { get; set; }
        public DbSet<Categoria> categorias { get; set; }

        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria()
            {
                categoriaId = Guid.Parse("f9f478c4-e823-4766-ac30-6570108c2f61"),
                nombre = "Actividades pendientes",
                peso = 20
            });
            categoriasInit.Add(new Categoria()
            {
                categoriaId = Guid.Parse("e1537fd4-6677-484b-b4f9-dcaf735a2e30"),
                nombre = "Actividades personales",
                descripcion = "Cocinar",
                peso = 50
            });

            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.categoriaId);
                categoria.Property(p => p.nombre).IsRequired().HasMaxLength(100);
                categoria.Property(p => p.descripcion).IsRequired(false).HasMaxLength(200);
                categoria.Property(p => p.peso).IsRequired();
                categoria.HasData(categoriasInit);
            });

            List<Tarea> tareasInit = new List<Tarea>();
            tareasInit.Add(new Tarea()
            {
                tareaId = Guid.Parse("e66a8239-b479-4028-857a-b6949571c0fa"),
                categoriaId = Guid.Parse("f9f478c4-e823-4766-ac30-6570108c2f61"),
                titulo = "Ver cursos de .NET",
                descripcion = "Curso de API's",
                prioridadTarea = Prioridad.Alta,
                fechaCreacion = DateTime.Now
            });
            tareasInit.Add(new Tarea()
            {
                tareaId = Guid.Parse("17d71731-4dbc-4cad-9488-d03cb5e9f9e1"),
                categoriaId = Guid.Parse("f9f478c4-e823-4766-ac30-6570108c2f61"),
                titulo = "Ver cursos de Angular",
                descripcion = "Curso de angular",
                prioridadTarea = Prioridad.Alta,
                fechaCreacion = DateTime.Now
            });
            tareasInit.Add(new Tarea()
            {
                tareaId = Guid.Parse("1fd0ad0c-f877-43a0-ae29-c88db61ba0e4"),
                categoriaId = Guid.Parse("e1537fd4-6677-484b-b4f9-dcaf735a2e30"),
                titulo = "Hacer compras semanales",
                descripcion = "Papas fritas, lechuga y crema de mani",
                prioridadTarea = Prioridad.Media,
                fechaCreacion = DateTime.Now
            });

            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.tareaId);
                tarea.HasOne(p => p.categoria).WithMany(p => p.tareas).HasForeignKey(p => p.categoriaId);
                tarea.Property(p => p.titulo).IsRequired().HasMaxLength(150);
                tarea.Property(p => p.descripcion).HasMaxLength(200);
                tarea.Property(p => p.prioridadTarea).HasConversion(
                    v => v.ToString(),
                    v => (Prioridad)Enum.Parse(typeof(Prioridad), v));
                tarea.Property(p => p.fechaCreacion);
                tarea.Property(p => p.fechaFinal);
                tarea.Ignore(p => p.resumen);
                tarea.HasData(tareasInit);
            });
        }
    }
}