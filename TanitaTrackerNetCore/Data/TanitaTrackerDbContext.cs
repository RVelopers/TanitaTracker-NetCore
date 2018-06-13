using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class TanitaTrackerDbContext : DbContext
    {

        public TanitaTrackerDbContext(DbContextOptions<TanitaTrackerDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }

    }
}