using LogsDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsDomain.Interfaces
{
    public interface ILogRepository<TEntity> where TEntity : LogBase
    {
        Task Insert(TEntity obj);
        Task<IList<TEntity>> GetAll();
        Task<TEntity> Find(int id);
        Task Delete(int id);
        Task Update(TEntity obj);
    }
}
