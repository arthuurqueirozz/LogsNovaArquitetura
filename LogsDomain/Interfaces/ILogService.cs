using LogsDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsDomain.Interfaces
{
    public interface ILogService
    {
        Task AdicionarLogAsync(LogBase log);
        Task<IEnumerable<LogBase>> RetornarTodosAsync();
        Task<LogBase> RetornarPorIdAsync(int id);
    }
}
