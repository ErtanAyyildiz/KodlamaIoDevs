using Core.Security.Entities;
using KodlamaIoDevs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KodlamaIoDevs.Persistance.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public BaseDbContext(IConfiguration configuration, DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            Configuration = configuration;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Programminglanguage

            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.Technologies);
            });

            /// Seeding data
            ProgrammingLanguage[] programmingLanguageEntitySeeds = {
                new(1, "Javascript"),
                new(2, "C#")
            };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

            #endregion

            #region Technology

            modelBuilder.Entity<Technology>(t =>
            {
                t.ToTable("Technologies").HasKey(k => k.Id);
                t.Property(p => p.Id).HasColumnName("Id");
                t.Property(p => p.Name).HasColumnName("Name");
                t.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                t.HasOne(p => p.ProgrammingLanguage);
            });

            Technology[] technologyEntitySeeds = {
                new(1, "Angular", 1),
                new(2, "ReactJS", 1),
                new(3, "EntityFramework", 2),
            };
            modelBuilder.Entity<Technology>().HasData(technologyEntitySeeds);

            #endregion  

            #region SocialMedia

            modelBuilder.Entity<SocialMedia>(s =>
            {
                s.ToTable("SocialMedia");
                s.Property(p => p.Id).HasColumnName("Id");
                s.Property(p => p.UserId).HasColumnName("UserId");
                s.Property(p => p.Url).HasColumnName("Url");
                s.HasOne(p => p.User);
            });

            #endregion

            #region User

            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("Users").HasKey(k => k.Id);
                u.Property(p => p.Id).HasColumnName("Id");
                u.Property(p => p.FirstName).HasColumnName("FirstName");
                u.Property(p => p.LastName).HasColumnName("LastName");
                u.Property(p => p.Email).HasColumnName("Email");
                u.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                u.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                u.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                u.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");

                u.HasMany(p => p.UserOperationClaims);
                u.HasMany(p => p.RefreshTokens);
            });

            #endregion

            #region UserOperationClaims

            modelBuilder.Entity<UserOperationClaim>(u =>
            {
                u.ToTable("UserOperationClaims").HasKey(k => k.Id);
                u.Property(p => p.Id).HasColumnName("Id");
                u.Property(p => p.UserId).HasColumnName("UserId");
                u.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                u.HasOne(p => p.OperationClaim);
                u.HasOne(p => p.User);
            });

            #endregion

            #region OperationClaim

            modelBuilder.Entity<OperationClaim>(o =>
            {
                o.ToTable("OperationClaims").HasKey(k => k.Id);
                o.Property(p => p.Id).HasColumnName("Id");
                o.Property(p => p.Name).HasColumnName("Name");
            });

            OperationClaim[] operationClaimsEntitySeeds = {
                new(1, "Admin"),
                new(2, "User")
            };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaimsEntitySeeds);

            #endregion

        }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        

    }
}
