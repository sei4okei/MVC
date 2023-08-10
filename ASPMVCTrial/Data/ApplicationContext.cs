using ASPMVCTrial.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ASPMVCTrial.Data
{
    public class ApplicationContext : IdentityDbContext<AppUser>
    {
        public DbSet<Deal> Deal { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
