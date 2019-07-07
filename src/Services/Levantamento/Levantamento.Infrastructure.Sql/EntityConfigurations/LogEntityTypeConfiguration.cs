using Levantamento.Domain.AggregatesModel.LevantamentoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Levantamento.Infrastructure.Sql.EntityConfigurations
{
    public class LogEntityTypeConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Log");

            builder.HasKey(b => b.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property(b => b.Long)
                .HasColumnType("decimal(12,9)");

            builder.Property(b => b.Lat)
                .HasColumnType("decimal(12,9)");

            builder.Property(b => b.Rate)
                .HasColumnType("decimal(6,3)");

            builder.Property(b => b.Speed)
                .HasColumnType("int");

            builder.Property(b => b.DateOccurred)
                .HasColumnType("datetime");
            
            builder
                .HasOne(p => p.Levantamento)
                .WithMany(x => x.Logs)
                .HasForeignKey(p => p.LevantamentoId)
                .HasConstraintName("FK_Log_Levantamento_LevantamentoId");
        }
    }
}
