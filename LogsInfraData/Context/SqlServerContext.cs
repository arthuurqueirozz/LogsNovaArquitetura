using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogsDomain.Entities;
using LogsDomain.Entities.LogTipos;
using LogsInfraData.Mapping;
using Microsoft.EntityFrameworkCore;

namespace LogsInfraData.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LogBase> LogBase { get; set; }
        public DbSet<LogPagamentoBoleto> LogPagamentoBoletos { get; set; }
        public DbSet<LogTransacaoInterna> LogTransacaoInternas { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
