using bookkeeper.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace bookkeeper.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CashRegister> CashRegisters { get; set; }
        public DbSet<Journal> Journals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-many relationship between Journal and CashRegister
            modelBuilder.Entity<CashRegister>()
                .HasOne(cr => cr.Journal)
                .WithMany(j => j.CashRegisters)
                .HasForeignKey(cr => cr.JournalId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
