using FluentValidation;
using LogsDomain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogsDomain.Interfaces
{
    public interface IBaseLogService<TEntity> where TEntity : LogBase
    {
        Task<TEntity> Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>, new();
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity?> GetById(int id);
        Task<TEntity> Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>, new();
        Task Delete(int id);
    }
}
