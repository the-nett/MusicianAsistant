using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        
        //public DbSet<UserRole> UsuariosRoles { get; set; }
        //public DbSet<RolePermission> RolesPermissions { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongVersion> SongVersions { get; set; }
        public DbSet<SongVersionPdf> SongVersionPdfs { get; set; }
        public DbSet<SongVersionInstrumentPdf> SongVersionInstrumentPdfs { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<SongVersionInstrumentVideo> SongVersionInstrumentVideos { get; set; }
        public DbSet<ActionType> ActionTypes { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<SongVersionInstrumentText> SongVersionInstrumentTexts { get; set; }
        public DbSet<Role> Roles { get; set; }


        public DbSet<ErrorLogs> ErrorLogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relations---------------------------------
            modelBuilder.Entity<Profile>()
                .HasOne(rp => rp.gender)
                .WithMany(r => r.Profiles)
                .HasForeignKey(rp => rp.GenderId);
            modelBuilder.Entity<Profile>(entity =>
            {
                entity.Property(e => e.BirthDate)
                    .HasConversion(
                        v => v.ToDateTime(TimeOnly.MinValue), // Convert to DateTime to store
                        v => DateOnly.FromDateTime(v));       // Convert back to DateOnly when reading
            });
            modelBuilder.Entity<Profile>()
                .HasOne(p => p.Role)
                .WithMany(r => r.Profiles)
                .HasForeignKey(p => p.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserInstrument>()
                .HasKey(ui => new { ui.UserId, ui.InstrumentId });

            modelBuilder.Entity<UserInstrument>()
                .HasOne(ui => ui.User)
                .WithMany(p => p.UserInstruments)
                .HasForeignKey(ui => ui.UserId);

            modelBuilder.Entity<UserInstrument>()
                .HasOne(ui => ui.Instrument)
                .WithMany(i => i.UserInstruments)
                .HasForeignKey(ui => ui.InstrumentId);
            //----------------------------------------------------
            modelBuilder.Entity<Song>()
                .HasOne(b => b.Creator)
                .WithMany(b => b.Songs)
                .HasForeignKey(b => b.CreatedBy);
            //-------------------------------------------------
            modelBuilder.Entity<SongVersion>()
                .HasOne(b => b.Song)
                .WithMany(b => b.Versions)
                .HasForeignKey(b => b.SongId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SongVersion>()
                .HasOne(b => b.Creator)
                .WithMany(b => b.SongVersions)
                .HasForeignKey(b => b.CreatedBy);

            //-------------------------------------------------
            modelBuilder.Entity<SongVersionPdf>()
                .HasOne(b => b.Version)
                .WithOne(bp => bp.SongVersionn).
                HasForeignKey<SongVersionPdf>(b => b.VersionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SongVersionPdf>()
                .HasOne(b => b.Uploader)
                .WithMany(bp => bp.SongVersionPdfs)
                .HasForeignKey(b => b.UploadedBy)
                .OnDelete(DeleteBehavior.Restrict);

            //-------------------------------------------------
            modelBuilder.Entity<SongVersionInstrumentPdf>()
                .HasOne(b => b.Version)
                .WithMany(bp => bp.SongVersionInstrumentPdfs)
                .HasForeignKey(b => b.VersionId);

            modelBuilder.Entity<SongVersionInstrumentPdf>()
                .HasOne(b => b.Instrument)
                .WithMany(bp => bp.SongVersionInstrumentPdfs)
                .HasForeignKey(b => b.InstrumentId);


            modelBuilder.Entity<SongVersionInstrumentPdf>()
                .HasOne(b => b.Uploader)
                .WithMany(bp => bp.SongVersionInstrumentPdfs)
                .HasForeignKey(b => b.UploadedBy)
                .OnDelete(DeleteBehavior.Restrict);
            //-------------------------------------------------
            modelBuilder.Entity<SongVersionInstrumentVideo>()
                .HasOne(b => b.Version)
                .WithMany(bp => bp.SongVersionInstrumentVideos)
                .HasForeignKey(b => b.VersionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SongVersionInstrumentVideo>()
                 .HasOne(b => b.Instrument)
                 .WithMany(bp => bp.SongVersionInstrumentVideos)
                 .HasForeignKey(b => b.InstrumentId);


            modelBuilder.Entity<SongVersionInstrumentVideo>()
                .HasOne(b => b.Uploader)
                .WithMany(bp => bp.SongVersionInstrumentVideos)
                .HasForeignKey(b => b.UploadedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SongVersionInstrumentText>()
                .HasOne(t => t.Version)
                .WithMany(v => v.SongVersionInstrumentTexts)
                .HasForeignKey(t => t.VersionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SongVersionInstrumentText>()
                .HasOne(t => t.Instrument)
                .WithMany(i => i.SongVersionInstrumentTexts)
                .HasForeignKey(t => t.InstrumentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SongVersionInstrumentText>()
                .HasOne(t => t.Uploader)
                .WithMany(p => p.SongVersionInstrumentTexts)
                .HasForeignKey(t => t.UploadedBy)
                .OnDelete(DeleteBehavior.Restrict);


            // ---------- Seed Data ----------
            //Instruments
            modelBuilder.Entity<Instrument>().HasData(
                new Instrument { InstrumentId = 1, NameInstrument = "Trompeta" },
                new Instrument { InstrumentId = 2, NameInstrument = "Guitarra" },
                new Instrument { InstrumentId = 3, NameInstrument = "Bateria" },
                new Instrument { InstrumentId = 4, NameInstrument = "Otro" }
            );
            //Genders
            modelBuilder.Entity<Gender>().HasData(
                new Gender { IdGender = 1, GenderName = "Masculino" },
                new Gender { IdGender = 2, GenderName = "Femenino" },
                new Gender { IdGender = 3, GenderName = "Otro" }
            );
            //Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Músico" },
                new Role { RoleId = 2, RoleName = "Administrador" }
            );

            modelBuilder.Entity<Profile>().HasData(
                new Profile
                {
                    Id = 1,
                    UserUniqueId = "user-unique-001",
                    FullName = "Ricardo Rodriguez",
                    GenderId = 1,
                    BirthDate = new DateOnly(1990, 05, 20),
                    CreatedAt = new DateTime(2025, 04, 07, 12, 0, 0, DateTimeKind.Utc),
                    IsActive = true,
                    RoleId = 2

                },
                new Profile
                {
                    Id = 2,
                    UserUniqueId = "user-unique-002",
                    FullName = "María López",
                    GenderId = 2,
                    BirthDate = new DateOnly(1992, 08, 15),
                    CreatedAt = new DateTime(2025, 04, 07, 12, 0, 0, DateTimeKind.Utc),
                    IsActive = true,
                    RoleId = 2
                },
                new Profile
                {
                    Id = 3,
                    UserUniqueId = "user-unique-003",
                    FullName = "Carlos Martínez",
                    GenderId = 1,
                    BirthDate = new DateOnly(1985, 11, 10),
                    CreatedAt = new DateTime(2025, 04, 07, 12, 0, 0, DateTimeKind.Utc),
                    IsActive = true,
                    RoleId = 1
                }
            );

        }
    }
}
