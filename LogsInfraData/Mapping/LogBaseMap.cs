using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogsDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogsInfraData.Mapping
{
    public class LogBaseMap : IEntityTypeConfiguration<LogBase>
    {
        public void Configure(EntityTypeBuilder<LogBase> builder)
        {
            builder.ToTable("LogBase");

            builder.HasKey(c => c.Id);

            builder.Property(prop => prop.Agencia)
                .IsRequired()
                .HasColumnName("Agencia")
                .HasColumnType("int");

            builder.Property(prop => prop.Estornado)
                .IsRequired()
                .HasColumnName("Estornado")
                .HasColumnType("bit");

            builder.Property(prop => prop.DataLog)
                .IsRequired()
                .HasColumnName("DataLog")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.NumeroContaDestino)
                .IsRequired()
                .HasColumnName("NumeroContaDestino")
                .HasColumnType("int");
        }
    }
}
