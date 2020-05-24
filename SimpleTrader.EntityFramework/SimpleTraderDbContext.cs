using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.EntityFramework
{
    public   class SimpleTraderDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AssetTransaction> AssetTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetTransaction>().OwnsOne(s => s.Stock);
            base.OnModelCreating(modelBuilder); 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=127.0.0.1\\SQLEXPRESS;database=SimpleTraderDb;user=sa;password=Siva@123");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
