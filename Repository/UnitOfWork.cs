using DatabaseContext;
using System;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {


        private readonly POSContext _context;

        public UnitOfWork(POSContext context)
        {
            _context = context;
        }


        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
