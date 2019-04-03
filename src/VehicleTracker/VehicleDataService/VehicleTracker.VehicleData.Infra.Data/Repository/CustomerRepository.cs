using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VehicleTracker.VehicleData.Domain.Interfaces;
using VehicleTracker.VehicleData.Domain.Models;
using VehicleTracker.VehicleData.Infra.Data.Context;

namespace VehicleTracker.VehicleData.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(VehicleDataContext context)
            : base(context)
        {

        }

    }

    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(VehicleDataContext context)
            : base(context)
        {

        }

        public Vehicle GetByVehicleId(string vehicleId)
        {
            return DbSet.FirstOrDefault(v => v.VehicleId == vehicleId);
        }


    }
}
