using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GymApi.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using GymApi.Models.CustomIdentity;

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
            builder.Entity<Usuarios>()
                .Property(r => r.EmailConfirmed)
                .HasConversion(new BoolToZeroOneConverter<Int16>());
            builder.Entity<Usuarios>()
                .Property(r => r.PhoneNumberConfirmed)
                .HasConversion(new BoolToZeroOneConverter<Int16>());
            builder.Entity<Usuarios>()
                .Property(r => r.TwoFactorEnabled)
                .HasConversion(new BoolToZeroOneConverter<Int16>());
            builder.Entity<Usuarios>()
                .Property(r => r.LockoutEnabled)
                .HasConversion(new BoolToZeroOneConverter<Int16>());
            builder.Entity<Usuarios>(b =>
            {
                //b.HasKey(e => e.Id);
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();


            });

            builder.Entity<ApplicationRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });
            //añadir datos a ApplicationRole tabla ""
            //builder.Entity<ApplicationRole>().HasData(
            //    new ApplicationRole() { Id = 1, Name = "SuperAdmin", NormalizedName = "SuperAdmin", ConcurrencyStamp = "" },
            //    new ApplicationRole() { Id = 2, Name = "Admin", NormalizedName = "Admin", ConcurrencyStamp = "" },
            //    new ApplicationRole() { Id = 3, Name = "Edit", NormalizedName = "Edit", ConcurrencyStamp = "" },
            //    new ApplicationRole() { Id = 4, Name = "User", NormalizedName = "User", ConcurrencyStamp = "" }
            //);
            //código añadido para ver si se soluciona el problema de registro de usuarios

        }

        /*  esto es para tener la clase usuarios como la tengo aquí, lógicamente de la forma que hemos modificado Identity tendre que poner una
            relación entre AspNetUsers y Usuarios simplemente eso pero eso ya me busco yo la vida para ver como se hace y aprender
        */
        public DbSet<Ejercicios> Ejercicios { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
