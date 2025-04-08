using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveInProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionTypes",
                columns: table => new
                {
                    ActionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTypes", x => x.ActionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "BandRoles",
                columns: table => new
                {
                    BandRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandRoles", x => x.BandRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    IdGender = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.IdGender);
                });

            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    InstrumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameInstrument = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.InstrumentId);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    AuditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.AuditId);
                    table.ForeignKey(
                        name: "FK_AuditLogs_ActionTypes_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalTable: "ActionTypes",
                        principalColumn: "ActionTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserUniqueId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusInvitationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "IdGender",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermission_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermission_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BandInvitations",
                columns: table => new
                {
                    InvitationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BandId = table.Column<int>(type: "int", nullable: false),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusInvitationId = table.Column<int>(type: "int", nullable: false),
                    InvitedBy = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcceptedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandInvitations", x => x.InvitationId);
                    table.ForeignKey(
                        name: "FK_BandInvitations_Profiles_InvitedBy",
                        column: x => x.InvitedBy,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BandInvitations_Statuses_StatusInvitationId",
                        column: x => x.StatusInvitationId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    BandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.BandId);
                    table.ForeignKey(
                        name: "FK_Bands_Profiles_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_Songs_Profiles_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInstrument",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InstrumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInstrument", x => new { x.UserId, x.InstrumentId });
                    table.ForeignKey(
                        name: "FK_UserInstrument_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "InstrumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInstrument_Profiles_UserId",
                        column: x => x.UserId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRol",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRol", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRol_Profiles_UserId",
                        column: x => x.UserId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRol_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBands",
                columns: table => new
                {
                    UserBandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BandId = table.Column<int>(type: "int", nullable: false),
                    BandRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBands", x => x.UserBandId);
                    table.ForeignKey(
                        name: "FK_UserBands_BandRoles_BandRoleId",
                        column: x => x.BandRoleId,
                        principalTable: "BandRoles",
                        principalColumn: "BandRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBands_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "BandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBands_Profiles_UserId",
                        column: x => x.UserId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SongVersions",
                columns: table => new
                {
                    VersionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VersionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false),
                    Album = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumCoverPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Compas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tempo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rhythm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BandId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongVersions", x => x.VersionId);
                    table.ForeignKey(
                        name: "FK_SongVersions_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "BandId");
                    table.ForeignKey(
                        name: "FK_SongVersions_Profiles_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongVersions_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SongVersionInstrumentPdfs",
                columns: table => new
                {
                    PdfId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VersionId = table.Column<int>(type: "int", nullable: false),
                    InstrumentId = table.Column<int>(type: "int", nullable: false),
                    UploadedBy = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongVersionInstrumentPdfs", x => x.PdfId);
                    table.ForeignKey(
                        name: "FK_SongVersionInstrumentPdfs_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "InstrumentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SongVersionInstrumentPdfs_Profiles_UploadedBy",
                        column: x => x.UploadedBy,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SongVersionInstrumentPdfs_SongVersions_VersionId",
                        column: x => x.VersionId,
                        principalTable: "SongVersions",
                        principalColumn: "VersionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SongVersionInstrumentVideos",
                columns: table => new
                {
                    VideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VersionId = table.Column<int>(type: "int", nullable: false),
                    InstrumentId = table.Column<int>(type: "int", nullable: false),
                    UploadedBy = table.Column<int>(type: "int", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongVersionInstrumentVideos", x => x.VideoId);
                    table.ForeignKey(
                        name: "FK_SongVersionInstrumentVideos_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "InstrumentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SongVersionInstrumentVideos_Profiles_UploadedBy",
                        column: x => x.UploadedBy,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SongVersionInstrumentVideos_SongVersions_VersionId",
                        column: x => x.VersionId,
                        principalTable: "SongVersions",
                        principalColumn: "VersionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SongVersionPdfs",
                columns: table => new
                {
                    PdfId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VersionId = table.Column<int>(type: "int", nullable: false),
                    UploadedBy = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongVersionPdfs", x => x.PdfId);
                    table.ForeignKey(
                        name: "FK_SongVersionPdfs_Profiles_UploadedBy",
                        column: x => x.UploadedBy,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SongVersionPdfs_SongVersions_VersionId",
                        column: x => x.VersionId,
                        principalTable: "SongVersions",
                        principalColumn: "VersionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BandRoles",
                columns: new[] { "BandRoleId", "Name" },
                values: new object[,]
                {
                    { 1, "Director" },
                    { 2, "Musico" },
                    { 3, "Técnico" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "IdGender", "GenderName" },
                values: new object[,]
                {
                    { 1, "Masculino" },
                    { 2, "Femenino" },
                    { 3, "Otro" }
                });

            migrationBuilder.InsertData(
                table: "Instruments",
                columns: new[] { "InstrumentId", "NameInstrument" },
                values: new object[,]
                {
                    { 1, "Trompeta" },
                    { 2, "Guitarra" },
                    { 3, "Bateria" },
                    { 4, "Otro" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Permite crear recursos", "Crear" },
                    { 2, "Permite leer recursos", "Leer" },
                    { 3, "Permite actualizar recursos", "Actualizar" },
                    { 4, "Permite eliminar recursos", "Eliminar" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Administrador del sistema", "Administrador" },
                    { 2, "Usuario estándar", "UsuarioEstandar" },
                    { 3, "Modera contenido", "Moderator" }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "FullName", "GenderId", "IsActive", "StatusInvitationId", "UserUniqueId" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 7, 12, 0, 0, 0, DateTimeKind.Utc), "Juan Pérez", 1, true, null, "user-unique-001" },
                    { 2, new DateTime(1992, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 7, 12, 0, 0, 0, DateTimeKind.Utc), "María López", 2, true, null, "user-unique-002" },
                    { 3, new DateTime(1985, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 7, 12, 0, 0, 0, DateTimeKind.Utc), "Carlos Martínez", 1, true, null, "user-unique-003" }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserRol",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_ActionTypeId",
                table: "AuditLogs",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BandInvitations_InvitedBy",
                table: "BandInvitations",
                column: "InvitedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BandInvitations_StatusInvitationId",
                table: "BandInvitations",
                column: "StatusInvitationId");

            migrationBuilder.CreateIndex(
                name: "IX_Bands_CreatedBy",
                table: "Bands",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_GenderId",
                table: "Profiles",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionId",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_CreatedBy",
                table: "Songs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SongVersionInstrumentPdfs_InstrumentId",
                table: "SongVersionInstrumentPdfs",
                column: "InstrumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SongVersionInstrumentPdfs_UploadedBy",
                table: "SongVersionInstrumentPdfs",
                column: "UploadedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SongVersionInstrumentPdfs_VersionId",
                table: "SongVersionInstrumentPdfs",
                column: "VersionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SongVersionInstrumentVideos_InstrumentId",
                table: "SongVersionInstrumentVideos",
                column: "InstrumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SongVersionInstrumentVideos_UploadedBy",
                table: "SongVersionInstrumentVideos",
                column: "UploadedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SongVersionInstrumentVideos_VersionId",
                table: "SongVersionInstrumentVideos",
                column: "VersionId");

            migrationBuilder.CreateIndex(
                name: "IX_SongVersionPdfs_UploadedBy",
                table: "SongVersionPdfs",
                column: "UploadedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SongVersionPdfs_VersionId",
                table: "SongVersionPdfs",
                column: "VersionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SongVersions_BandId",
                table: "SongVersions",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_SongVersions_CreatedBy",
                table: "SongVersions",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SongVersions_SongId",
                table: "SongVersions",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBands_BandId",
                table: "UserBands",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBands_BandRoleId",
                table: "UserBands",
                column: "BandRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBands_UserId",
                table: "UserBands",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInstrument_InstrumentId",
                table: "UserInstrument",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRol_RoleId",
                table: "UserRol",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "BandInvitations");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "SongVersionInstrumentPdfs");

            migrationBuilder.DropTable(
                name: "SongVersionInstrumentVideos");

            migrationBuilder.DropTable(
                name: "SongVersionPdfs");

            migrationBuilder.DropTable(
                name: "UserBands");

            migrationBuilder.DropTable(
                name: "UserInstrument");

            migrationBuilder.DropTable(
                name: "UserRol");

            migrationBuilder.DropTable(
                name: "ActionTypes");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "SongVersions");

            migrationBuilder.DropTable(
                name: "BandRoles");

            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Bands");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
