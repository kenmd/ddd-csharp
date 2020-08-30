using System;
using System.Threading.Tasks;
using DddInPractice.Logic;


namespace DddInPractice.Repository
{
    public interface IRepository<T> where T : AggregateRoot
    {
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(int id);
    }
}
