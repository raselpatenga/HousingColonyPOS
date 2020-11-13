using System;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Complete();
    }
}
