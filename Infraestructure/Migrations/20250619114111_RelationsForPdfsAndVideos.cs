using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelationsForPdfsAndVideos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongVersionInstrumentPdfs_Instruments_InstrumentId",
                table: "SongVersionInstrumentPdfs");

            migrationBuilder.DropForeignKey(
                name: "FK_SongVersionInstrumentPdfs_SongVersions_VersionId",
                table: "SongVersionInstrumentPdfs");

            migrationBuilder.DropForeignKey(
                name: "FK_SongVersionInstrumentVideos_Instruments_InstrumentId",
                table: "SongVersionInstrumentVideos");

            migrationBuilder.DropIndex(
                name: "IX_SongVersionInstrumentVideos_InstrumentId",
                table: "SongVersionInstrumentVideos");

            migrationBuilder.DropIndex(
                name: "IX_SongVersionInstrumentPdfs_InstrumentId",
                table: "SongVersionInstrumentPdfs");

            migrationBuilder.DropIndex(
                name: "IX_SongVersionInstrumentPdfs_VersionId",
                table: "SongVersionInstrumentPdfs");

            migrationBuilder.CreateIndex(
                name: "IX_SongVersionInstrumentVideos_InstrumentId",
                table: "SongVersionInstrumentVideos",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_SongVersionInstrumentPdfs_InstrumentId",
                table: "SongVersionInstrumentPdfs",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_SongVersionInstrumentPdfs_VersionId",
                table: "SongVersionInstrumentPdfs",
                column: "VersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SongVersionInstrumentPdfs_Instruments_InstrumentId",
                table: "SongVersionInstrumentPdfs",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "InstrumentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongVersionInstrumentPdfs_SongVersions_VersionId",
                table: "SongVersionInstrumentPdfs",
                column: "VersionId",
                principalTable: "SongVersions",
                principalColumn: "VersionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongVersionInstrumentVideos_Instruments_InstrumentId",
                table: "SongVersionInstrumentVideos",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "InstrumentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongVersionInstrumentPdfs_Instruments_InstrumentId",
                table: "SongVersionInstrumentPdfs");

            migrationBuilder.DropForeignKey(
                name: "FK_SongVersionInstrumentPdfs_SongVersions_VersionId",
                table: "SongVersionInstrumentPdfs");

            migrationBuilder.DropForeignKey(
                name: "FK_SongVersionInstrumentVideos_Instruments_InstrumentId",
                table: "SongVersionInstrumentVideos");

            migrationBuilder.DropIndex(
                name: "IX_SongVersionInstrumentVideos_InstrumentId",
                table: "SongVersionInstrumentVideos");

            migrationBuilder.DropIndex(
                name: "IX_SongVersionInstrumentPdfs_InstrumentId",
                table: "SongVersionInstrumentPdfs");

            migrationBuilder.DropIndex(
                name: "IX_SongVersionInstrumentPdfs_VersionId",
                table: "SongVersionInstrumentPdfs");

            migrationBuilder.CreateIndex(
                name: "IX_SongVersionInstrumentVideos_InstrumentId",
                table: "SongVersionInstrumentVideos",
                column: "InstrumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SongVersionInstrumentPdfs_InstrumentId",
                table: "SongVersionInstrumentPdfs",
                column: "InstrumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SongVersionInstrumentPdfs_VersionId",
                table: "SongVersionInstrumentPdfs",
                column: "VersionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SongVersionInstrumentPdfs_Instruments_InstrumentId",
                table: "SongVersionInstrumentPdfs",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "InstrumentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SongVersionInstrumentPdfs_SongVersions_VersionId",
                table: "SongVersionInstrumentPdfs",
                column: "VersionId",
                principalTable: "SongVersions",
                principalColumn: "VersionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SongVersionInstrumentVideos_Instruments_InstrumentId",
                table: "SongVersionInstrumentVideos",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "InstrumentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
