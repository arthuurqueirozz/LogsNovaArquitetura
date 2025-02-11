using LogsDomain.Entities;
using LogsDomain.Interfaces;
using LogsInfraData.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogsData.Repository
{
    public class LogRepository<TEntity> : ILogRepository<TEntity> where TEntity : LogBase
    {
        private readonly SqlServerContext _context;

        public LogRepository(SqlServerContext context)
        {
            _context = context;
        }

        public async Task Insert(TEntity log)
        {
            _context.Set<TEntity>().Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Find(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task Update(TEntity log)
        {
            _context.Set<TEntity>().Update(log);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var log = await Find(id);
            if (log != null)
            {
                _context.Set<TEntity>().Remove(log);
                await _context.SaveChangesAsync();
            }
        }
    }
}
