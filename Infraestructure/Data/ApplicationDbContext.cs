using Domain.Entities;
using Infrastructure.Data.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSets (Nombres plurales según convención, pero las entidades tienen nombres singulares)
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
        public DbSet<SongVersionAudio> SongVersionAudios { get; set; }
        public DbSet<ErrorLogs> ErrorLogs { get; set; }
        public DbSet<UserInstrument> UserInstruments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Llama al método base para convenciones

            // Aplica todas las configuraciones de entidades
            modelBuilder.ApplyConfiguration(new ActionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AuditLogConfiguration());
            modelBuilder.ApplyConfiguration(new ErrorLogsConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new InstrumentConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new SongConfiguration());
            modelBuilder.ApplyConfiguration(new SongVersionConfiguration());
            modelBuilder.ApplyConfiguration(new SongVersionAudioConfiguration());
            modelBuilder.ApplyConfiguration(new SongVersionInstrumentPdfConfiguration());
            modelBuilder.ApplyConfiguration(new SongVersionInstrumentTextConfiguration());
            modelBuilder.ApplyConfiguration(new SongVersionInstrumentVideoConfiguration());
            modelBuilder.ApplyConfiguration(new SongVersionPdfConfiguration());
            modelBuilder.ApplyConfiguration(new UserInstrumentConfiguration());
        }
    }
}