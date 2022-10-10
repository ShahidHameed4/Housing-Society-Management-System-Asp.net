using FastSocietyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FastSocietyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> employees { get; set; }

        public DbSet<Member> customers { get; set; }

        public DbSet<House> houses { get; set; }

        public DbSet<AllocateHouse> allocateHouses { get; set; }

        public DbSet<Annoucement> annoucements { get; set; }
        public DbSet<Complaint> complaints { get; set; }

        public Member obj { get; set; }
    }
}
