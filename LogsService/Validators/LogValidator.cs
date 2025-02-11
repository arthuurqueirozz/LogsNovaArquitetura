﻿using LogsDomain.Entities;
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
                .GreaterThan(0).WithMessage("a agencia deve ser maior que zero.");

            RuleFor(log => log.NumeroContaDestino)
                .GreaterThan(0).WithMessage("o numero da conta destino deve ser maior que zero.");
        }
    }
}

