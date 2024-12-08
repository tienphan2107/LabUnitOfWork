using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IBaseRepositoryAsync<T> where T : BaseEntity
    {
        Task<T> GetById(object id);
        Task<IList<T>> ListAll();
        Task<T> Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
