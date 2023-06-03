﻿using BookStore.Saas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookStore.Saas.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Translator> Translator { get; set; }
        public DbSet<User> User { get; set; }
    }
}