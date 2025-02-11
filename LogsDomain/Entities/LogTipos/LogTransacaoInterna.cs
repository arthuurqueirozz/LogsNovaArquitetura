using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsDomain.Entities.LogTipos
{
    public class LogTransacaoInterna : LogBase
    {
        public int NumeroContaInicio { get; set; }
        public decimal ValorTransacao { get; set; } = 0m;
        public string Status { get; set; } = string.Empty;
    }
}
