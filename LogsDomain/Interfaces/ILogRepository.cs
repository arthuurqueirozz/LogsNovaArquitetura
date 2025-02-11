using LogsDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsDomain.Interfaces
{
    public interface ILogRepository
    {
        Task AdicionarLogAsync(LogBase log);
        Task<IEnumerable<LogBase>> RetornarTodosLogsAsync();
        Task<LogBase> RetornarPorIdAsync(int id);
    }
}
