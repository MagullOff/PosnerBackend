using System.Net.Mime;

namespace PosnerBackend.Repositories;

public abstract class BaseRepository(ApplicationContext context)
{
    protected readonly ApplicationContext Context = context;
    
    protected bool SaveChanges()
    {
        var saved = Context.SaveChanges();
        return saved > 0;
    }
}