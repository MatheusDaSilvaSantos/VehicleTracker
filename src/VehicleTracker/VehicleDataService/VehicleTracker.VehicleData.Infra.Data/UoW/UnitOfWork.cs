using VehicleTracker.Abstract.Domain.Core.Interfaces;
using VehicleTracker.VehicleData.Infra.Data.Context;

namespace VehicleTracker.VehicleData.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VehicleDataContext _context;

        public UnitOfWork(VehicleDataContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
