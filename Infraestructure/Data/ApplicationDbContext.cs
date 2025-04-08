using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        //public DbSet<UserRole> UsuariosRoles { get; set; }
        //public DbSet<RolePermission> RolesPermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<UserBand> UserBands { get; set; }
        public DbSet<BandRole> BandRoles { get; set; }
        public DbSet<BandInvitation> BandInvitations { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongVersion> SongVersions { get; set; }
        public DbSet<SongVersionPdf> SongVersionPdfs { get; set; }
        public DbSet<SongVersionInstrumentPdf> SongVersionInstrumentPdfs { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<SongVersionInstrumentVideo> SongVersionInstrumentVideos { get; set; }
        public DbSet<ActionType> ActionTypes { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<StatusInvitation> Statuses { get; set; }

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
            modelBuilder.Entity<RolePermission>()
             .HasKey(rp => new { rp.RoleId, rp.PermissionId });
            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolesPermissions)
                .HasForeignKey(rp => rp.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolesPermissions)
                .HasForeignKey(rp => rp.PermissionId);
            //----------------------------------------------
            modelBuilder.Entity<UserRol>()
                .HasKey(ur => new { ur.UserId, ur.RoleId }); // Clave compuesta

            modelBuilder.Entity<UserRol>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UsersRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRol>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UsersRoles)
                .HasForeignKey(ur => ur.RoleId);
            //-------------------------------------------------
            modelBuilder.Entity<Band>()
                .HasOne(p => p.Creator)
                .WithMany(r => r.Bands)
                .HasForeignKey(p => p.CreatedBy);
            //-------------------------------------------------
            modelBuilder.Entity<UserBand>()
                .HasOne(ub => ub.User)
                .WithMany(p => p.UsersBand)
                .HasForeignKey(ub => ub.UserId)
                .OnDelete(DeleteBehavior.Restrict); // <-- Aquí se evita la cascada conflictiva

            modelBuilder.Entity<UserBand>()
                .HasOne(ub => ub.Band)
                .WithMany(b => b.UsersBand)
                .HasForeignKey(ub => ub.BandId)
                .OnDelete(DeleteBehavior.Cascade); // Esto sí lo puedes dejar así

            modelBuilder.Entity<UserBand>()
                .HasOne(ub => ub.BandRole)
                .WithMany(br => br.UsersBand)
                .HasForeignKey(ub => ub.BandRoleId)
                .OnDelete(DeleteBehavior.Cascade); // También sin problema

            //-------------------------------------------------
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

            modelBuilder.Entity<SongVersion>()
                .HasOne(b => b.Band)
                .WithMany(pr => pr.Songs)
                .HasForeignKey(b => b.BandId);
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
                .WithOne(bp => bp.SongVersionInstrumentPdf)
                .HasForeignKey<SongVersionInstrumentPdf>(b => b.VersionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SongVersionInstrumentPdf>()
                .HasOne(b => b.Instrument)
                .WithOne(bp => bp.SongVersionInstrumentPdf)
                .HasForeignKey<SongVersionInstrumentPdf>(b => b.InstrumentId)
                .OnDelete(DeleteBehavior.Restrict);

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
                .WithOne(bp => bp.SongVersionInstrumentVideos)
                .HasForeignKey<SongVersionInstrumentVideo>(b => b.InstrumentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SongVersionInstrumentVideo>()
                .HasOne(b => b.Uploader)
                .WithMany(bp => bp.SongVersionInstrumentVideos)
                .HasForeignKey(b => b.UploadedBy)
                .OnDelete(DeleteBehavior.Restrict);
            //-------------------------------------------------

            modelBuilder.Entity<BandInvitation>()
                .HasOne(b => b.Status)
                .WithMany(bp => bp.BandInvitations)
                .HasForeignKey(b => b.StatusInvitationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BandInvitation>()
                .HasOne(b => b.InvitedByProfile)
                .WithMany(bp => bp.BandInvitations)
                .HasForeignKey(b => b.InvitedBy)
                .OnDelete(DeleteBehavior.Restrict);


            // ---------- Seed Data ----------
            // Insertando roles
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, Name = "Administrador", Description = "Administrador del sistema" },
                new Role { RoleId = 2, Name = "UsuarioEstandar", Description = "Usuario estándar" },
                new Role { RoleId = 3, Name = "Moderator", Description = "Modera contenido" }
            );
            // Insertando permisos
            modelBuilder.Entity<Permission>().HasData(
                new Permission { PermissionId = 1, Name = "Crear", Description = "Permite crear recursos" },
                new Permission { PermissionId = 2, Name = "Leer", Description = "Permite leer recursos" },
                new Permission { PermissionId = 3, Name = "Actualizar", Description = "Permite actualizar recursos" },
                new Permission { PermissionId = 4, Name = "Eliminar", Description = "Permite eliminar recursos" }
            );
            //Instruments
            modelBuilder.Entity<Instrument>().HasData(
                new Instrument { InstrumentId = 1, NameInstrument = "Trompeta" },
                new Instrument { InstrumentId = 2, NameInstrument = "Guitarra" },
                new Instrument { InstrumentId = 3, NameInstrument = "Bateria" },
                new Instrument { InstrumentId = 4, NameInstrument = "Otro" }
            );
            // Asignando roles a bandRoles
            modelBuilder.Entity<BandRole>().HasData(
                new BandRole { BandRoleId = 1, Name = "Director" }, // Usuario 1 es Admin
                new BandRole { BandRoleId = 2, Name = "Musico" }, // Usuario 2 es User
                new BandRole { BandRoleId = 3, Name = "Técnico" }  // Usuario 3 es Moderador
            );
            //Genders
            modelBuilder.Entity<Gender>().HasData(
                new Gender { IdGender = 1, GenderName = "Masculino" },
                new Gender { IdGender = 2, GenderName = "Femenino" },
                new Gender { IdGender = 3, GenderName = "Otro" }
            );

            modelBuilder.Entity<Profile>().HasData(
                new Profile
                {
                    Id = 1,
                    UserUniqueId = "user-unique-001",
                    StatusInvitationId = null,
                    FullName = "Juan Pérez",
                    GenderId = 1,
                    BirthDate = new DateOnly(1990, 05, 20),
                    CreatedAt = new DateTime(2025, 04, 07, 12, 0, 0, DateTimeKind.Utc),
                    IsActive = true
                },
                new Profile
                {
                    Id = 2,
                    UserUniqueId = "user-unique-002",
                    StatusInvitationId = null,
                    FullName = "María López",
                    GenderId = 2,
                    BirthDate = new DateOnly(1992, 08, 15),
                    CreatedAt = new DateTime(2025, 04, 07, 12, 0, 0, DateTimeKind.Utc),
                    IsActive = true
                },
                new Profile
                {
                    Id = 3,
                    UserUniqueId = "user-unique-003",
                    StatusInvitationId = null,
                    FullName = "Carlos Martínez",
                    GenderId = 1,
                    BirthDate = new DateOnly(1985, 11, 10),
                    CreatedAt = new DateTime(2025, 04, 07, 12, 0, 0, DateTimeKind.Utc),
                    IsActive = true
                }
            );



            // Asignando usuarios a roles (usuarios_roles)
            modelBuilder.Entity<UserRol>().HasData(
                new UserRol { UserId = 1, RoleId = 1 }, // Usuario 1 es Admin
                new UserRol { UserId = 2, RoleId = 2 }, // Usuario 2 es User
                new UserRol { UserId = 3, RoleId = 3 }  // Usuario 3 es Moderador
            );

            // Asignando permisos a roles (roles_permissions)
            modelBuilder.Entity<RolePermission>().HasData(
                new RolePermission { RoleId = 1, PermissionId = 1 }, // Admin puede crear
                new RolePermission { RoleId = 1, PermissionId = 2 }, // Admin puede leer
                new RolePermission { RoleId = 1, PermissionId = 3 }, // Admin puede actualizar
                new RolePermission { RoleId = 1, PermissionId = 4 }, // Admin puede eliminar
                new RolePermission { RoleId = 2, PermissionId = 2 }, // Usuario solo puede leer
                new RolePermission { RoleId = 3, PermissionId = 2 }, // Moderador puede leer
                new RolePermission { RoleId = 3, PermissionId = 3 }  // Moderador puede actualizar
            );
        }
    }
}
