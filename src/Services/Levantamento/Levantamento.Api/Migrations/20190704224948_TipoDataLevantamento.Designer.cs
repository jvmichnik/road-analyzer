﻿// <auto-generated />
using System;
using Levantamento.Infrastructure.Sql.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Levantamento.Api.Migrations
{
    [DbContext(typeof(LevantamentoContext))]
    [Migration("20190704224948_TipoDataLevantamento")]
    partial class TipoDataLevantamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Levantamento.Domain.AggregatesModel.LevantamentoAggregate.LevantamentoRoot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Levantamento");
                });

            modelBuilder.Entity("Levantamento.Domain.AggregatesModel.LevantamentoAggregate.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOccurred");

                    b.Property<decimal>("Lat");

                    b.Property<Guid?>("LevantamentoRootId");

                    b.Property<decimal>("Long");

                    b.Property<decimal>("Rate");

                    b.Property<int>("Speed");

                    b.HasKey("Id");

                    b.HasIndex("LevantamentoRootId");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("Levantamento.Domain.AggregatesModel.LevantamentoAggregate.Log", b =>
                {
                    b.HasOne("Levantamento.Domain.AggregatesModel.LevantamentoAggregate.LevantamentoRoot")
                        .WithMany("Logs")
                        .HasForeignKey("LevantamentoRootId");
                });
#pragma warning restore 612, 618
        }
    }
}
