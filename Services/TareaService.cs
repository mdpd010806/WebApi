using webapi.Models;
using webapi;

namespace webapi.Services;

public class TareaService : ITareaService
{
    WebApiContext context;

    public TareaService(WebApiContext context)
    {
        this.context = context;
    }

    public IEnumerable<Tarea> Get()
    {
        return context.tareas;
    }

    public async Task Delete(Guid id)
    {
        var tareadb = context.tareas.Find(id);
        if (tareadb != null)
        {
            context.Remove(tareadb);
            await context.SaveChangesAsync();
        }
    }

    public async Task Save(Tarea tarea)
    {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }

    public async Task Update(Tarea tarea, Guid id)
    {
        var tareadb = context.tareas.Find(id);
        if (tareadb != null)
        {
            tareadb.categoriaId = tarea.categoriaId;
            tareadb.titulo = tarea.titulo;
            tareadb.descripcion = tarea.descripcion;
            tareadb.prioridadTarea = tarea.prioridadTarea;
            await context.SaveChangesAsync();
        }
    }
}

public interface ITareaService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Tarea tarea, Guid id);
    Task Delete(Guid id);
}