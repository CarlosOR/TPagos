using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Tuya.Pagos.Resolver.Persistence
{
    public static class MemoryContextResolver
    {
        public static void ResolveMemoryDbContext<TContext>(this IServiceCollection service) where TContext : DbContext
        {
            service.AddDbContext<TContext>();
        }
    }
}
