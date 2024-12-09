using Microsoft.EntityFrameworkCore;
using Scholarly.Domain.Entities.Common;
using Scholarly.Domain.Entities.Articles;
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
        public DbSet<Article> Articles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScholarlyDbContext).Assembly);

            modelBuilder.Entity<Gender>().HasData(
                new Gender 
                {
                    GenderId = 1,
                    GenderName = "Male"
                },
                new Gender
                {
                    GenderId = 2,
                    GenderName = "Female"
                });

            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    UserId = 1,
                    FirstName = "Gurwinder",
                    LastName = "Singh",
                    UserName = "gurwindersingh",
                    Email = "gurwindersingh@gmail.com",
                    PhoneNumber = "1234567890",
                    DOB = new DateTime(1996,08,14),
                    Password = "admin@admin",
                    Gender = null,
                    GenderId = 1,
                });

            modelBuilder.Entity<UserEducation>().HasData(
                new UserEducation
                {
                    UserEducationId = 1,
                    EducationName = "Cloud Data Management",
                    StartDt = new DateTime(2023, 5, 8),
                    EndDt = new DateTime(2024, 8, 19),
                    IsCurrent = false,
                    FieldOfStudy = "Information Technology",
                    Level = "Post Graduate Diploma",
                    InstituteName = "Conestoga College, Kitchener",
                    Description = "A brief dive in various cloud technologies and their implementation",
                    User = null,
                    UserId = 1
                },
                new UserEducation
                {
                    UserEducationId = 2,
                    EducationName = "Computer Science and Engineering",
                    StartDt = new DateTime(2017, 5, 1),
                    EndDt = new DateTime(2024, 4, 1),
                    IsCurrent = false,
                    FieldOfStudy = "Information Technology",
                    Level = "Bachelor's of Technology",
                    InstituteName = "Rayat Institute of Engineering and Information Technology, Railmajra",
                    Description = "A brief study and hand-on experience on computer technologies",
                    User = null,
                    UserId = 1,
                });

            modelBuilder.Entity<UserWorkExperience>().HasData(
                new UserWorkExperience
                {
                    UserWorkExperienceId = 1,
                    Position = "Software Developer",
                    StartDt = new DateTime(2023,4, 1),
                    EndDt= DateTime.UtcNow,
                    IsCurrent = true,
                    Description = "Gained a working experience on latest technologies such as Azure DevOps, Angular, MediatR etc",
                    SkillsUsed = "Azure DevOps, Angular, MediatR, Inversion of Control (IOC), Onion Architecture etc",
                    CompanyName = "Ace Cooling Solutions",
                    User = null,
                    UserId = 1,
                },
                new UserWorkExperience
                {
                    UserWorkExperienceId = 2,
                    Position = "Software Developer",
                    StartDt = new DateTime(2017, 8, 7),
                    EndDt = new DateTime(2023, 3, 1),
                    IsCurrent = false,
                    Description = "Worked on a multi-tier application within a team of 5 developers.",
                    SkillsUsed = "Angular, Inversion of Control (IOC), JQuery, TypeScript, ASP.NET CORE etc",
                    CompanyName = "Vertex Infosoft Solutions Pvt. Ltd",
                    User = null,
                    UserId = 1,
                },
                new UserWorkExperience
                {
                    UserWorkExperienceId = 3,
                    Position = "Software Developer",
                    StartDt = new DateTime(2015, 5, 7),
                    EndDt = new DateTime(2027, 2, 1),
                    IsCurrent = false,
                    Description = "Gained a working experience of Entity Framework and client handling practices.",
                    SkillsUsed = "AngularJS, Entity Framework, ASP.NET MVC etc",
                    CompanyName = "Vertex Infosoft Solutions Pvt. Ltd",
                    User = null,
                    UserId = 1,
                });
        }
    }
}
