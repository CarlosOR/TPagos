using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tuya.Pagos.Persistence.Context;

namespace Tuya.Pagos.Persistence.Infraestructure
{
    public class MemoryDbFactory : Disposable, IDbFactory
    {
        private PagosContext DbContext;

        public PagosContext Init()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            DbContextOptions<PagosContext> options =
                new DbContextOptionsBuilder<PagosContext>()
                .UseInMemoryDatabase("InMemoryDbname")
                .UseInternalServiceProvider(serviceProvider)
                .Options;


            return DbContext ?? (DbContext = new PagosContext(options));
        }

        protected override void DisposeCore()
        {
            if (DbContext != null)
                DbContext.Dispose();
        }
    }
}
