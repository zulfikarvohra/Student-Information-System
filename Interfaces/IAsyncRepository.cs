using StudentInformationSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudentInformationSystem.Interfaces
{
    public interface IAsyncRepository<T> where T : class, BaseEntity
    {
      Task<List<T>> GetAll();
        Task<T> Get(long id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(long id);


    }
}
