using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplicationTomato.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {


        public virtual DbSet<Category> Categories { get; set; }
       // public virtual DbSet<SubCategory> SubCategories { get; set; }
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Category>()
                      .HasMany(b => b.ChildCategories)
                      .WithOne()
                      .HasPrincipalKey(b => b.Id);
            modelBuilder.Entity<Category>()
              .Navigation(b => b.ChildCategories)
              .UsePropertyAccessMode(PropertyAccessMode.Property);
  */
            
            /*
                modelBuilder.Entity<Category>()
                           .HasMany(b => b.SubCategories)
                           .WithOne()
                           .HasPrincipalKey(b => b.Id);

                modelBuilder.Entity<SubCategory>()
                           .HasOne(p => p.Category)
                           .WithMany(b => b.SubCategories)
                                .HasForeignKey(p => p.CategoryId);

                modelBuilder.Entity<Category>()
                  .Navigation(b => b.SubCategories)
                  .UsePropertyAccessMode(PropertyAccessMode.Property);
            */
            //its neccessary in order to no ask for primary key
            base.OnModelCreating(modelBuilder);

        }



    }
}
