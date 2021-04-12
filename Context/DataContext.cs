using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBoundForm.Model;

namespace DataBoundForm.Context
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ) : base(options)
        { 
        
        }
        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<BlogModel> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorModel>().ToTable("Author");
            modelBuilder.Entity<BlogModel>().ToTable("Blog");

        }
    }
}
