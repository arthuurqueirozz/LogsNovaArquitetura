using LogsDomain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsService.Validators
{
    public class LogBaseValidator : AbstractValidator<LogBase>
    {
        public LogBaseValidator()
        {
            RuleFor(log => log.DataLog)
                .NotEmpty().WithMessage("a data do log nao pode estar vazia")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("a data do log nao pode estar no futuro.");

            RuleFor(log => log.Agencia)
                .GreaterThan(0).WithMessage("numero da agencia nao pode ser zero.");
        }
    }
}

