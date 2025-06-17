using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BandsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongVersions_Bands_BandId",
                table: "SongVersions");

            migrationBuilder.DropTable(
                name: "UserBands");

            migrationBuilder.DropTable(
                name: "BandRoles");

            migrationBuilder.DropTable(
                name: "Bands");

            migrationBuilder.DropIndex(
                name: "IX_SongVersions_BandId",
                table: "SongVersions");

            migrationBuilder.DropColumn(
                name: "BandId",
                table: "SongVersions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BandId",
                table: "SongVersions",
                type: "int",
                nullable: true);

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
                name: "Bands",
                columns: table => new
                {
                    BandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "UserBands",
                columns: table => new
                {
                    UserBandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BandId = table.Column<int>(type: "int", nullable: false),
                    BandRoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.InsertData(
                table: "BandRoles",
                columns: new[] { "BandRoleId", "Name" },
                values: new object[,]
                {
                    { 1, "Director" },
                    { 2, "Musico" },
                    { 3, "Técnico" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongVersions_BandId",
                table: "SongVersions",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_Bands_CreatedBy",
                table: "Bands",
                column: "CreatedBy");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SongVersions_Bands_BandId",
                table: "SongVersions",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "BandId");
        }
    }
}
