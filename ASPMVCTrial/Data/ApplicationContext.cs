using ASPMVCTrial.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ASPMVCTrial.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Deal> Deal { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
