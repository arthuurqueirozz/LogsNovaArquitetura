using FluentValidation;
using LogsDomain.Entities;
using LogsDomain.Interfaces;
using LogsService.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace LogsService.Services
{
    public class BaseService<TEntity> : IBaseLogService<TEntity> where TEntity : LogBase
    {
        private readonly ILogRepository<TEntity> _logRepository;

        public BaseService(ILogRepository<TEntity> logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<TEntity> Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>, new()
        {
            Validate(obj, Activator.CreateInstance<TValidator>());

            await _logRepository.Insert(obj);
            return obj;
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return await _logRepository.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _logRepository.Find(id);
        }

        public async Task<TEntity> Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>, new()
        {
            Validate(obj, Activator.CreateInstance<TValidator>());

            await _logRepository.Update(obj);
            return obj;
        }

        public async Task Delete(int id)
        {
            await _logRepository.Delete(id);
        }



        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
            {
                throw new Exception("Null Object");
            }

            var validationResult = validator.Validate(obj);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}
