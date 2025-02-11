using FluentValidation;
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
            
        }
    }
}
