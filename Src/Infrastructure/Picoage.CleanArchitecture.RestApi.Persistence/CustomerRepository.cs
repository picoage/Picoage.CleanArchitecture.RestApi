using Newtonsoft.Json;
using Picoage.CleanArchitecture.RestApi.Application.Interfaces.Repositories;
using Picoage.CleanArchitecture.RestApi.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Picoage.CleanArchitecture.RestApi.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string path;

        public CustomerRepository(string path)
        {
            this.path = path;
        }
        public async Task<IEnumerable<Customer>> GetAll()
        {
            //cHa89YlWjlIZ
            string file = await File.ReadAllTextAsync(path);
            return JsonConvert.DeserializeObject<List<Customer>>(file);
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
