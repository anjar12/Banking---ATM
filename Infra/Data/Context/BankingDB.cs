using Infra.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Context
{
    public class BankingDB : DbContext
    {
        public BankingDB(DbContextOptions<BankingDB> options) : base(options)
        {
        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<TransactionType> TransactionType { get; set; }
        public DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>().ToTable("Customers");
            modelBuilder.Entity<Transactions>().ToTable("Transactions");
            modelBuilder.Entity<TransactionType>().ToTable("TransactionType");
            modelBuilder.Entity<Users>().ToTable("Users");
        }
    }
}
