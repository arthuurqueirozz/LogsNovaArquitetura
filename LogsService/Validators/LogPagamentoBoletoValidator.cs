﻿using FluentValidation;
using LogsDomain.Entities.LogTipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsService.Validators
{
    public class LogPagamentoBoletoValidator : AbstractValidator<LogPagamentoBoleto>
    {
        public LogPagamentoBoletoValidator()
        {
            RuleFor(log => log.CodigoBarrasBoleto)
                .NotEmpty().WithMessage("o codigo de barras nao pode ser vazio");

            RuleFor(log => log.ValorBoleto)
                .GreaterThan(0).WithMessage("o valor do boleto nao pode ser nulo");
        }
    }
}
