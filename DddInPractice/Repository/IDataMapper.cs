using System;
using System.Threading.Tasks;

namespace DddInPractice.Repository
{
    public interface IDataMapper<T>
    {
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<T> Update(int id, T entity);
        Task<bool> Delete(int id);
    }
}
