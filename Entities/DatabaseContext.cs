using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace StudentInformationSystem.Entities
{
  
        public class DatabaseContext :  IdentityDbContext<ApplicationUser>
        {
            public DatabaseContext(DbContextOptions<DatabaseContext> options)
                : base(options)
            {
            }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Files>()
                   .HasOne(i => i.Student)
                    .WithMany(c => c.Files)
                   .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
           

        }
        public DbSet<StudentMaster> StudentMaster { get; set; }
            public DbSet<Files> Files { get; set; }
        }
       
       
    
}
