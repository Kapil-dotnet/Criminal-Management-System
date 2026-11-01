using CriminalManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CriminalManagementSystem.Data
{
    public class CriminalDbContext : IdentityDbContext<IdentityUser>
    {
        public CriminalDbContext(
            DbContextOptions<CriminalDbContext> options)
            : base(options)
        {
        }
        public DbSet<Criminal> Criminals { get; set; }
    }
}