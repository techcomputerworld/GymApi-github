using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GymApi.Models;

namespace GymApi.Data
{
    public class GymDbContext : IdentityDbContext//<IdentityUser>
    {
        public GymDbContext(DbContextOptions<GymDbContext> options)
           : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);
            builder.Entity<Usuarios>()
                .HasOne(e => e.ejercicios)
                .WithMany(u => u.usuarios)
                .HasForeignKey(e => e.Id);
        }
        public DbSet<Ejercicios> Ejercicios { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
