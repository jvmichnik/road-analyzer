using Levantamento.Domain.AggregatesModel.LevantamentoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Levantamento.Infrastructure.Sql.EntityConfigurations
{
    public class LevantamentoEntityTypeConfiguration : IEntityTypeConfiguration<Domain.AggregatesModel.LevantamentoAggregate.Levantamentos>
    {
        public void Configure(EntityTypeBuilder<Domain.AggregatesModel.LevantamentoAggregate.Levantamentos> config)
        {
            config.ToTable("Levantamento");

            config.HasKey(b => b.Id);

            config.Ignore(b => b.DomainEvents);

            config.Property(b => b.Name)
                .HasColumnType("varchar(150)")
                .IsRequired();

            config.Property(b => b.Description)
                .HasColumnType("varchar(500)");

            config.Property(b => b.Start)
                .HasColumnType("datetime");

            config.Property(b => b.End)
                .HasColumnType("datetime");
        }
    }
}
