using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogsDomain.Entities;
using LogsDomain.Entities.LogTipos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogsInfraData.Mapping
{
    public class LogPagamentoBoletoMap : IEntityTypeConfiguration<LogPagamentoBoleto>
    {
        public void Configure(EntityTypeBuilder<LogPagamentoBoleto> builder)
        {
            builder.ToTable("LogPagamentoBoletos");

            //builder.HasKey(c => c.Id);

            builder.HasOne<LogBase>()
                .WithOne()
                .HasForeignKey<LogPagamentoBoleto>(c => c.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(prop => prop.CodigoBarrasBoleto)
                .IsRequired()
                .HasColumnName("CodigoBarrasBoleto");

            builder.Property(prop => prop.DataVencimento)
                .IsRequired()
                .HasColumnName("DataVencimento");

            builder.Property(prop => prop.DataPagamento)
                .IsRequired()
                .HasColumnName("DataPagamento");

            builder.Property(prop => prop.ValorBoleto)
                .IsRequired()
                .HasColumnName("ValorBoleto")
                .HasColumnType("decimal(18,2)");

        }
    }
}
