﻿// <auto-generated />
using System;
using Currency_Calculator.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Currency_Calculator.EntityFramework.Migrations
{
    [DbContext(typeof(CurrencyDbContext))]
    partial class CurrencyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Currency_Calculator.EntityFramework.DTOs.CurrencyDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CurrencyRatesAndEffectiveDateDtoId")
                        .HasColumnType("TEXT");

                    b.Property<double>("ExchangeRate")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyRatesAndEffectiveDateDtoId");

                    b.ToTable("CurrencyDto");
                });

            modelBuilder.Entity("Currency_Calculator.EntityFramework.DTOs.CurrencyRatesAndEffectiveDateDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CurrencyRatesAndEffectiveDate");
                });

            modelBuilder.Entity("Currency_Calculator.EntityFramework.DTOs.CurrencyDto", b =>
                {
                    b.HasOne("Currency_Calculator.EntityFramework.DTOs.CurrencyRatesAndEffectiveDateDto", null)
                        .WithMany("Rates")
                        .HasForeignKey("CurrencyRatesAndEffectiveDateDtoId");
                });

            modelBuilder.Entity("Currency_Calculator.EntityFramework.DTOs.CurrencyRatesAndEffectiveDateDto", b =>
                {
                    b.Navigation("Rates");
                });
#pragma warning restore 612, 618
        }
    }
}