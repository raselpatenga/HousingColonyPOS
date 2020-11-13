using System;

namespace Repository
{
    public interface IDisposing: IDisposable
    {
        event EventHandler Disposing;
    }
}
