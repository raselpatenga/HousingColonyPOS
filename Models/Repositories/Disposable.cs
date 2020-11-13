using System;

namespace Repository
{
    public abstract class Disposable : IDisposing
    {
        protected virtual void Dispose(bool disposing)
        {
            Disposing?.Invoke(this, new EventArgs());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public event EventHandler Disposing;
    }
}
