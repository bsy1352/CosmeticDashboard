using CosmeticDashboard.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticDashboard.DataContext
{
    public class AspnetDbContext : DbContext
    {
        

        public AspnetDbContext(DbContextOptions<AspnetDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<KoreaLocation> Locations { get; set; }

        public DbSet<Factory> Factories { get; set; }
    }
}
