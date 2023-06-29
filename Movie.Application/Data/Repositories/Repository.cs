using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Data.Repositories
{
    internal interface IRepository<T>
    {
        Task<T> GetById(int id);
        Task<IList<T>> GetAll();
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}
