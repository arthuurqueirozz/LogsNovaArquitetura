using FluentValidation;
using LogsDomain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogsDomain.Interfaces
{
    public interface IBaseLogService<TEntity> where TEntity : LogBase
    {
       
        public Task<T> Add<TValidator, T>(T obj)
            where TValidator : AbstractValidator<T>, new()
            where T : TEntity;
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity?> GetById(int id);
        Task<TEntity> Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>, new();
        Task Delete(int id);
    }
}
