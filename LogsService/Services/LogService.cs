using FluentValidation;
using LogsDomain.Entities;
using LogsDomain.Interfaces;
using LogsService.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsService.Services
{
    internal class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        private readonly LogValidator _logValidator;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
            _logValidator = new LogValidator();
        }


        public async Task AdicionarLogAsync(LogBase log)
        {
            var logValidacao = _logValidator.Validate(log);
            if (!logValidacao.IsValid)
                throw new ValidationException(logValidacao.Errors);       //validaçao log base

            await _logRepository.AdicionarLogAsync(log);
        }

        public async Task<IEnumerable<LogBase>> RetornarTodosAsync()
        {
            return await _logRepository.RetornarTodosLogsAsync();
        }

        public async Task<LogBase> RetornarPorIdAsync(int id)
        {
            return await _logRepository.RetornarPorIdAsync(id);
        }
    }
}
