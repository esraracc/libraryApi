using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class LibraryContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UserActionsOnTheBook> UserActionsOnTheBooks { get; set; }


        public LibraryContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(a =>
            {
                a.ToTable("Books").HasKey(x => x.Id);
                a.Property(x => x.Id).HasColumnName("Id");
                a.Property(x => x.Name).HasColumnName("Name");
                a.Property(x => x.PageCount).HasColumnName("PageCount");
                a.Property(x => x.Count).HasColumnName("Count");
                a.Property(x => x.AuthorName).HasColumnName("AuthorName");

               // a.HasOne(s => s.UserActionsOnTheBook)
               //.WithOne(ad => ad.Book)
               //.HasForeignKey<UserActionsOnTheBook>(ad => ad.BookId);
            });

            modelBuilder.Entity<UserActionsOnTheBook>(a =>
            {
                a.ToTable("UserActionsOnTheBooks").HasKey(x => x.Id);
                a.Property(x => x.Id).HasColumnName("Id");
                a.Property(x => x.UserId).HasColumnName("UserId");
                a.Property(x => x.StatusOfTheBook).HasColumnName("StatusOfTheBook");
                a.Property(x => x.ReserveDate).HasColumnName("ReserveDate");
                a.Property(x => x.DeliveryDate).HasColumnName("DeliveryDate");
                a.Property(x => x.ReturnDate).HasColumnName("ReturnDate");

                a.Property(x => x.DeliveryDate).IsRequired(false);
            });

            Book[] bookEntitySeeds = { new(1, "Yazılım Öğreniyorum", 350, 3, "Esra ARAÇ"), new(2, "Yazılım Öğreniyorum2", 300, 5, "Esra ARAÇ"), new(3, "Yazılım Öğreniyorum 3", 200, 2, "Esra ARAÇ") };
            modelBuilder.Entity<Book>().HasData(bookEntitySeeds);
        }
    }
}
