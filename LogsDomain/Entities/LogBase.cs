using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsDomain.Entities
{
    public class LogBase : BaseEntity
    {
        //public int Id { get; set; }
        public DateTime DataLog { get; set; } = DateTime.UtcNow;
        public int Agencia { get; set; }
        public bool Estornado { get; set; } 
        //public int NumeroContaDestino { get; set; }

    }
}
