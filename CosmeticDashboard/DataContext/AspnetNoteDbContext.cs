using CosmeticDashboard.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticDashboard.DataContext
{
    public class AspnetNoteDbContext : DbContext
    {
        public AspnetNoteDbContext(DbContextOptions<AspnetNoteDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }

       
    }
}
