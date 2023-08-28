using BookStore.Domain.Models.AuthorAggregates;
using BookStore.Domain.Models.BookAggregates;
using BookStore.Domain.Models.OrderAggregates;
using BookStore.Domain.Models.PublisherAggregates;
using BookStore.Domain.Models.RoleAggregates;
using BookStore.Domain.Models.TranslatorAggregates;
using BookStore.Domain.Models.UserAggregates;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookStore.Infrastructure
{
    public class ApplicationDbContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
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
    }
}