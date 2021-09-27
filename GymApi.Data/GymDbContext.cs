using GymApi.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using GymApi.Models.CustomIdentity;
using Microsoft.EntityFrameworkCore;

namespace GymApi.Data
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options)
           : base(options)
        {

        }
        public GymDbContext()
        {

        }
        


        public DbSet<Ejercicios> Ejercicios { get; set; }
        public DbSet<Models.Usuarios> Usuarios { get; set; }
    }
}
