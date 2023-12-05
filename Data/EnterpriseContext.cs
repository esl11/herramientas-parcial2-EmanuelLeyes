using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using parcial2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class EnterpriseContext : IdentityDbContext
    {
        public EnterpriseContext (DbContextOptions<EnterpriseContext> options)
            : base(options)
        {
        }

        public DbSet<parcial2.Models.Footwear> Footwear { get; set; } = default!;

        public DbSet<parcial2.Models.Store> Store { get; set; } = default!;
        public DbSet<parcial2.Models.Movement> Movement { get; set; } = default!;

        public DbSet<parcial2.Models.CompanyData> CompanyData { get; set; } = default!;

       
    
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   //Relación muchos a muchos
            modelBuilder.Entity<Footwear>()
                .HasMany(e => e.Stores)
                .WithMany(e => e.Footwears)
                .UsingEntity("EnterprisesStores");

            base.OnModelCreating(modelBuilder);


        /*
               //Relacion uno a muchos
                 modelBuilder.Entity<CompanyData>()
                .HasMany(p => p.Stores)
                .WithOne(p => p.CompanyD)
                .HasForeignKey( p => p.CompanyDataId);
        */

        }
}
