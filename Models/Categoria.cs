
using System.Text.Json.Serialization;

namespace webapi.Models
{
    public class Categoria
    {
        public Guid categoriaId {get; set;}
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int peso { get; set; }
        [JsonIgnore]
        public virtual ICollection<Tarea> tareas {get; set;}
    }
}