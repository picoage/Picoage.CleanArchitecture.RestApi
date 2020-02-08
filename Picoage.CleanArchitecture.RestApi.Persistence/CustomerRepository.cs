using Picoage.CleanArchitecture.RestApi.Application.Interfaces.Repositories;
using Picoage.CleanArchitecture.RestApi.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Picoage.CleanArchitecture.RestApi.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await Task.FromResult(new List<Customer> { new Customer { FirstName = "Bob", LastName = "Test", UserName = "dev@test.com", Password = "6a>2=b9piSo6n-d" } });
        }

        public Task<Customer> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
