using Microsoft.EntityFrameworkCore;
using Scholarly.Domain.Entities.Common;
using Scholarly.Domain.Entities.Users;

namespace Scholarly.Persistence
{
    public class ScholarlyDbContext: DbContext
    {
        public ScholarlyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserWorkExperience> UserWorkExperiences { get; set; }
        public DbSet<UserEducation> UserEducations { get; set; }
        public DbSet<Gender> Genders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScholarlyDbContext).Assembly);
        }
    }
}
