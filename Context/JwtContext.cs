using Microsoft.EntityFrameworkCore;
using MitraNepAdven.Models;
using System.Collections.Generic;

namespace MitraNepAdven.Context
{

    public class JwtContext : DbContext
    {
        public JwtContext(DbContextOptions<JwtContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Staff> Staff { get; set; }



        // DbSet properties for blog and gallery entities
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Gear> Gears { get; set; }

        public DbSet<Car> Cars { get; set; }





    }
}
