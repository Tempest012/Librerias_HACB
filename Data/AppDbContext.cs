﻿using Librerias_HACB.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace Librerias_HACB.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>().HasOne(b => b.Book).WithMany(ba => ba.Book_Authors).HasForeignKey(bi => bi.BookId);
            modelBuilder.Entity<Book_Author>().HasOne(b => b.Author).WithMany(ba => ba.Book_Authors).HasForeignKey(bi => bi.AuthorId);
        }
        //Utilizaremos este método para obtener y enviar datos a la BD
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book_Author> Book_Author { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}
