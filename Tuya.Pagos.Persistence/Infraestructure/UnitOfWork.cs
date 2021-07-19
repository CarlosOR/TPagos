using Microsoft.EntityFrameworkCore;
using Tuya.Pagos.Persistence.Interfaces.Infraestructure;

namespace Tuya.Pagos.Persistence.Infraestructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private DbContext dbContext;

        public DbContext DbContext
        {
            get => dbContext ?? (dbContext = dbFactory.Init());
        }

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
