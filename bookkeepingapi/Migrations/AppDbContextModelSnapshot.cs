﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bookkeeper.Data;

#nullable disable

namespace bookkeepingapi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("bookkeeper.Models.CashRegister", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("JournalId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("JournalId");

                    b.ToTable("CashRegisters");
                });

            modelBuilder.Entity("bookkeeper.Models.Journal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Credit")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Debit")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Journals");
                });

            modelBuilder.Entity("bookkeeper.Models.CashRegister", b =>
                {
                    b.HasOne("bookkeeper.Models.Journal", "Journal")
                        .WithMany("CashRegisters")
                        .HasForeignKey("JournalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Journal");
                });

            modelBuilder.Entity("bookkeeper.Models.Journal", b =>
                {
                    b.Navigation("CashRegisters");
                });
#pragma warning restore 612, 618
        }
    }
}
