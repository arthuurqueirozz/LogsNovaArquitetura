using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsDomain.Entities.LogTipos
{
    public class LogPagamentoBoleto : LogBase
    {
        public string CodigoBarrasBoleto { get; set; } = string.Empty;
        public int ContaDestino { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal ValorBoleto { get; set; }
    }
}
