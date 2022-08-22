
namespace webapi.Models
{
    public class Tarea
    {
        public Guid tareaId { get; set; }
        public Guid categoriaId {get; set;}
        public string titulo { get; set; }
        public string descripcion { get; set; }   
        public Prioridad prioridadTarea {get; set;}
        public DateTime fechaCreacion {get; set;}
        public DateTime fechaFinal { get; set; }
        public virtual Categoria categoria {get; set;}
        public string resumen {get; set;}
    }

    public enum Prioridad{
        Baja, Media, Alta
    }
}