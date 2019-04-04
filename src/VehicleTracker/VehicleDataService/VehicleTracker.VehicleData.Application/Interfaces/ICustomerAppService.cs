using System;
using System.Collections.Generic;
using VehicleTracker.VehicleData.Application.ViewModels;

namespace VehicleTracker.VehicleData.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        void AddNewCustomer(CustomerViewModel customerViewModel);
        IEnumerable<CustomerViewModel> GetAll();
        CustomerViewModel GetById(Guid id);
        void Update(CustomerViewModel customerViewModel);
        void Remove(Guid id);

    }
}
