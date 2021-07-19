using System;
using System.Collections.Generic;
using System.Text;

namespace Tuya.Pagos.Persistence.Infraestructure
{
    public class Disposable : IDisposable
    {
        private bool IsDisposed;

        ~Disposable()
        {
            Dispose(false);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if(!IsDisposed && disposing)
            {
                DisposeCore();
            }
            IsDisposed = true;
        }

        // Ovveride this to dispose custom objects
        protected virtual void DisposeCore()
        {
        }
    }
}
