using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tuya.Pagos.Persistence.Infraestructure;
using Tuya.Pagos.Persistence.Interfaces.Infraestructure;

namespace Tuya.Pagos.Resolver.Persistence
{
    public static class ContextResolver
    {
        public static void ResolveDbContext<TContext>(this IServiceCollection service) where TContext: DbContext
        {
            //If u decide use in memory DB also coment the dependeci inyection for ContructorConnection to no provide a connection string
            service.AddScoped<IContructorConnection, ContructorConnection>();
            service.AddDbContext<TContext>( (serviceProvider, contextBuilder) =>
            {
                IContructorConnection connection = serviceProvider.GetRequiredService<IContructorConnection>();
                connection.ConfigureConnection(contextBuilder);
            });
        }

    }
}
