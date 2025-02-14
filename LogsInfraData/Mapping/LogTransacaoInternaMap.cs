using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogsDomain.Entities.LogTipos;
using LogsDomain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LogsInfraData.Mapping
{
    public class LogTransacaoInternaMap : IEntityTypeConfiguration<LogTransacaoInterna>
    {
        public void Configure(EntityTypeBuilder<LogTransacaoInterna> builder)
        {
            builder.ToTable("LogTransacaoInternas");

            //builder.HasKey(c => c.Id);

            builder.HasOne<LogBase>()
                .WithOne()
                .HasForeignKey<LogTransacaoInterna>(k => k.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(prop => prop.NumeroContaInicio)
                .IsRequired()
                .HasColumnName("NumeroContaInicio");

            builder.Property(prop => prop.Status)
                .IsRequired()
                .HasColumnName("Status");

            builder.Property(prop => prop.ValorTransacao)
                .IsRequired()
                .HasColumnName("ValorTransacao")
                .HasColumnType("decimal(18,2)");           
        }
    }
}
