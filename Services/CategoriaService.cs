using webapi;
using webapi.Models;

namespace webapi.Services;
public class CategoriaService: ICategoriaService
{
    WebApiContext context;

    public CategoriaService(WebApiContext context)
    {
        this.context = context;
    }

    public IEnumerable<Categoria> Get()
    {
        return context.categorias;
    }

    public async Task Save(Categoria categoria)
    {
        await context.AddAsync(categoria);
        await context.SaveChangesAsync();
    }

    public async Task Update(Categoria categoria, Guid id)
    {
        var categoriadb = context.categorias.Find(id);
        if (categoriadb != null)
        {
            categoriadb.nombre = categoria.nombre;
            categoriadb.descripcion = categoria.descripcion;
            categoriadb.peso = categoria.peso;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var categoriadb = context.categorias.Find(id);
        if (categoriadb != null)
        {
            context.Remove(categoriadb);
            await context.SaveChangesAsync();
        }
    }
}

public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    Task Save(Categoria categoria);
    Task Update(Categoria categoria, Guid id);
    Task Delete(Guid id);
}