using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTextForVersions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SongVersionInstrumentTexts",
                columns: table => new
                {
                    TextId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VersionId = table.Column<int>(type: "int", nullable: false),
                    InstrumentId = table.Column<int>(type: "int", nullable: false),
                    UploadedBy = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongVersionInstrumentTexts", x => x.TextId);
                    table.ForeignKey(
                        name: "FK_SongVersionInstrumentTexts_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "InstrumentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SongVersionInstrumentTexts_Profiles_UploadedBy",
                        column: x => x.UploadedBy,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SongVersionInstrumentTexts_SongVersions_VersionId",
                        column: x => x.VersionId,
                        principalTable: "SongVersions",
                        principalColumn: "VersionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongVersionInstrumentTexts_InstrumentId",
                table: "SongVersionInstrumentTexts",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_SongVersionInstrumentTexts_UploadedBy",
                table: "SongVersionInstrumentTexts",
                column: "UploadedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SongVersionInstrumentTexts_VersionId",
                table: "SongVersionInstrumentTexts",
                column: "VersionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongVersionInstrumentTexts");
        }
    }
}
