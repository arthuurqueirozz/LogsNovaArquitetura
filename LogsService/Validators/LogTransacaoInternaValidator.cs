using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LogsDomain.Entities.LogTipos;

namespace LogsService.Validators
{
    public  class LogTransacaoInternaValidator : AbstractValidator<LogTransacaoInterna>
    {
        public LogTransacaoInternaValidator()
        {
            RuleFor(log => log.NumeroContaDestino)
                            .GreaterThan(0).WithMessage("o numero da conta destino deve ser maior que zero.");

            RuleFor(log => log.ValorTransacao)
                            .GreaterThan(0).WithMessage("o valor da transacao nao pode ser zero");
        }
    }
}










