using System;
using Tuya.Pagos.Persistence.Context;

namespace Tuya.Pagos.Persistence.Infraestructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private PagosContext DbContext;

        public DbFactory(PagosContext practiceContext)
        {
            this.DbContext = practiceContext;
        }

        public PagosContext Init()
        {

            return DbContext ?? (DbContext = new PagosContext());
        }

        protected override void DisposeCore()
        {
            if (DbContext != null)
                DbContext.Dispose();
        }

    }

    public interface IDbFactory : IDisposable
    {
        PagosContext Init();
    }
}
