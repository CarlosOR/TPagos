using Tuya.Pagos.Models.Entities;
using Tuya.Pagos.Persistence.Repositories;
using Tuya.Pagos.Persistence.Infraestructure;
using Microsoft.Extensions.DependencyInjection;
using Tuya.Pagos.Persistence.Interfaces.Repositories;
using Tuya.Pagos.Persistence.Interfaces.Infraestructure;

namespace Tuya.Pagos.Resolver.Persistence
{
    public static class PersistenceResolver
    {
        public static void AddPersistenceServices(this IServiceCollection service)
        {
            //To use a sql connection use DbFactory, only can be uncomment one of them
            service.AddScoped<IDbFactory, DbFactory>();
            //To use in memory DB use MemoryDbFactory, only can be uncomment one of them
            //If u decide use in memory DB also coment the dependeci inyection for ContructorConnection to no provide a connection string
            //service.AddScoped<IDbFactory, MemoryDbFactory>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IRepository<Invoice>, Repository<Invoice>>();
            service.AddScoped<IRepository<InvoiceProduct>, Repository<InvoiceProduct>>();
            service.AddScoped<IRepository<Stock>, Repository<Stock>>();
            service.AddScoped<IRepository<Product>, Repository<Product>>();
            service.AddScoped<IRepository<Sending>, Repository<Sending>>();
        }
    }
}
