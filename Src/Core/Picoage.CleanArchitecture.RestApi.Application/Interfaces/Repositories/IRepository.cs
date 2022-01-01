using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Picoage.CleanArchitecture.RestApi.Application.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Insert(TEntity entity);

        Task Update(TEntity entity);

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(Guid id);



    }
}
