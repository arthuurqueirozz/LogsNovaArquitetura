using LogsDomain.Entities;
using LogsDomain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LogsData.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly LogDbContext _context;

        public LogRepository(LogDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarLogAsync(LogBase log)
        {
            _context.Set<LogBase>().Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LogBase>> RetornarTodosLogsAsync()
        {
            return await _context.Set<LogBase>().ToListAsync();
        }

        public async Task<LogBase> RetornarPorIdAsync(int id)
        {
            return await _context.Set<LogBase>().FindAsync(id);
        }
    }
}
